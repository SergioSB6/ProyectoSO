namespace Client
{
    partial class Principal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuantasPartidasHeGanadoEnTotalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horaYFechaDeUnaPartidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuántasPartidasGanéElDiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ShowConectados = new System.Windows.Forms.DataGridView();
            this.Desconectar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Chat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.servicios_rec = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowConectados)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(594, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuantasPartidasHeGanadoEnTotalToolStripMenuItem,
            this.quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem,
            this.horaYFechaDeUnaPartidaToolStripMenuItem,
            this.cuántasPartidasGanéElDiaToolStripMenuItem});
            this.consultasToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.consultasToolStripMenuItem.Text = "CONSULTAS";
            // 
            // cuantasPartidasHeGanadoEnTotalToolStripMenuItem
            // 
            this.cuantasPartidasHeGanadoEnTotalToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuantasPartidasHeGanadoEnTotalToolStripMenuItem.Name = "cuantasPartidasHeGanadoEnTotalToolStripMenuItem";
            this.cuantasPartidasHeGanadoEnTotalToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.cuantasPartidasHeGanadoEnTotalToolStripMenuItem.Text = "¿Cuántas partidas ha ganado el jugador...";
            this.cuantasPartidasHeGanadoEnTotalToolStripMenuItem.Click += new System.EventHandler(this.cuantasPartidasHeGanadoEnTotalToolStripMenuItem_Click);
            // 
            // quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem
            // 
            this.quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem.Name = "quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem";
            this.quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem.Text = "¿Quién ha ganado una partida de más de 10min?";
            this.quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem.Click += new System.EventHandler(this.quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem_Click);
            // 
            // horaYFechaDeUnaPartidaToolStripMenuItem
            // 
            this.horaYFechaDeUnaPartidaToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horaYFechaDeUnaPartidaToolStripMenuItem.Name = "horaYFechaDeUnaPartidaToolStripMenuItem";
            this.horaYFechaDeUnaPartidaToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.horaYFechaDeUnaPartidaToolStripMenuItem.Text = "Hora y fecha de una partida";
            this.horaYFechaDeUnaPartidaToolStripMenuItem.Click += new System.EventHandler(this.horaYFechaDeUnaPartidaToolStripMenuItem_Click);
            // 
            // cuántasPartidasGanéElDiaToolStripMenuItem
            // 
            this.cuántasPartidasGanéElDiaToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuántasPartidasGanéElDiaToolStripMenuItem.Name = "cuántasPartidasGanéElDiaToolStripMenuItem";
            this.cuántasPartidasGanéElDiaToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.cuántasPartidasGanéElDiaToolStripMenuItem.Text = "¿Cuántas partidas gané el día...";
            this.cuántasPartidasGanéElDiaToolStripMenuItem.Click += new System.EventHandler(this.cuántasPartidasGanéElDiaToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(455, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "*Haz click en un jugador conectado para invitar a partida o chatear.";
            // 
            // ShowConectados
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.ShowConectados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ShowConectados.BackgroundColor = System.Drawing.Color.White;
            this.ShowConectados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ShowConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShowConectados.GridColor = System.Drawing.Color.White;
            this.ShowConectados.Location = new System.Drawing.Point(14, 49);
            this.ShowConectados.Name = "ShowConectados";
            this.ShowConectados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ShowConectados.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.ShowConectados.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.ShowConectados.Size = new System.Drawing.Size(135, 184);
            this.ShowConectados.TabIndex = 4;
            this.ShowConectados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowConectados_CellClick);
            // 
            // Desconectar
            // 
            this.Desconectar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Desconectar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Desconectar.FlatAppearance.BorderSize = 2;
            this.Desconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Desconectar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desconectar.Location = new System.Drawing.Point(458, 42);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(111, 33);
            this.Desconectar.TabIndex = 5;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = false;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ShowConectados);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(10, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 261);
            this.panel2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-4, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 38);
            this.label4.TabIndex = 12;
            this.label4.Text = "JUGADORES CONECTADOS";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(208, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 33);
            this.button1.TabIndex = 10;
            this.button1.Text = "Jugar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.Color.White;
            this.Chat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Chat.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chat.Location = new System.Drawing.Point(208, 83);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(84, 33);
            this.Chat.TabIndex = 11;
            this.Chat.Text = "Chat";
            this.Chat.UseVisualStyleBackColor = false;
            this.Chat.Click += new System.EventHandler(this.Chat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 24);
            this.label3.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // servicios_rec
            // 
            this.servicios_rec.BackColor = System.Drawing.Color.Transparent;
            this.servicios_rec.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servicios_rec.ForeColor = System.Drawing.Color.White;
            this.servicios_rec.Location = new System.Drawing.Point(564, 359);
            this.servicios_rec.Name = "servicios_rec";
            this.servicios_rec.Size = new System.Drawing.Size(30, 23);
            this.servicios_rec.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(397, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Número de consultas realizadas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-3, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(381, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "*Haz click en la pestaña de arriba para hacer consultas de partidas.";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(594, 386);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.servicios_rec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Chat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowConectados)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuantasPartidasHeGanadoEnTotalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quienHaGanadoUnaPartidaDeMásDe10minToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horaYFechaDeUnaPartidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuántasPartidasGanéElDiaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ShowConectados;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Chat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label servicios_rec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}