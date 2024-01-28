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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lstArchivos = new ListBox();
            dgvVAGs = new DataGridView();
            colPuntero = new DataGridViewTextBoxColumn();
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
            listBox1 = new ListBox();
            bnProcessData = new Button();
            btnAdd = new Button();
            chkCallnames = new CheckBox();
            PopUp = new ContextMenuStrip(components);
            tsMenuCopiar = new ToolStripMenuItem();
            toolStripComboBox1 = new ToolStripComboBox();
            progressBar1 = new ProgressBar();
            lblContador = new Label();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvVAGs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVAGs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVAGs.Columns.AddRange(new DataGridViewColumn[] { colPuntero, colArchivo, colFrase, colAsignado, colCheckeo });
            dgvVAGs.Location = new Point(18, 347);
            dgvVAGs.Name = "dgvVAGs";
            dgvVAGs.RowHeadersVisible = false;
            dgvVAGs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVAGs.Size = new Size(1202, 285);
            dgvVAGs.TabIndex = 1;
            dgvVAGs.CellClick += dgvVAGs_CellClick;
            // 
            // colPuntero
            // 
            colPuntero.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colPuntero.HeaderText = "Offset";
            colPuntero.Name = "colPuntero";
            colPuntero.ReadOnly = true;
            colPuntero.Resizable = DataGridViewTriState.False;
            colPuntero.Width = 64;
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
            btnAgregarAudio.Image = Properties.Resources.audio;
            btnAgregarAudio.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregarAudio.Location = new Point(18, 12);
            btnAgregarAudio.Name = "btnAgregarAudio";
            btnAgregarAudio.Size = new Size(104, 40);
            btnAgregarAudio.TabIndex = 2;
            btnAgregarAudio.Text = "Add audio";
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
            groupBox1.Text = "Audio Info and player";
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
            btnDelete.Location = new Point(721, 294);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(48, 47);
            btnDelete.TabIndex = 7;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += button3_Click;
            // 
            // btnClear
            // 
            btnClear.Image = Properties.Resources.clear_261;
            btnClear.Location = new Point(775, 294);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(48, 47);
            btnClear.TabIndex = 10;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.InfoText;
            listBox1.Font = new Font("Itim", 10F);
            listBox1.ForeColor = Color.Lime;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(18, 638);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1121, 94);
            listBox1.TabIndex = 11;
            // 
            // bnProcessData
            // 
            bnProcessData.Location = new Point(339, 294);
            bnProcessData.Name = "bnProcessData";
            bnProcessData.Size = new Size(115, 47);
            bnProcessData.TabIndex = 12;
            bnProcessData.Text = "Process files";
            bnProcessData.UseVisualStyleBackColor = true;
            bnProcessData.Click += button4_Click;
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.add_icon_vector_216797802;
            btnAdd.Location = new Point(667, 294);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(48, 47);
            btnAdd.TabIndex = 13;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // chkCallnames
            // 
            chkCallnames.AutoSize = true;
            chkCallnames.Location = new Point(1145, 646);
            chkCallnames.Name = "chkCallnames";
            chkCallnames.Size = new Size(83, 19);
            chkCallnames.TabIndex = 14;
            chkCallnames.Text = "CallNames";
            chkCallnames.UseVisualStyleBackColor = true;
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
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(460, 318);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(159, 23);
            progressBar1.TabIndex = 15;
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(724, 41);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(75, 15);
            lblContador.TabIndex = 16;
            lblContador.Text = "Files counts: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 744);
            Controls.Add(lblContador);
            Controls.Add(progressBar1);
            Controls.Add(chkCallnames);
            Controls.Add(btnAdd);
            Controls.Add(bnProcessData);
            Controls.Add(listBox1);
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
        private ListBox listBox1;
        private Button bnProcessData;
        private ListBox lstInformacionWAV;
        private Button btnAdd;
        private CheckBox chkCallnames;
        private ContextMenuStrip PopUp;
        private ToolStripMenuItem tsMenuCopiar;
        private ToolStripComboBox toolStripComboBox1;
        private ProgressBar progressBar1;
        private DataGridViewTextBoxColumn colPuntero;
        private DataGridViewTextBoxColumn colArchivo;
        private DataGridViewTextBoxColumn colFrase;
        private DataGridViewTextBoxColumn colAsignado;
        private DataGridViewCheckBoxColumn colCheckeo;
        private Label lblContador;
    }
}
