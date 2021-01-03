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

namespace Client
{
    public partial class HoraFecha : Form
    {
        Socket server;
        public HoraFecha()

        {
            InitializeComponent();
        }

        public void setServer(Socket a)
        {
            this.server = a;
        }

        private void HoraFecha_Load(object sender, EventArgs e)
        {

        }

        public void setrespuesta(string a)

        {
            if (a == "3/NoExist")
            {
                label2.Text = "La partida con el ID: " + IDpartida.Text + " no existe.";
            }

            else
            {
                label2.Text = "La partida fue jugada el " + a + ".";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IDpartida.Text != "")
            {
                string mensaje = "3/" + IDpartida.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                /*//Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                if (mensaje == "3/NoExist")
                {
                    label2.Text = "La partida con el ID: " + IDpartida.Text + " no existe.";
                }

                else
                {
                    label2.Text = "La partida fue jugada el " + mensaje + ".";
                }*/
            }
        }
    }
}
