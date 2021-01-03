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
    public partial class GanadasDia : Form
    {
        string username;
        Socket server;
        public GanadasDia()
        {
            InitializeComponent();
        }

        public void setrespuesta (string a)
        
        {
            label2.Text = "El día " + textBox1.Text + " ganaste " + a + " partidas.";
        }

        public void setName(string a)
        {
            this.username = a;
        }

        public void setServer(Socket a)
        {
            this.server = a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string mensaje = "4/" + username + "-" + textBox1.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

               /*//Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                label2.Text = "El día " + textBox1.Text + " ganaste " + mensaje + " partidas."; */
            }
        }

        private void GanadasDia_Load(object sender, EventArgs e)
        {

        }
    }
}
