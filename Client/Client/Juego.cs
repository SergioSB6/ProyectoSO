using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public partial class Juego : Form
    {

        Socket server;
        /*
         int njugadores;
        int jugadoresrestantes;
        Socket server;
         */

        int i=0;
        int playerNum;
        int numJugadores;

        static int[,] array = new int[80, 40];//[50,20]//this is my array is the base of the game

      
        /// Variables para las direcciones
        static int izquierda = 0;
        static int derecha = 1;
        static int arriba = 2;
        static int abajo = 3;


        /// Variables Jugador
        List<Point> puntosOcupados = new List<Point>();
        
        Point[] posicionJugadores = new Point[4];
        public int[] direccionesJugadores = new int[4];
        Bitmap[] imagenesJugadores = new Bitmap[4];

        static int puntosJugador = 0;
        static int columnaJugador = 1; 
        static int filaJugador = 20;
        public Juego(int numJugadores)
        {
            InitializeComponent();
            this.numJugadores = numJugadores;
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < numJugadores; i++)
            {
                if(i == 0)
                {
                    posicionJugadores[i] = new Point(1,1);
                    direccionesJugadores[i] = derecha;
                    imagenesJugadores[i] = new Bitmap("..//..//circle.PNG");
                }
                else if (i == 1)
                {
                    posicionJugadores[i] = new Point(5, 5);
                    direccionesJugadores[i] = derecha;
                    imagenesJugadores[i] = new Bitmap("..//..//circle.PNG");

                }
                else if (i == 2)
                {
                    posicionJugadores[i] = new Point(1,5);
                    direccionesJugadores[i] = derecha;
                    imagenesJugadores[i] = new Bitmap("..//..//circle.PNG");

                }
                else if (i == 3)
                {
                    posicionJugadores[i] = new Point(5,1);
                    direccionesJugadores[i] = derecha;
                    imagenesJugadores[i] = new Bitmap("..//..//circle.PNG");

                }
            }

            //jugador1 = new PictureBox();
            //jugador1.ClientSize = new Size(10, 10);
            ////Bitmap image = new Bitmap("..//..//circle.PNG");
            ////var image = Image.FromFile("..//..//Black_Circle.jpg");
            ////jugador.Image = image;

            //columnaJugador = 1;
            //filaJugador = 35;
            //j1.X = columnaJugador;
            //j1.Y = filaJugador;
            //direccionJugador = derecha;

            //jugador1.Location = j1;
            //panel1.Controls.Add(jugador1);

            //jugador2 = new PictureBox();
            //jugador2.ClientSize = new Size(10, 10);
            ////Bitmap image = new Bitmap("..//..//circle.PNG");
            ////var image = Image.FromFile("..//..//Black_Circle.jpg");
            ////jugador.Image = image;

            //columnaJugador = 35;
            //filaJugador = 1;
            //j2.X = columnaJugador;
            //j2.Y = filaJugador;
            //direccionJugador = izquierda;

            //jugador2.Location = j2;
            //panel1.Controls.Add(jugador2);


            timer1.Interval = 100;
            timer1.Start();
        }

        private void Juego_KeyPress(object sender, KeyPressEventArgs e)
        {
            CambiarDireccionJugadorPropio(e);
        }


        public void setServer(Socket a)   //Se utiliza para pasar transpasar los datos entre formularios
        {
            this.server = a;
        }

        public void setPlayer(int player)
        {
            this.playerNum = player;
        }

        //Metodos
        public void CambiarDireccionJugadorPropio(KeyPressEventArgs e)
        {
          
            if (e.KeyChar == 119 && direccionesJugadores[playerNum] != abajo
                                 && direccionesJugadores[playerNum] != arriba)
            {
                direccionesJugadores[playerNum] = arriba;
            }
            else if (e.KeyChar == 97 && direccionesJugadores[playerNum] != derecha
                                     && direccionesJugadores[playerNum] != izquierda)
            {
                direccionesJugadores[playerNum] = izquierda;

            }
            else if (e.KeyChar == 100 && direccionesJugadores[playerNum] != izquierda
                                      && direccionesJugadores[playerNum] != derecha)
            {
                direccionesJugadores[playerNum] = derecha;
            }
            else if (e.KeyChar ==115 && direccionesJugadores[playerNum]!= arriba
                                     && direccionesJugadores[playerNum] != abajo)
            {
                direccionesJugadores[playerNum] = abajo;
            }
            else
            {
                return;
            }

            string msg1 = "21/" + playerNum + "/" + direccionesJugadores[playerNum];
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(msg1);
            server.Send(msg);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < numJugadores; i++)
            {
                if (posicionJugadores[i].X >= 776)
                {
                    timer1.Stop();
                    return;
                }
                else if (posicionJugadores[i].Y >= 426)
                {
                    timer1.Stop();
                    return;
                }
                else if (posicionJugadores[i].X <= 0)
                {
                    timer1.Stop();
                    return;
                }
                else if (posicionJugadores[i].Y <= 0)
                {
                    timer1.Stop();
                    return;
                }
                
                foreach(var p in puntosOcupados)
                {
                    if(posicionJugadores[i] == new Point(p.X, p.Y))
                    {
                        timer1.Stop();
                        return;
                    }
                }

                PictureBox puntoOcupado = new PictureBox();
                puntoOcupado.ClientSize = new Size(15, 15);
                puntoOcupado.Location = posicionJugadores[i];               
                puntoOcupado.Image = (Image)imagenesJugadores[i];
                puntosOcupados.Add(posicionJugadores[i]);

                panel1.Controls.Add(puntoOcupado);


                if (direccionesJugadores[i] == arriba)
                {
                    posicionJugadores[i] = new Point(posicionJugadores[i].X, posicionJugadores[i].Y  - 10);
                }
                else if (direccionesJugadores[i] == abajo)
                {
                    posicionJugadores[i] = new Point(posicionJugadores[i].X, posicionJugadores[i].Y + 10);
                }
                else if (direccionesJugadores[i] == derecha)
                {
                    posicionJugadores[i] = new Point(posicionJugadores[i].X + 10, posicionJugadores[i].Y );
                }
                else if (direccionesJugadores[i] == izquierda)
                {
                    posicionJugadores[i] = new Point(posicionJugadores[i].X - 10, posicionJugadores[i].Y);
                }


            }
            //ocupados2 = new PictureBox[50000];

            //PictureBox puntoocupado2 = new PictureBox();
            //puntoocupado2.ClientSize = new Size(15, 15);
            //puntoocupado2.Location = j2;
            ////puntoocupado.SizeMode = PictureBoxSizeMode.StretchImage;
            //Bitmap image = new Bitmap("..//..//circle.PNG");
            //puntoocupado2.Image = (Image)image2;

            //panel1.Controls.Add(puntoocupado2);

            //ocupados2[i] = puntoocupado2;

            //byte[] info = new byte[80];
            //byte[] info2 = new byte[80];
            //byte[] msg = System.Text.Encoding.ASCII.GetBytes("22/");
            //server.Send(msg);
            //server.Receive(info);

            //string[] trozos = Encoding.ASCII.GetString(info).Split('/');
            //int dir1 = Convert.ToInt32(trozos[0]);

            

            //byte[] msg2 = System.Text.Encoding.ASCII.GetBytes("23/");
            //server.Send(msg2);
            //server.Receive(info2);
            //string[] trozos2 = Encoding.ASCII.GetString(info2).Split('/');
            //int dir2 = Convert.ToInt32(trozos2[0]);

            //MoverJugadores(j2, dir2, jugador2);
        }
    }
}
