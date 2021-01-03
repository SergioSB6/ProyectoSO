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

namespace Client
{
    public partial class Juego : Form
    {
        PictureBox jugador;
        PictureBox[] ocupados;
        int i=0;

        static int[,] array = new int[80, 40];//[50,20]//this is my array is the base of the game

      
        /// Variables para las direcciones
        static int izquierda = 0;
        static int derecha = 1;
        static int arriba = 2;
        static int abajo = 3;


        /// Variables Jugador
        Point y1 = new Point();
        static int puntosJugador = 0;
        static int direccionJugador = derecha;
        static int columnaJugador = 1; 
        static int filaJugador = 20;  

        
        //Metodos
        static void CambiarDireccionJugador(KeyPressEventArgs e)
        {
          
            if (e.KeyChar == 119 && direccionJugador != abajo)
            {
                direccionJugador = arriba;
            }
            if (e.KeyChar == 97 && direccionJugador != derecha)
            {
                direccionJugador = izquierda;
            }
            if (e.KeyChar == 100 && direccionJugador != izquierda)
            {
                direccionJugador = derecha;
            }
            if (e.KeyChar ==115 && direccionJugador != arriba)
            {
                direccionJugador = abajo;
            }
           
        }

       

        public Juego()
        {
            InitializeComponent();
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            jugador = new PictureBox();
            jugador.ClientSize = new Size(15, 15);



            Bitmap image = new Bitmap("circle.PNG");
            jugador.Image = (Image)image;

            

            columnaJugador = 1;
            filaJugador = 35;
            y1.X = columnaJugador;
            y1.Y = filaJugador;
            direccionJugador = derecha;

            jugador.Location = y1;
            panel1.Controls.Add(jugador);

            
            timer1.Interval = 100;
            timer1.Start();
        }

        private void Juego_KeyPress(object sender, KeyPressEventArgs e)
        {
            CambiarDireccionJugador(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ocupados = new PictureBox[50000];

            PictureBox puntoocupado = new PictureBox();
            puntoocupado.ClientSize = new Size(15, 15);
            puntoocupado.Location = y1;
            //puntoocupado.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap image2 = new Bitmap("Captura.PNG");
            puntoocupado.Image = (Image)image2;

            panel1.Controls.Add(puntoocupado);

            ocupados[i] = puntoocupado;
            

            if (direccionJugador == arriba)
            {
                y1.Y = y1.Y - 10;
            }

            if (direccionJugador == abajo)
            {
                y1.Y = y1.Y + 10;
            }

            if (direccionJugador == derecha)
            {
                y1.X = y1.X + 10;
            }

            if (direccionJugador == izquierda)
            {
                y1.X = y1.X - 10;
            }

            if (y1.X >= 776)
            {
                timer1.Stop();
            }
            else if (y1.Y >= 426)
            {
                timer1.Stop();
            }
            else if (y1.X <= 0)
            {
                timer1.Stop();
            }
            else if (y1.Y <= 0)
            {
                timer1.Stop();
            }
            else
            {
                jugador.Location = y1;
                panel1.Invalidate();
            }
            
        }
    }
}
