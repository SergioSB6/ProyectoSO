namespace Client
{
    partial class Chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChatMensajes = new System.Windows.Forms.ListBox();
            this.Enviar = new System.Windows.Forms.Button();
            this.MensajeChat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ChatMensajes
            // 
            this.ChatMensajes.FormattingEnabled = true;
            this.ChatMensajes.Items.AddRange(new object[] {
            " "});
            this.ChatMensajes.Location = new System.Drawing.Point(12, 12);
            this.ChatMensajes.Name = "ChatMensajes";
            this.ChatMensajes.Size = new System.Drawing.Size(214, 186);
            this.ChatMensajes.TabIndex = 0;
            // 
            // Enviar
            // 
            this.Enviar.Location = new System.Drawing.Point(205, 222);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(57, 23);
            this.Enviar.TabIndex = 2;
            this.Enviar.Text = "Enviar";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // MensajeChat
            // 
            this.MensajeChat.Location = new System.Drawing.Point(12, 224);
            this.MensajeChat.Name = "MensajeChat";
            this.MensajeChat.Size = new System.Drawing.Size(179, 20);
            this.MensajeChat.TabIndex = 3;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(276, 261);
            this.Controls.Add(this.MensajeChat);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.ChatMensajes);
            this.Name = "Chat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ChatMensajes;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.TextBox MensajeChat;
    }
}