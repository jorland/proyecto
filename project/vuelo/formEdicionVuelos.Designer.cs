namespace project
{
    partial class formEdicionVuelos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEdicionVuelos));
            this.label8 = new System.Windows.Forms.Label();
            this.buscarVuelo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btBuscarVuelo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaVuelos = new System.Windows.Forms.DataGridView();
            this.IngresarVuelo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAvion = new System.Windows.Forms.ComboBox();
            this.txtIdVuelo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.cbOrigenVuelo = new System.Windows.Forms.ComboBox();
            this.cbFecha = new System.Windows.Forms.DateTimePicker();
            this.cbDestinoVuelo = new System.Windows.Forms.ComboBox();
            this.txtMillasVuelo = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.cbHora = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaVuelos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 26);
            this.label8.TabIndex = 24;
            this.label8.Text = "Busqueda del vuelo";
            // 
            // buscarVuelo
            // 
            this.buscarVuelo.AutoSize = true;
            this.buscarVuelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarVuelo.Location = new System.Drawing.Point(36, 96);
            this.buscarVuelo.Name = "buscarVuelo";
            this.buscarVuelo.Size = new System.Drawing.Size(137, 16);
            this.buscarVuelo.TabIndex = 25;
            this.buscarVuelo.Text = "Nombre del Vuelo:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(179, 94);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(230, 20);
            this.txtBuscar.TabIndex = 9;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btBuscarVuelo
            // 
            this.btBuscarVuelo.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarVuelo.Image")));
            this.btBuscarVuelo.Location = new System.Drawing.Point(425, 81);
            this.btBuscarVuelo.Name = "btBuscarVuelo";
            this.btBuscarVuelo.Size = new System.Drawing.Size(46, 45);
            this.btBuscarVuelo.TabIndex = 10;
            this.btBuscarVuelo.UseVisualStyleBackColor = true;
            this.btBuscarVuelo.Click += new System.EventHandler(this.btBuscarVuelo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaVuelos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 214);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Vuelos";
            // 
            // listaVuelos
            // 
            this.listaVuelos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.listaVuelos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.listaVuelos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaVuelos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.listaVuelos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.listaVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaVuelos.Location = new System.Drawing.Point(18, 30);
            this.listaVuelos.Name = "listaVuelos";
            this.listaVuelos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.listaVuelos.Size = new System.Drawing.Size(439, 172);
            this.listaVuelos.TabIndex = 11;
            // 
            // IngresarVuelo
            // 
            this.IngresarVuelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IngresarVuelo.Image = ((System.Drawing.Image)(resources.GetObject("IngresarVuelo.Image")));
            this.IngresarVuelo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IngresarVuelo.Location = new System.Drawing.Point(155, 350);
            this.IngresarVuelo.Name = "IngresarVuelo";
            this.IngresarVuelo.Size = new System.Drawing.Size(152, 45);
            this.IngresarVuelo.TabIndex = 12;
            this.IngresarVuelo.Text = "Ingresar Vuelo";
            this.IngresarVuelo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IngresarVuelo.UseVisualStyleBackColor = true;
            this.IngresarVuelo.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Origen del Vuelo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 26);
            this.label4.TabIndex = 24;
            this.label4.Text = "Nuevos Vuelos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Destino del Vuelo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(37, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Avion :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Millas del Vuelo:";
            // 
            // cbAvion
            // 
            this.cbAvion.FormattingEnabled = true;
            this.cbAvion.Location = new System.Drawing.Point(180, 290);
            this.cbAvion.Name = "cbAvion";
            this.cbAvion.Size = new System.Drawing.Size(121, 21);
            this.cbAvion.TabIndex = 7;
            // 
            // txtIdVuelo
            // 
            this.txtIdVuelo.Location = new System.Drawing.Point(181, 109);
            this.txtIdVuelo.Name = "txtIdVuelo";
            this.txtIdVuelo.Size = new System.Drawing.Size(120, 20);
            this.txtIdVuelo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Fecha del Vuelo:";
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(37, 112);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(71, 16);
            this.id.TabIndex = 28;
            this.id.Text = "ID Vuelo:";
            // 
            // cbOrigenVuelo
            // 
            this.cbOrigenVuelo.FormattingEnabled = true;
            this.cbOrigenVuelo.Location = new System.Drawing.Point(181, 199);
            this.cbOrigenVuelo.Name = "cbOrigenVuelo";
            this.cbOrigenVuelo.Size = new System.Drawing.Size(121, 21);
            this.cbOrigenVuelo.TabIndex = 4;
            // 
            // cbFecha
            // 
            this.cbFecha.Location = new System.Drawing.Point(180, 137);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(120, 20);
            this.cbFecha.TabIndex = 2;
            // 
            // cbDestinoVuelo
            // 
            this.cbDestinoVuelo.FormattingEnabled = true;
            this.cbDestinoVuelo.Location = new System.Drawing.Point(180, 232);
            this.cbDestinoVuelo.Name = "cbDestinoVuelo";
            this.cbDestinoVuelo.Size = new System.Drawing.Size(121, 21);
            this.cbDestinoVuelo.TabIndex = 5;
            // 
            // txtMillasVuelo
            // 
            this.txtMillasVuelo.Location = new System.Drawing.Point(180, 264);
            this.txtMillasVuelo.Name = "txtMillasVuelo";
            this.txtMillasVuelo.Size = new System.Drawing.Size(120, 20);
            this.txtMillasVuelo.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(32, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 45);
            this.button2.TabIndex = 13;
            this.button2.Text = "Volver";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtPrecio);
            this.panel1.Controls.Add(this.cbHora);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txtMillasVuelo);
            this.panel1.Controls.Add(this.cbAvion);
            this.panel1.Controls.Add(this.cbDestinoVuelo);
            this.panel1.Controls.Add(this.IngresarVuelo);
            this.panel1.Controls.Add(this.cbFecha);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbOrigenVuelo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.id);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtIdVuelo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 405);
            this.panel1.TabIndex = 32;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(180, 322);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(120, 20);
            this.txtPrecio.TabIndex = 8;
            // 
            // cbHora
            // 
            this.cbHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.cbHora.Location = new System.Drawing.Point(180, 170);
            this.cbHora.Name = "cbHora";
            this.cbHora.Size = new System.Drawing.Size(120, 20);
            this.cbHora.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Hora :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(159, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 101);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Precio Dolares :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btBuscarVuelo);
            this.panel2.Controls.Add(this.txtBuscar);
            this.panel2.Controls.Add(this.buscarVuelo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 405);
            this.panel2.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(15, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(346, 414);
            this.panel3.TabIndex = 34;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Location = new System.Drawing.Point(388, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(534, 414);
            this.panel4.TabIndex = 35;
            // 
            // formEdicionVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(934, 474);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formEdicionVuelos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de Vuelos";
            this.Load += new System.EventHandler(this.formEdicionVuelos_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaVuelos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label buscarVuelo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btBuscarVuelo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView listaVuelos;
        private System.Windows.Forms.Button IngresarVuelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAvion;
        private System.Windows.Forms.TextBox txtIdVuelo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.ComboBox cbOrigenVuelo;
        private System.Windows.Forms.DateTimePicker cbFecha;
        private System.Windows.Forms.ComboBox cbDestinoVuelo;
        private System.Windows.Forms.TextBox txtMillasVuelo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker cbHora;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;

    }
}