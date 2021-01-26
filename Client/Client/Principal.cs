using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows;

namespace Client
{
    public partial class Principal : Form
    {
        int estado;
        string ListaConectados;
        Socket server;
        string username;
        bool estaEnSala = false;
        PartidasGanadas pg;
        HoraFecha hf;
        GanadasDia gd;
        Ganadores10min gm;
        Thread atender;
        Chat chat = null;
        Juego juego;

        int tiempo = 10;

        delegate void DelegadoParaEscribir(string mensaje);
        public Principal(Socket socket)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            this.server = socket;

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
            label1.Text = "Usuario: " + username;

            //Start game for testing
            //juego = new Juego(1);
            //juego.setServer(server);
            //juego.setPlayer(0);
            //juego.ShowDialog();
        }
        public void setStatus (int a)
        {
            this.estado = a;
        }
        
        public int getStatus()
        {
            return estado;
        }

        public void setUser(string a)  
        {
            this.username = a;
        }

        public void PonContador(string contador)
        {
            servicios_rec.Text = contador;
        }
       
 //////////////////////////////////////// ATENDER SERVER/////////////////////////////////////////////

        public void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');

                //if (trozos[0].GetType() == typeof(string))
                //    return;

                //int codigo = Convert.ToInt32(trozos[0]);

                int codigo;
                bool parse = int.TryParse(trozos[0], out codigo);

                if (!parse)
                    return;

                string mensaje = trozos[1].Split('\0')[0];

                switch (codigo)
                {

                    case 1:   // Respuesta a partidas ganadas por un jugador x

                        pg.setrespuesta(mensaje);
                        break;

                    case 2: // Ganadores de partidas de >10min

                        gm = new Ganadores10min();
                        gm.setLista(mensaje);
                        gm.ShowDialog();
                        break;


                    case 3: // Respuesta a la hora y la fecha de una partida 

                        hf.setrespuesta(mensaje);
                        break;

                    case 4:  // Respuesta a partidas un día x

                        gd.setrespuesta(mensaje);
                        break;

                    case 7: // Respuesta a lista de conectados 

                        string[] vector = new string[5];
                        vector = mensaje.Split(',');

                        ShowConectados.RowHeadersVisible = false;
                        ShowConectados.ColumnHeadersVisible = false;
                        ShowConectados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        ShowConectados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        ShowConectados.RowCount = vector.Length;
                        ShowConectados.ColumnCount = 1;

                        int i = 0;
                        while (i < vector.Length)
                        {

                            if (i == 0)
                            {
                                ShowConectados.Rows[i].Cells[0].Value = "Número de conectados: " + vector[i];
                            }
                            else
                            {
                                ShowConectados.Rows[i].Cells[0].Value = vector[i];
                            }
                            i++;
                        }
                        break;

                    case 6: // Respuesta servicios realizados 
                        {
                            servicios_rec.Text = "Número total de servicios: " + mensaje;
                            DelegadoParaEscribir delegado = new DelegadoParaEscribir(PonContador);
                            servicios_rec.Invoke(delegado, new object[] { mensaje });
                            break;
                        }
                    case 8:
                        //He enviado invitación correctamente
                        MessageBox.Show("Invitación enviada correctamente");
                        break;
                    case 9:
                        //Recibo invitación
                        //Puedo rechazar o aceptar

                        DialogResult dialogResult = MessageBox.Show("Has recibido una invitación de " + mensaje + ", aceptas?", " Invitación a partida ", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {


                            string msg1 = "6/" + mensaje + "-" + "yes";
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(msg1);
                            //byte[] msg = System.Text.Encoding.ASCII.GetBytes("6/");
                            estaEnSala = true;
                            server.Send(msg);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                             string msg1 = "6/" + mensaje + "-" + "no";
                             byte[] msg = System.Text.Encoding.ASCII.GetBytes(msg1);
                            server.Send(msg);
                        }
                        break;
                    case 10:
                        {
                            var result = mensaje.Split(',');

                            if (result[1] == "yes")
                            {
                                estaEnSala = true;
                                
                            }
                            else
                            {
                                MessageBox.Show(result[0] + " ha rechazado tu invitación");
                            }
                        break;
                        }
                    case 11:
                        {
                            if(chat == null)
                                break;

                            var result = mensaje.Split(',');

                            if (chat.chatMensajes == null)
                                chat.chatMensajes = new ListBox();


                            chat.chatMensajes.Items.Add(result[0] + ": " + result[1]);

                            break;
                        }

                    case 12:
                        {
                            //Leemos el indice de nestro player
                            var result = mensaje.Split(',');

                            for (int j = 10; j >= 0; j--)
                            {
                                label3.BackColor = Color.White;
                                label3.ForeColor = Color.Black;
                                label3.Text = "La partida empieza en: \n" + j;
                                Thread.Sleep(1000);
                            }

                            //byte[] player = new byte[80];
                            //server.Receive(player);

                            //Start game
                            juego = new Juego(Convert.ToInt32(result[1]));
                            juego.setServer(server);
                            juego.setPlayer(Convert.ToInt32(result[0]));
                            juego.ShowDialog();
                            
                            break;                        
                            
                        }
                    case 13:
                        {
                            // Es el admin
                            button1.Enabled = true;
                            break;
                        }
                    case 14:
                        {
                            //Cambio de dirección de un usuario
                            var result = mensaje.Split(',');
                            juego.direccionesJugadores[Convert.ToInt32(result[0])] = Convert.ToInt32(result[1]);
                            break;
                        }
                }
            }
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("La partida empieza en: \n" + tiempo);
            //label3.Text = "La partida empieza en: \n" + tiempo;

            //if(tiempo == 0)
            //{
            //    timer1.Stop();
            //    //Start game
            //    return;
            //}

            //tiempo--;
        }

        //////////////////////////////////////// ATENDER SERVER/////////////////////////////////////////////


        private void cuantasPartidasHeGanadoEnTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            pg = new PartidasGanadas();
            pg.setServer(server);
            pg.ShowDialog();

        }

        private void quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            string mensaje = "2/vacio";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            
        }

        private void horaYFechaDeUnaPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hf = new HoraFecha();
            hf.setServer(server);
            hf.ShowDialog();
        }

        private void cuántasPartidasGanéElDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gd = new GanadasDia();
            gd.setServer(server);
            gd.setName(username);
            gd.ShowDialog();
        }

       

        private void Desconectar_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            estado = 1;
            string mensaje = "0/"+username;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Lavender;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            Close();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            

            string msg1 = "9/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(msg1);
            server.Send(msg);

        }

        private void ShowConectados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = 0;
            DataGridViewCell cell = (DataGridViewCell)ShowConectados.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string userName = cell.EditedFormattedValue.ToString();
            string mensaje = "5/" + userName;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void Chat_Click(object sender, EventArgs e)
        {
            chat = new Chat(username, estaEnSala, server);
            chat.ShowDialog();
        }

    }
}
