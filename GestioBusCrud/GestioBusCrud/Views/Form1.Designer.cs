
namespace GestioBusCrud.Views
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
            this.tbIdLinia = new System.Windows.Forms.TextBox();
            this.tbNomLinia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btClearLinia = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescLinia = new System.Windows.Forms.TextBox();
            this.btDelLinia = new System.Windows.Forms.Button();
            this.btUpdLinia = new System.Windows.Forms.Button();
            this.btInsLinia = new System.Windows.Forms.Button();
            this.dgvLinies = new System.Windows.Forms.DataGridView();
            this.dgvParades = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvHoraris = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dtPicker1 = new System.Windows.Forms.DateTimePicker();
            this.btInsHora = new System.Windows.Forms.Button();
            this.btUpdHora = new System.Windows.Forms.Button();
            this.btDelHora = new System.Windows.Forms.Button();
            this.btDelParada = new System.Windows.Forms.Button();
            this.btInsParada = new System.Windows.Forms.Button();
            this.tbIdParada = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.coordGrup = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLongitud = new System.Windows.Forms.TextBox();
            this.tbLatitud = new System.Windows.Forms.TextBox();
            this.btLlocs = new System.Windows.Forms.Button();
            this.btClearParada = new System.Windows.Forms.Button();
            this.btUpdParada = new System.Windows.Forms.Button();
            this.tbNomParada = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPosParada = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoraris)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.coordGrup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbIdLinia
            // 
            this.tbIdLinia.Location = new System.Drawing.Point(10, 38);
            this.tbIdLinia.Name = "tbIdLinia";
            this.tbIdLinia.ReadOnly = true;
            this.tbIdLinia.Size = new System.Drawing.Size(74, 21);
            this.tbIdLinia.TabIndex = 1;
            this.tbIdLinia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbNomLinia
            // 
            this.tbNomLinia.Location = new System.Drawing.Point(90, 38);
            this.tbNomLinia.Name = "tbNomLinia";
            this.tbNomLinia.Size = new System.Drawing.Size(244, 21);
            this.tbNomLinia.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("DejaVu Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Línies";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btClearLinia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbDescLinia);
            this.groupBox1.Controls.Add(this.btDelLinia);
            this.groupBox1.Controls.Add(this.btUpdLinia);
            this.groupBox1.Controls.Add(this.btInsLinia);
            this.groupBox1.Controls.Add(this.tbNomLinia);
            this.groupBox1.Controls.Add(this.tbIdLinia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("DejaVu Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 149);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Línia seleccionada";
            // 
            // btClearLinia
            // 
            this.btClearLinia.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClearLinia.Location = new System.Drawing.Point(359, 17);
            this.btClearLinia.Name = "btClearLinia";
            this.btClearLinia.Size = new System.Drawing.Size(112, 25);
            this.btClearLinia.TabIndex = 10;
            this.btClearLinia.Text = "Nova Linia";
            this.btClearLinia.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Descripció";
            // 
            // tbDescLinia
            // 
            this.tbDescLinia.Location = new System.Drawing.Point(10, 94);
            this.tbDescLinia.Name = "tbDescLinia";
            this.tbDescLinia.Size = new System.Drawing.Size(324, 21);
            this.tbDescLinia.TabIndex = 8;
            // 
            // btDelLinia
            // 
            this.btDelLinia.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelLinia.Location = new System.Drawing.Point(359, 111);
            this.btDelLinia.Name = "btDelLinia";
            this.btDelLinia.Size = new System.Drawing.Size(112, 25);
            this.btDelLinia.TabIndex = 7;
            this.btDelLinia.Text = "Esborrar";
            this.btDelLinia.UseVisualStyleBackColor = true;
            // 
            // btUpdLinia
            // 
            this.btUpdLinia.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdLinia.Location = new System.Drawing.Point(359, 80);
            this.btUpdLinia.Name = "btUpdLinia";
            this.btUpdLinia.Size = new System.Drawing.Size(112, 25);
            this.btUpdLinia.TabIndex = 6;
            this.btUpdLinia.Text = "Actualitzar";
            this.btUpdLinia.UseVisualStyleBackColor = true;
            // 
            // btInsLinia
            // 
            this.btInsLinia.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInsLinia.Location = new System.Drawing.Point(359, 49);
            this.btInsLinia.Name = "btInsLinia";
            this.btInsLinia.Size = new System.Drawing.Size(112, 25);
            this.btInsLinia.TabIndex = 5;
            this.btInsLinia.Text = "Afegir";
            this.btInsLinia.UseVisualStyleBackColor = true;
            // 
            // dgvLinies
            // 
            this.dgvLinies.AllowUserToAddRows = false;
            this.dgvLinies.AllowUserToDeleteRows = false;
            this.dgvLinies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLinies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLinies.Location = new System.Drawing.Point(14, 178);
            this.dgvLinies.MultiSelect = false;
            this.dgvLinies.Name = "dgvLinies";
            this.dgvLinies.ReadOnly = true;
            this.dgvLinies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLinies.Size = new System.Drawing.Size(475, 620);
            this.dgvLinies.TabIndex = 7;
            // 
            // dgvParades
            // 
            this.dgvParades.AllowUserToAddRows = false;
            this.dgvParades.AllowUserToDeleteRows = false;
            this.dgvParades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParades.Location = new System.Drawing.Point(508, 178);
            this.dgvParades.MultiSelect = false;
            this.dgvParades.Name = "dgvParades";
            this.dgvParades.ReadOnly = true;
            this.dgvParades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParades.Size = new System.Drawing.Size(675, 314);
            this.dgvParades.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("DejaVu Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(507, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Parades de la línia";
            // 
            // dgvHoraris
            // 
            this.dgvHoraris.AllowUserToAddRows = false;
            this.dgvHoraris.AllowUserToDeleteRows = false;
            this.dgvHoraris.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoraris.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoraris.Location = new System.Drawing.Point(510, 527);
            this.dgvHoraris.MultiSelect = false;
            this.dgvHoraris.Name = "dgvHoraris";
            this.dgvHoraris.ReadOnly = true;
            this.dgvHoraris.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoraris.Size = new System.Drawing.Size(675, 271);
            this.dgvHoraris.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("DejaVu Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(507, 507);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Horaris de la parada";
            // 
            // dtPicker1
            // 
            this.dtPicker1.CustomFormat = "HH:mm";
            this.dtPicker1.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker1.Location = new System.Drawing.Point(683, 497);
            this.dtPicker1.Name = "dtPicker1";
            this.dtPicker1.ShowUpDown = true;
            this.dtPicker1.Size = new System.Drawing.Size(65, 26);
            this.dtPicker1.TabIndex = 12;
            this.dtPicker1.Value = new System.DateTime(2022, 5, 25, 0, 0, 0, 0);
            // 
            // btInsHora
            // 
            this.btInsHora.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInsHora.Location = new System.Drawing.Point(754, 496);
            this.btInsHora.Name = "btInsHora";
            this.btInsHora.Size = new System.Drawing.Size(139, 25);
            this.btInsHora.TabIndex = 11;
            this.btInsHora.Text = "Afegir hora";
            this.btInsHora.UseVisualStyleBackColor = true;
            // 
            // btUpdHora
            // 
            this.btUpdHora.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdHora.Location = new System.Drawing.Point(899, 496);
            this.btUpdHora.Name = "btUpdHora";
            this.btUpdHora.Size = new System.Drawing.Size(139, 25);
            this.btUpdHora.TabIndex = 13;
            this.btUpdHora.Text = "Editar hora";
            this.btUpdHora.UseVisualStyleBackColor = true;
            // 
            // btDelHora
            // 
            this.btDelHora.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelHora.Location = new System.Drawing.Point(1044, 496);
            this.btDelHora.Name = "btDelHora";
            this.btDelHora.Size = new System.Drawing.Size(139, 25);
            this.btDelHora.TabIndex = 14;
            this.btDelHora.Text = "Esborrar hora";
            this.btDelHora.UseVisualStyleBackColor = true;
            // 
            // btDelParada
            // 
            this.btDelParada.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelParada.Location = new System.Drawing.Point(548, 112);
            this.btDelParada.Name = "btDelParada";
            this.btDelParada.Size = new System.Drawing.Size(112, 25);
            this.btDelParada.TabIndex = 7;
            this.btDelParada.Text = "Esborrar";
            this.btDelParada.UseVisualStyleBackColor = true;
            // 
            // btInsParada
            // 
            this.btInsParada.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInsParada.Location = new System.Drawing.Point(548, 45);
            this.btInsParada.Name = "btInsParada";
            this.btInsParada.Size = new System.Drawing.Size(112, 25);
            this.btInsParada.TabIndex = 5;
            this.btInsParada.Text = "Afegir";
            this.btInsParada.UseVisualStyleBackColor = true;
            // 
            // tbIdParada
            // 
            this.tbIdParada.Location = new System.Drawing.Point(10, 38);
            this.tbIdParada.Name = "tbIdParada";
            this.tbIdParada.ReadOnly = true;
            this.tbIdParada.Size = new System.Drawing.Size(74, 21);
            this.tbIdParada.TabIndex = 1;
            this.tbIdParada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Id";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPosParada);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.coordGrup);
            this.groupBox2.Controls.Add(this.btLlocs);
            this.groupBox2.Controls.Add(this.btClearParada);
            this.groupBox2.Controls.Add(this.btDelParada);
            this.groupBox2.Controls.Add(this.btUpdParada);
            this.groupBox2.Controls.Add(this.btInsParada);
            this.groupBox2.Controls.Add(this.tbNomParada);
            this.groupBox2.Controls.Add(this.tbIdParada);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("DejaVu Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(508, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(675, 146);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parada seleccionada";
            // 
            // coordGrup
            // 
            this.coordGrup.Controls.Add(this.label10);
            this.coordGrup.Controls.Add(this.label8);
            this.coordGrup.Controls.Add(this.tbLongitud);
            this.coordGrup.Controls.Add(this.tbLatitud);
            this.coordGrup.Location = new System.Drawing.Point(10, 65);
            this.coordGrup.Name = "coordGrup";
            this.coordGrup.Size = new System.Drawing.Size(330, 75);
            this.coordGrup.TabIndex = 11;
            this.coordGrup.TabStop = false;
            this.coordGrup.Text = "Coordenades de la parada";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 14;
            this.label10.Text = "Longitud:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "Latitud:";
            // 
            // tbLongitud
            // 
            this.tbLongitud.Location = new System.Drawing.Point(80, 47);
            this.tbLongitud.Name = "tbLongitud";
            this.tbLongitud.Size = new System.Drawing.Size(234, 21);
            this.tbLongitud.TabIndex = 13;
            // 
            // tbLatitud
            // 
            this.tbLatitud.Location = new System.Drawing.Point(80, 20);
            this.tbLatitud.Name = "tbLatitud";
            this.tbLatitud.Size = new System.Drawing.Size(234, 21);
            this.tbLatitud.TabIndex = 12;
            // 
            // btLlocs
            // 
            this.btLlocs.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLlocs.Location = new System.Drawing.Point(346, 74);
            this.btLlocs.Name = "btLlocs";
            this.btLlocs.Size = new System.Drawing.Size(196, 63);
            this.btLlocs.TabIndex = 11;
            this.btLlocs.Text = "Afegir lloc d\'interès";
            this.btLlocs.UseVisualStyleBackColor = true;
            // 
            // btClearParada
            // 
            this.btClearParada.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClearParada.Location = new System.Drawing.Point(548, 11);
            this.btClearParada.Name = "btClearParada";
            this.btClearParada.Size = new System.Drawing.Size(113, 25);
            this.btClearParada.TabIndex = 10;
            this.btClearParada.Text = "Nova Parada";
            this.btClearParada.UseVisualStyleBackColor = true;
            // 
            // btUpdParada
            // 
            this.btUpdParada.Font = new System.Drawing.Font("DejaVu Sans Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdParada.Location = new System.Drawing.Point(548, 79);
            this.btUpdParada.Name = "btUpdParada";
            this.btUpdParada.Size = new System.Drawing.Size(112, 25);
            this.btUpdParada.TabIndex = 6;
            this.btUpdParada.Text = "Actualitzar";
            this.btUpdParada.UseVisualStyleBackColor = true;
            // 
            // tbNomParada
            // 
            this.tbNomParada.Location = new System.Drawing.Point(188, 39);
            this.tbNomParada.Name = "tbNomParada";
            this.tbNomParada.Size = new System.Drawing.Size(354, 21);
            this.tbNomParada.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(187, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 14);
            this.label9.TabIndex = 4;
            this.label9.Text = "Nom";
            // 
            // tbPosParada
            // 
            this.tbPosParada.Location = new System.Drawing.Point(88, 39);
            this.tbPosParada.Name = "tbPosParada";
            this.tbPosParada.Size = new System.Drawing.Size(94, 21);
            this.tbPosParada.TabIndex = 12;
            this.tbPosParada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(87, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 13;
            this.label11.Text = "#Pos.rel.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 811);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btDelHora);
            this.Controls.Add(this.btUpdHora);
            this.Controls.Add(this.btInsHora);
            this.Controls.Add(this.dtPicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvHoraris);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvParades);
            this.Controls.Add(this.dgvLinies);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("DejaVu Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "GestioBus - Gestor de la Base de dades";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoraris)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.coordGrup.ResumeLayout(false);
            this.coordGrup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbIdLinia;
        public System.Windows.Forms.TextBox tbNomLinia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView dgvLinies;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbDescLinia;
        public System.Windows.Forms.Button btClearLinia;
        public System.Windows.Forms.Button btInsLinia;
        public System.Windows.Forms.Button btUpdLinia;
        public System.Windows.Forms.Button btDelLinia;
        public System.Windows.Forms.DataGridView dgvParades;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView dgvHoraris;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtPicker1;
        public System.Windows.Forms.Button btInsHora;
        public System.Windows.Forms.Button btUpdHora;
        public System.Windows.Forms.Button btDelHora;
        public System.Windows.Forms.Button btDelParada;
        public System.Windows.Forms.Button btInsParada;
        public System.Windows.Forms.TextBox tbIdParada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btClearParada;
        public System.Windows.Forms.Button btUpdParada;
        public System.Windows.Forms.TextBox tbNomParada;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox coordGrup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox tbLongitud;
        public System.Windows.Forms.TextBox tbLatitud;
        public System.Windows.Forms.Button btLlocs;
        public System.Windows.Forms.TextBox tbPosParada;
        private System.Windows.Forms.Label label11;
    }
}

