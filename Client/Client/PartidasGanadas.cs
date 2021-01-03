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


namespace Client
{
    public partial class PartidasGanadas : Form
    {
        Socket server;
        string username;

        public void setrespuesta(string a)
        {

             if (a == "1/NoExist")
                {
                    label2.Text = "El jugador " + usernameconsulta.Text + " no existe.";
                }

                else
                {
                    label2.Text = "El jugador " + usernameconsulta.Text + " ha ganado " + a + " partidas.";
                }

       
        }

        public PartidasGanadas()
        {
            InitializeComponent();
        }

        public void setServer(Socket a)   
        {
            this.server = a;
        }

        private void PartidasGanadas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameconsulta.Text != "")
            {
                string mensaje = "1/" + usernameconsulta.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

               
                /*//Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                */
                /* if (mensaje == "1/NoExist")
                {
                    label2.Text = "El jugador " + usernameconsulta.Text + " no existe.";
                }

                else
                {
                    label2.Text = "El jugador " + usernameconsulta.Text + " ha ganado " + mensaje + " partidas.";
                }*/
            }
        }
    }
}
