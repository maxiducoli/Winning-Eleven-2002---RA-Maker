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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lstArchivos = new ListBox();
            dgvVAGs = new DataGridView();
            colPuntero = new DataGridViewTextBoxColumn();
            colpuntero2 = new DataGridViewTextBoxColumn();
            colArchivo = new DataGridViewTextBoxColumn();
            colFrase = new DataGridViewTextBoxColumn();
            colAsignado = new DataGridViewTextBoxColumn();
            colCheckeo = new DataGridViewCheckBoxColumn();
            btnAgregarAudio = new Button();
            btnCrearRA = new Button();
            groupBox1 = new GroupBox();
            lstInformacionWAV = new ListBox();
            btnStop = new Button();
            btnPlay = new Button();
            btnUp = new Button();
            btnDown = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            lstConsola = new ListBox();
            btnProcessData = new Button();
            btnAdd = new Button();
            chkCallnames = new CheckBox();
            PopUp = new ContextMenuStrip(components);
            tsMenuCopiar = new ToolStripMenuItem();
            toolStripComboBox1 = new ToolStripComboBox();
            progressBar1 = new ProgressBar();
            lblContador = new Label();
            lblVAGs = new Label();
            rbNormal = new RadioButton();
            rbCall1 = new RadioButton();
            rbCall3 = new RadioButton();
            btnGuardarListado = new Button();
            btnAbrirlistado = new Button();
            rbAll = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvVAGs).BeginInit();
            groupBox1.SuspendLayout();
            PopUp.SuspendLayout();
            SuspendLayout();
            // 
            // lstArchivos
            // 
            lstArchivos.FormattingEnabled = true;
            lstArchivos.ItemHeight = 15;
            lstArchivos.Location = new Point(18, 59);
            lstArchivos.Name = "lstArchivos";
            lstArchivos.Size = new Size(805, 229);
            lstArchivos.TabIndex = 0;
            lstArchivos.Click += lstArchivos_Click;
            // 
            // dgvVAGs
            // 
            dgvVAGs.AllowUserToAddRows = false;
            dgvVAGs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvVAGs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvVAGs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVAGs.Columns.AddRange(new DataGridViewColumn[] { colPuntero, colpuntero2, colArchivo, colFrase, colAsignado, colCheckeo });
            dgvVAGs.Location = new Point(18, 347);
            dgvVAGs.Name = "dgvVAGs";
            dgvVAGs.RowHeadersVisible = false;
            dgvVAGs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVAGs.Size = new Size(1121, 285);
            dgvVAGs.TabIndex = 1;
            dgvVAGs.CellClick += dgvVAGs_CellClick;
            // 
            // colPuntero
            // 
            colPuntero.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colPuntero.HeaderText = "Offset 1";
            colPuntero.Name = "colPuntero";
            colPuntero.ReadOnly = true;
            colPuntero.Resizable = DataGridViewTriState.False;
            colPuntero.Width = 73;
            // 
            // colpuntero2
            // 
            colpuntero2.HeaderText = "Offset2";
            colpuntero2.Name = "colpuntero2";
            colpuntero2.ReadOnly = true;
            colpuntero2.Resizable = DataGridViewTriState.False;
            // 
            // colArchivo
            // 
            colArchivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colArchivo.HeaderText = "File Name";
            colArchivo.Name = "colArchivo";
            colArchivo.ReadOnly = true;
            colArchivo.Resizable = DataGridViewTriState.False;
            colArchivo.Width = 85;
            // 
            // colFrase
            // 
            colFrase.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFrase.HeaderText = "Descrption";
            colFrase.Name = "colFrase";
            colFrase.Resizable = DataGridViewTriState.False;
            // 
            // colAsignado
            // 
            colAsignado.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colAsignado.HeaderText = "File in RA";
            colAsignado.Name = "colAsignado";
            colAsignado.ReadOnly = true;
            colAsignado.Resizable = DataGridViewTriState.False;
            colAsignado.Width = 81;
            // 
            // colCheckeo
            // 
            colCheckeo.HeaderText = "Check";
            colCheckeo.Name = "colCheckeo";
            colCheckeo.ReadOnly = true;
            colCheckeo.Resizable = DataGridViewTriState.False;
            // 
            // btnAgregarAudio
            // 
            btnAgregarAudio.Enabled = false;
            btnAgregarAudio.Image = Properties.Resources.audio;
            btnAgregarAudio.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregarAudio.Location = new Point(18, 12);
            btnAgregarAudio.Name = "btnAgregarAudio";
            btnAgregarAudio.Size = new Size(123, 40);
            btnAgregarAudio.TabIndex = 2;
            btnAgregarAudio.Text = "Agregar audio";
            btnAgregarAudio.TextAlign = ContentAlignment.MiddleRight;
            btnAgregarAudio.UseVisualStyleBackColor = true;
            btnAgregarAudio.Click += btnAgregarAudio_Click;
            // 
            // btnCrearRA
            // 
            btnCrearRA.Enabled = false;
            btnCrearRA.Location = new Point(1145, 671);
            btnCrearRA.Name = "btnCrearRA";
            btnCrearRA.Size = new Size(75, 61);
            btnCrearRA.TabIndex = 3;
            btnCrearRA.Text = "Create RA";
            btnCrearRA.UseVisualStyleBackColor = true;
            btnCrearRA.Click += btnCrearRA_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Silver;
            groupBox1.Controls.Add(lstInformacionWAV);
            groupBox1.Controls.Add(btnStop);
            groupBox1.Controls.Add(btnPlay);
            groupBox1.Location = new Point(883, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(337, 282);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información del WAV y reproductor";
            // 
            // lstInformacionWAV
            // 
            lstInformacionWAV.BackColor = SystemColors.InfoText;
            lstInformacionWAV.Font = new Font("Segoe UI", 10F);
            lstInformacionWAV.ForeColor = Color.LimeGreen;
            lstInformacionWAV.FormattingEnabled = true;
            lstInformacionWAV.ItemHeight = 17;
            lstInformacionWAV.Location = new Point(12, 22);
            lstInformacionWAV.Name = "lstInformacionWAV";
            lstInformacionWAV.Size = new Size(319, 208);
            lstInformacionWAV.TabIndex = 2;
            // 
            // btnStop
            // 
            btnStop.Image = Properties.Resources.download_icon_pause_play_square_stop_icon_1320185672026264120_32;
            btnStop.Location = new Point(56, 236);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(35, 35);
            btnStop.TabIndex = 1;
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnPlay
            // 
            btnPlay.Image = Properties.Resources.play_icon_134504;
            btnPlay.Location = new Point(15, 236);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(35, 35);
            btnPlay.TabIndex = 0;
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnUp
            // 
            btnUp.Image = Properties.Resources._256371;
            btnUp.Location = new Point(829, 128);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(48, 47);
            btnUp.TabIndex = 5;
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += button1_Click;
            // 
            // btnDown
            // 
            btnDown.Image = Properties.Resources.down;
            btnDown.Location = new Point(829, 181);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(48, 47);
            btnDown.TabIndex = 6;
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += button2_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.Clear1;
            btnDelete.Location = new Point(580, 294);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(48, 47);
            btnDelete.TabIndex = 7;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += button3_Click;
            // 
            // btnClear
            // 
            btnClear.Image = Properties.Resources.clear_261;
            btnClear.Location = new Point(634, 294);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(48, 47);
            btnClear.TabIndex = 10;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lstConsola
            // 
            lstConsola.BackColor = SystemColors.InfoText;
            lstConsola.Font = new Font("Itim", 10F);
            lstConsola.ForeColor = Color.Lime;
            lstConsola.FormattingEnabled = true;
            lstConsola.ItemHeight = 15;
            lstConsola.Location = new Point(18, 638);
            lstConsola.Name = "lstConsola";
            lstConsola.Size = new Size(1121, 94);
            lstConsola.TabIndex = 11;
            // 
            // btnProcessData
            // 
            btnProcessData.Enabled = false;
            btnProcessData.Location = new Point(210, 294);
            btnProcessData.Name = "btnProcessData";
            btnProcessData.Size = new Size(132, 47);
            btnProcessData.TabIndex = 12;
            btnProcessData.Text = "Preparar archivos VAG";
            btnProcessData.UseVisualStyleBackColor = true;
            btnProcessData.Click += button4_Click;
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.add_icon_vector_216797802;
            btnAdd.Location = new Point(526, 294);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(48, 47);
            btnAdd.TabIndex = 13;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // chkCallnames
            // 
            chkCallnames.AutoSize = true;
            chkCallnames.Enabled = false;
            chkCallnames.Location = new Point(1145, 646);
            chkCallnames.Name = "chkCallnames";
            chkCallnames.Size = new Size(84, 19);
            chkCallnames.TabIndex = 14;
            chkCallnames.Text = "Call names";
            chkCallnames.UseVisualStyleBackColor = true;
            chkCallnames.Visible = false;
            // 
            // PopUp
            // 
            PopUp.Items.AddRange(new ToolStripItem[] { tsMenuCopiar, toolStripComboBox1 });
            PopUp.Name = "PopUp";
            PopUp.Size = new Size(241, 53);
            PopUp.TabStop = true;
            PopUp.Opening += contextMenuStrip1_Opening;
            // 
            // tsMenuCopiar
            // 
            tsMenuCopiar.Name = "tsMenuCopiar";
            tsMenuCopiar.Size = new Size(240, 22);
            tsMenuCopiar.Text = "Copy description";
            tsMenuCopiar.Click += tsMenuCopiar_Click;
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Items.AddRange(new object[] { "FakeYou - Mariano Closs (Full Version)", "FakeYou - Christian Martinolli", "FakeYou - Julio Palma", "FakeYou - Rodolfo De Paoli" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(180, 23);
            toolStripComboBox1.Text = "Relatores FakeYou";
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
            toolStripComboBox1.Click += toolStripComboBox1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(348, 318);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(159, 23);
            progressBar1.TabIndex = 15;
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(18, 291);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(124, 15);
            lblContador.TabIndex = 16;
            lblContador.Text = "Cantidad de archivos: ";
            // 
            // lblVAGs
            // 
            lblVAGs.AutoSize = true;
            lblVAGs.Location = new Point(18, 329);
            lblVAGs.Name = "lblVAGs";
            lblVAGs.Size = new Size(137, 15);
            lblVAGs.TabIndex = 17;
            lblVAGs.Text = "Cantidad de VAGs reales:";
            // 
            // rbNormal
            // 
            rbNormal.AutoSize = true;
            rbNormal.Location = new Point(147, 23);
            rbNormal.Name = "rbNormal";
            rbNormal.Size = new Size(141, 19);
            rbNormal.TabIndex = 18;
            rbNormal.TabStop = true;
            rbNormal.Text = "Relatos y comentarios";
            rbNormal.UseVisualStyleBackColor = true;
            rbNormal.CheckedChanged += rbNormal_CheckedChanged;
            // 
            // rbCall1
            // 
            rbCall1.AutoSize = true;
            rbCall1.Location = new Point(358, 23);
            rbCall1.Name = "rbCall1";
            rbCall1.Size = new Size(119, 19);
            rbCall1.TabIndex = 19;
            rbCall1.TabStop = true;
            rbCall1.Text = "Call name normal";
            rbCall1.UseVisualStyleBackColor = true;
            rbCall1.CheckedChanged += rbCall1_CheckedChanged;
            // 
            // rbCall3
            // 
            rbCall3.AutoSize = true;
            rbCall3.Location = new Point(548, 23);
            rbCall3.Name = "rbCall3";
            rbCall3.Size = new Size(120, 19);
            rbCall3.TabIndex = 20;
            rbCall3.TabStop = true;
            rbCall3.Text = "Call name exitado";
            rbCall3.UseVisualStyleBackColor = true;
            rbCall3.CheckedChanged += rbCall3_CheckedChanged;
            // 
            // btnGuardarListado
            // 
            btnGuardarListado.Image = Properties.Resources.guardar32x32;
            btnGuardarListado.Location = new Point(775, 294);
            btnGuardarListado.Name = "btnGuardarListado";
            btnGuardarListado.Size = new Size(48, 47);
            btnGuardarListado.TabIndex = 21;
            btnGuardarListado.UseVisualStyleBackColor = true;
            btnGuardarListado.Click += button1_Click_1;
            // 
            // btnAbrirlistado
            // 
            btnAbrirlistado.Image = Properties.Resources.abrir;
            btnAbrirlistado.Location = new Point(721, 294);
            btnAbrirlistado.Name = "btnAbrirlistado";
            btnAbrirlistado.Size = new Size(48, 47);
            btnAbrirlistado.TabIndex = 22;
            btnAbrirlistado.UseVisualStyleBackColor = true;
            btnAbrirlistado.Click += btnAbrirlistado_Click;
            // 
            // rbAll
            // 
            rbAll.AutoSize = true;
            rbAll.Location = new Point(721, 23);
            rbAll.Name = "rbAll";
            rbAll.Size = new Size(120, 19);
            rbAll.TabIndex = 23;
            rbAll.TabStop = true;
            rbAll.Text = "Call name exitado";
            rbAll.UseVisualStyleBackColor = true;
            rbAll.CheckedChanged += rbAll_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 743);
            Controls.Add(rbAll);
            Controls.Add(btnAbrirlistado);
            Controls.Add(btnGuardarListado);
            Controls.Add(rbCall3);
            Controls.Add(rbCall1);
            Controls.Add(rbNormal);
            Controls.Add(lblVAGs);
            Controls.Add(lblContador);
            Controls.Add(progressBar1);
            Controls.Add(chkCallnames);
            Controls.Add(btnAdd);
            Controls.Add(btnProcessData);
            Controls.Add(lstConsola);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(groupBox1);
            Controls.Add(btnCrearRA);
            Controls.Add(btnAgregarAudio);
            Controls.Add(dgvVAGs);
            Controls.Add(lstArchivos);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Winning Eleven 2002 - RA Maker -= By CARP =-";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvVAGs).EndInit();
            groupBox1.ResumeLayout(false);
            PopUp.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstArchivos;
        private DataGridView dgvVAGs;
        private Button btnAgregarAudio;
        private Button btnCrearRA;
        private GroupBox groupBox1;
        private Button btnStop;
        private Button btnPlay;
        private Button btnUp;
        private Button btnDown;
        private Button btnDelete;
        private Button btnClear;
        private ListBox lstConsola;
        private Button btnProcessData;
        private ListBox lstInformacionWAV;
        private Button btnAdd;
        private CheckBox chkCallnames;
        private ContextMenuStrip PopUp;
        private ToolStripMenuItem tsMenuCopiar;
        private ToolStripComboBox toolStripComboBox1;
        private ProgressBar progressBar1;
        private Label lblContador;
        private Label lblVAGs;
        private RadioButton rbNormal;
        private RadioButton rbCall1;
        private RadioButton rbCall3;
        private Button btnGuardarListado;
        private Button btnAbrirlistado;
        private DataGridViewTextBoxColumn colPuntero;
        private DataGridViewTextBoxColumn colpuntero2;
        private DataGridViewTextBoxColumn colArchivo;
        private DataGridViewTextBoxColumn colFrase;
        private DataGridViewTextBoxColumn colAsignado;
        private DataGridViewCheckBoxColumn colCheckeo;
        private RadioButton rbAll;
    }
}
