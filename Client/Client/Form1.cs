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
    public partial class Chat : Form
    {
        Socket server;
        string username;
        bool estaEnSala;
        public ListBox chatMensajes;

        public Chat(string username, bool estaEnSala, Socket server)
        {
            InitializeComponent();

            this.username = username;
            this.estaEnSala = estaEnSala;
            this.server = server;
            chatMensajes = ChatMensajes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            if (!estaEnSala)
            {
                MessageBox.Show("No estas en ninguna sala, invita a alguien para chatear");
                return;
            }

            string mensaje = "8/" + username + "-" + MensajeChat.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            MensajeChat.Text = "";
        }
    }
}
