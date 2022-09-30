
namespace Pt1b_WebSockets_Client
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbLocalHost = new System.Windows.Forms.TextBox();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMissatges = new System.Windows.Forms.ListBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.lbCarta1 = new System.Windows.Forms.Label();
            this.lbCarta2 = new System.Windows.Forms.Label();
            this.lbCarta3 = new System.Windows.Forms.Label();
            this.lbCarta4 = new System.Windows.Forms.Label();
            this.lbCarta5 = new System.Windows.Forms.Label();
            this.lbCartaEntra = new System.Windows.Forms.Label();
            this.chkAutoscroll = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbConnectar = new System.Windows.Forms.Label();
            this.btEnviar = new Poker.RJControls.RJButton();
            this.chkConnectar = new Poker.RJControls.RJToggleButton();
            this.chkInici = new Poker.RJControls.RJToggleButton();
            this.btAdquirir = new Poker.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbLocalHost
            // 
            this.tbLocalHost.BackColor = System.Drawing.Color.DarkGreen;
            this.tbLocalHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLocalHost.ForeColor = System.Drawing.SystemColors.Info;
            this.tbLocalHost.Location = new System.Drawing.Point(25, 31);
            this.tbLocalHost.Name = "tbLocalHost";
            this.tbLocalHost.Size = new System.Drawing.Size(290, 26);
            this.tbLocalHost.TabIndex = 0;
            // 
            // tbNom
            // 
            this.tbNom.BackColor = System.Drawing.Color.DarkGreen;
            this.tbNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNom.ForeColor = System.Drawing.SystemColors.Info;
            this.tbNom.Location = new System.Drawing.Point(343, 29);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(215, 26);
            this.tbNom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Url Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(340, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nom Usuari";
            // 
            // lbMissatges
            // 
            this.lbMissatges.BackColor = System.Drawing.Color.DarkGreen;
            this.lbMissatges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMissatges.ForeColor = System.Drawing.SystemColors.Info;
            this.lbMissatges.FormattingEnabled = true;
            this.lbMissatges.ItemHeight = 20;
            this.lbMissatges.Location = new System.Drawing.Point(142, 69);
            this.lbMissatges.Name = "lbMissatges";
            this.lbMissatges.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbMissatges.Size = new System.Drawing.Size(623, 124);
            this.lbMissatges.TabIndex = 5;
            // 
            // tbMessage
            // 
            this.tbMessage.BackColor = System.Drawing.Color.DarkGreen;
            this.tbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessage.ForeColor = System.Drawing.SystemColors.Info;
            this.tbMessage.Location = new System.Drawing.Point(25, 597);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(554, 26);
            this.tbMessage.TabIndex = 5;
            // 
            // lbCarta1
            // 
            this.lbCarta1.AutoSize = true;
            this.lbCarta1.BackColor = System.Drawing.Color.Transparent;
            this.lbCarta1.Font = new System.Drawing.Font("Consolas", 110F);
            this.lbCarta1.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbCarta1.Image = global::Poker.Properties.Resources.cardsBack;
            this.lbCarta1.Location = new System.Drawing.Point(76, 200);
            this.lbCarta1.Name = "lbCarta1";
            this.lbCarta1.Size = new System.Drawing.Size(155, 172);
            this.lbCarta1.TabIndex = 8;
            this.lbCarta1.Text = "🂠";
            // 
            // lbCarta2
            // 
            this.lbCarta2.AutoSize = true;
            this.lbCarta2.BackColor = System.Drawing.Color.Transparent;
            this.lbCarta2.Font = new System.Drawing.Font("Consolas", 110F);
            this.lbCarta2.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbCarta2.Image = global::Poker.Properties.Resources.cardsBack;
            this.lbCarta2.Location = new System.Drawing.Point(202, 200);
            this.lbCarta2.Name = "lbCarta2";
            this.lbCarta2.Size = new System.Drawing.Size(155, 172);
            this.lbCarta2.TabIndex = 10;
            this.lbCarta2.Text = "🂠";
            // 
            // lbCarta3
            // 
            this.lbCarta3.AutoSize = true;
            this.lbCarta3.BackColor = System.Drawing.Color.Transparent;
            this.lbCarta3.Font = new System.Drawing.Font("Consolas", 110F);
            this.lbCarta3.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbCarta3.Image = global::Poker.Properties.Resources.cardsBack;
            this.lbCarta3.Location = new System.Drawing.Point(326, 200);
            this.lbCarta3.Name = "lbCarta3";
            this.lbCarta3.Size = new System.Drawing.Size(155, 172);
            this.lbCarta3.TabIndex = 12;
            this.lbCarta3.Text = "🂠";
            // 
            // lbCarta4
            // 
            this.lbCarta4.AutoSize = true;
            this.lbCarta4.BackColor = System.Drawing.Color.Transparent;
            this.lbCarta4.Font = new System.Drawing.Font("Consolas", 110F);
            this.lbCarta4.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbCarta4.Image = global::Poker.Properties.Resources.cardsBack;
            this.lbCarta4.Location = new System.Drawing.Point(454, 199);
            this.lbCarta4.Name = "lbCarta4";
            this.lbCarta4.Size = new System.Drawing.Size(155, 172);
            this.lbCarta4.TabIndex = 13;
            this.lbCarta4.Text = "🂠";
            // 
            // lbCarta5
            // 
            this.lbCarta5.AutoSize = true;
            this.lbCarta5.BackColor = System.Drawing.Color.Transparent;
            this.lbCarta5.Font = new System.Drawing.Font("Consolas", 110F);
            this.lbCarta5.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbCarta5.Image = global::Poker.Properties.Resources.cardsBack;
            this.lbCarta5.Location = new System.Drawing.Point(586, 199);
            this.lbCarta5.Name = "lbCarta5";
            this.lbCarta5.Size = new System.Drawing.Size(155, 172);
            this.lbCarta5.TabIndex = 14;
            this.lbCarta5.Text = "🂠";
            // 
            // lbCartaEntra
            // 
            this.lbCartaEntra.AutoSize = true;
            this.lbCartaEntra.BackColor = System.Drawing.Color.Transparent;
            this.lbCartaEntra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCartaEntra.Font = new System.Drawing.Font("Consolas", 110F);
            this.lbCartaEntra.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbCartaEntra.Image = global::Poker.Properties.Resources.cardsBack;
            this.lbCartaEntra.Location = new System.Drawing.Point(326, 379);
            this.lbCartaEntra.Name = "lbCartaEntra";
            this.lbCartaEntra.Size = new System.Drawing.Size(155, 172);
            this.lbCartaEntra.TabIndex = 15;
            this.lbCartaEntra.Text = "🂠";
            // 
            // chkAutoscroll
            // 
            this.chkAutoscroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoscroll.BackColor = System.Drawing.Color.Transparent;
            this.chkAutoscroll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoscroll.Checked = true;
            this.chkAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoscroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoscroll.ForeColor = System.Drawing.SystemColors.Info;
            this.chkAutoscroll.Location = new System.Drawing.Point(671, 199);
            this.chkAutoscroll.Name = "chkAutoscroll";
            this.chkAutoscroll.Size = new System.Drawing.Size(94, 20);
            this.chkAutoscroll.TabIndex = 16;
            this.chkAutoscroll.Text = "Auto scroll";
            this.chkAutoscroll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoscroll.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Poker.Properties.Resources.logoPokerVallbona;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(28, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 94);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(680, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Iniciar Partida";
            // 
            // lbConnectar
            // 
            this.lbConnectar.AutoSize = true;
            this.lbConnectar.BackColor = System.Drawing.Color.Transparent;
            this.lbConnectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConnectar.ForeColor = System.Drawing.SystemColors.Info;
            this.lbConnectar.Location = new System.Drawing.Point(580, 7);
            this.lbConnectar.Name = "lbConnectar";
            this.lbConnectar.Size = new System.Drawing.Size(77, 18);
            this.lbConnectar.TabIndex = 21;
            this.lbConnectar.Text = "Connectar";
            // 
            // btEnviar
            // 
            this.btEnviar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btEnviar.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.btEnviar.BorderColor = System.Drawing.Color.DimGray;
            this.btEnviar.BorderRadius = 12;
            this.btEnviar.BorderSize = 1;
            this.btEnviar.FlatAppearance.BorderSize = 0;
            this.btEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnviar.ForeColor = System.Drawing.Color.Black;
            this.btEnviar.Location = new System.Drawing.Point(597, 589);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(172, 34);
            this.btEnviar.TabIndex = 6;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.TextColor = System.Drawing.Color.Black;
            this.btEnviar.UseVisualStyleBackColor = false;
            // 
            // chkConnectar
            // 
            this.chkConnectar.AutoCheck = false;
            this.chkConnectar.AutoEllipsis = true;
            this.chkConnectar.BackColor = System.Drawing.Color.Transparent;
            this.chkConnectar.Location = new System.Drawing.Point(580, 26);
            this.chkConnectar.MinimumSize = new System.Drawing.Size(45, 22);
            this.chkConnectar.Name = "chkConnectar";
            this.chkConnectar.OffBackColor = System.Drawing.Color.DarkGray;
            this.chkConnectar.OffToggleColor = System.Drawing.Color.Red;
            this.chkConnectar.OnBackColor = System.Drawing.Color.Teal;
            this.chkConnectar.OnToggleColor = System.Drawing.Color.Lime;
            this.chkConnectar.Size = new System.Drawing.Size(83, 30);
            this.chkConnectar.SolidStyle = false;
            this.chkConnectar.TabIndex = 2;
            this.chkConnectar.UseVisualStyleBackColor = false;
            // 
            // chkInici
            // 
            this.chkInici.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInici.AutoCheck = false;
            this.chkInici.BackColor = System.Drawing.Color.Transparent;
            this.chkInici.Location = new System.Drawing.Point(682, 26);
            this.chkInici.MinimumSize = new System.Drawing.Size(45, 22);
            this.chkInici.Name = "chkInici";
            this.chkInici.OffBackColor = System.Drawing.Color.DarkGray;
            this.chkInici.OffToggleColor = System.Drawing.Color.Red;
            this.chkInici.OnBackColor = System.Drawing.Color.Teal;
            this.chkInici.OnToggleColor = System.Drawing.Color.Lime;
            this.chkInici.Size = new System.Drawing.Size(83, 30);
            this.chkInici.SolidStyle = false;
            this.chkInici.TabIndex = 3;
            this.chkInici.UseVisualStyleBackColor = false;
            // 
            // btAdquirir
            // 
            this.btAdquirir.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btAdquirir.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.btAdquirir.BorderColor = System.Drawing.Color.DimGray;
            this.btAdquirir.BorderRadius = 15;
            this.btAdquirir.BorderSize = 1;
            this.btAdquirir.FlatAppearance.BorderSize = 0;
            this.btAdquirir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdquirir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdquirir.ForeColor = System.Drawing.Color.Black;
            this.btAdquirir.Location = new System.Drawing.Point(334, 544);
            this.btAdquirir.Name = "btAdquirir";
            this.btAdquirir.Size = new System.Drawing.Size(126, 34);
            this.btAdquirir.TabIndex = 4;
            this.btAdquirir.Text = "Adquirir";
            this.btAdquirir.TextColor = System.Drawing.Color.Black;
            this.btAdquirir.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.BackgroundImage = global::Poker.Properties.Resources.greenLeatherBkg;
            this.ClientSize = new System.Drawing.Size(791, 636);
            this.Controls.Add(this.btAdquirir);
            this.Controls.Add(this.btEnviar);
            this.Controls.Add(this.lbConnectar);
            this.Controls.Add(this.chkConnectar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkInici);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkAutoscroll);
            this.Controls.Add(this.lbCartaEntra);
            this.Controls.Add(this.lbCarta1);
            this.Controls.Add(this.lbCarta2);
            this.Controls.Add(this.lbCarta3);
            this.Controls.Add(this.lbCarta4);
            this.Controls.Add(this.lbCarta5);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lbMissatges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.tbLocalHost);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Poker";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbLocalHost;
        public System.Windows.Forms.TextBox tbNom;
        public System.Windows.Forms.ListBox lbMissatges;
        public System.Windows.Forms.TextBox tbMessage;
        public System.Windows.Forms.Label lbCarta1;
        public System.Windows.Forms.Label lbCarta2;
        public System.Windows.Forms.Label lbCarta3;
        public System.Windows.Forms.Label lbCarta4;
        public System.Windows.Forms.Label lbCarta5;
        public System.Windows.Forms.Label lbCartaEntra;
        public System.Windows.Forms.CheckBox chkAutoscroll;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Poker.RJControls.RJToggleButton chkInici;
        private System.Windows.Forms.Label label3;
        public Poker.RJControls.RJToggleButton chkConnectar;
        public System.Windows.Forms.Label lbConnectar;
        public Poker.RJControls.RJButton btEnviar;
        public Poker.RJControls.RJButton btAdquirir;
    }
}

