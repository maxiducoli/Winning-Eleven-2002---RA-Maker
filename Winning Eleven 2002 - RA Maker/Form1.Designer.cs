namespace Winning_Eleven_2002___RA_Maker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lstArchivos = new ListBox();
            dgvVAGs = new DataGridView();
            colPuntero = new DataGridViewTextBoxColumn();
            colArchivo = new DataGridViewTextBoxColumn();
            colFrase = new DataGridViewTextBoxColumn();
            colAsignado = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colCheckeo = new DataGridViewCheckBoxColumn();
            btnAgregarAudio = new Button();
            btnCrearRA = new Button();
            groupBox1 = new GroupBox();
            button7 = new Button();
            button6 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button8 = new Button();
            listBox1 = new ListBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVAGs).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lstArchivos
            // 
            lstArchivos.FormattingEnabled = true;
            lstArchivos.ItemHeight = 15;
            lstArchivos.Location = new Point(18, 41);
            lstArchivos.Name = "lstArchivos";
            lstArchivos.Size = new Size(889, 229);
            lstArchivos.TabIndex = 0;
            // 
            // dgvVAGs
            // 
            dgvVAGs.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvVAGs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVAGs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVAGs.Columns.AddRange(new DataGridViewColumn[] { colPuntero, colArchivo, colFrase, colAsignado, colEstado, colCheckeo });
            dgvVAGs.Location = new Point(18, 305);
            dgvVAGs.Name = "dgvVAGs";
            dgvVAGs.RowHeadersVisible = false;
            dgvVAGs.Size = new Size(1202, 298);
            dgvVAGs.TabIndex = 1;
            // 
            // colPuntero
            // 
            colPuntero.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colPuntero.HeaderText = "Offset puntero";
            colPuntero.Name = "colPuntero";
            colPuntero.ReadOnly = true;
            colPuntero.Resizable = DataGridViewTriState.False;
            colPuntero.Width = 109;
            // 
            // colArchivo
            // 
            colArchivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colArchivo.HeaderText = "Nombre Archivo";
            colArchivo.Name = "colArchivo";
            colArchivo.ReadOnly = true;
            colArchivo.Resizable = DataGridViewTriState.False;
            colArchivo.Width = 120;
            // 
            // colFrase
            // 
            colFrase.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFrase.HeaderText = "Texto de la frase";
            colFrase.Name = "colFrase";
            colFrase.Resizable = DataGridViewTriState.False;
            // 
            // colAsignado
            // 
            colAsignado.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colAsignado.HeaderText = "ArchivoAsignado";
            colAsignado.Name = "colAsignado";
            colAsignado.ReadOnly = true;
            colAsignado.Resizable = DataGridViewTriState.False;
            colAsignado.Width = 123;
            // 
            // colEstado
            // 
            colEstado.HeaderText = "Estado";
            colEstado.MaxInputLength = 2;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            colEstado.Resizable = DataGridViewTriState.False;
            // 
            // colCheckeo
            // 
            colCheckeo.HeaderText = "Check";
            colCheckeo.Name = "colCheckeo";
            colCheckeo.ReadOnly = true;
            colCheckeo.Resizable = DataGridViewTriState.False;
            colCheckeo.Visible = false;
            // 
            // btnAgregarAudio
            // 
            btnAgregarAudio.Location = new Point(18, 12);
            btnAgregarAudio.Name = "btnAgregarAudio";
            btnAgregarAudio.Size = new Size(98, 23);
            btnAgregarAudio.TabIndex = 2;
            btnAgregarAudio.Text = "Agregar audio";
            btnAgregarAudio.UseVisualStyleBackColor = true;
            btnAgregarAudio.Click += btnAgregarAudio_Click;
            // 
            // btnCrearRA
            // 
            btnCrearRA.Location = new Point(1105, 680);
            btnCrearRA.Name = "btnCrearRA";
            btnCrearRA.Size = new Size(115, 23);
            btnCrearRA.TabIndex = 3;
            btnCrearRA.Text = "Crear RA";
            btnCrearRA.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(button6);
            groupBox1.Location = new Point(967, 29);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(253, 243);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info del audio";
            // 
            // button7
            // 
            button7.Location = new Point(156, 209);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 1;
            button7.Text = "button7";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(23, 209);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 0;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(913, 41);
            button1.Name = "button1";
            button1.Size = new Size(48, 23);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(913, 70);
            button2.Name = "button2";
            button2.Size = new Size(48, 23);
            button2.TabIndex = 6;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(913, 99);
            button3.Name = "button3";
            button3.Size = new Size(48, 23);
            button3.TabIndex = 7;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button8
            // 
            button8.Location = new Point(913, 128);
            button8.Name = "button8";
            button8.Size = new Size(48, 23);
            button8.TabIndex = 10;
            button8.Text = "button8";
            button8.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.InfoText;
            listBox1.Font = new Font("Itim", 10F);
            listBox1.ForeColor = Color.Lime;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(18, 609);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1081, 94);
            listBox1.TabIndex = 11;
            // 
            // button4
            // 
            button4.Location = new Point(526, 276);
            button4.Name = "button4";
            button4.Size = new Size(115, 23);
            button4.TabIndex = 12;
            button4.Text = "Procesar archivos";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 715);
            Controls.Add(button4);
            Controls.Add(listBox1);
            Controls.Add(button8);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(btnCrearRA);
            Controls.Add(btnAgregarAudio);
            Controls.Add(dgvVAGs);
            Controls.Add(lstArchivos);
            Name = "Form1";
            Text = "Winning Eleven 2002 - RA Maker -= By CARP =-";
            ((System.ComponentModel.ISupportInitialize)dgvVAGs).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstArchivos;
        private DataGridView dgvVAGs;
        private Button btnAgregarAudio;
        private Button btnCrearRA;
        private GroupBox groupBox1;
        private Button button7;
        private Button button6;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button8;
        private ListBox listBox1;
        private Button button4;
        private DataGridViewTextBoxColumn colPuntero;
        private DataGridViewTextBoxColumn colArchivo;
        private DataGridViewTextBoxColumn colFrase;
        private DataGridViewTextBoxColumn colAsignado;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewCheckBoxColumn colCheckeo;
    }
}
