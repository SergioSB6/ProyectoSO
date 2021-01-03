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
using System.Threading;

namespace Client
{
    
    public partial class User : Form
    {
        int estado = 0;
        Socket server;
        int puerto = 50005;
        Principal prin; 

        public User()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("147.83.117.22");
                IPEndPoint ipep = new IPEndPoint(direc, puerto);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.Green;
                    MessageBox.Show("Conectado");

                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }



                string user = username.Text;
                string pass = password.Text;
                string mensaje = "100/" + user + "/" + pass;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                if (mensaje == "100/Correct")
                {
                    MessageBox.Show("Welcome " + user + ".");
                    prin = new Principal();
                    prin.setServer(server);
                    prin.setUser(user);
                    this.Hide();
                    prin.ShowDialog();

                    estado = prin.getStatus();

                    if (estado == 0)

                    {
                        mensaje = "0/";

                        msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        // Nos desconectamos
                        this.BackColor = Color.Gray;
                        server.Shutdown(SocketShutdown.Both);
                        server.Close();
                    }
                    //Mensaje de desconexión
                    
                    this.Close();
                }

                else 
                {
                    if (mensaje == "100/NoUser")
                    {
                    MessageBox.Show("El usuario introducido no existe, porfavor regístrese.");
                    }
                    else if (mensaje == "100/Incorrect")
                    {
                        MessageBox.Show("Contraseña incorrecta.");
                    }
                    //Mensaje de desconexión
                    mensaje = "0/";

                    msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    // Nos desconectamos
                    this.BackColor = Color.Gray;
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("147.83.117.22");
            IPEndPoint ipep = new IPEndPoint(direc, puerto);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado.");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No se ha podido conectar con el servidor.");
                return;
            }


            string user = username.Text;
            string pass = password.Text;
            string mensaje = "101/" + user + "/" + pass;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            if (mensaje == "101/Correct")
            {
                MessageBox.Show("Registro completado.");
            }

            else if (mensaje == "101/Incorrect")
            {
                MessageBox.Show("El usuario ya existe.");
            }

            else if (mensaje == "101/Incorrect2")
            {
                MessageBox.Show("Error de registro, inténtalo de nuevo.");
            }

            //Mensaje de desconexión
            mensaje = "0/";

            msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
