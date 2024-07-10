namespace TrabajoEdi3.Windows
{
    partial class FrmZapatillasPorMarca
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            dgvConsulta = new DataGridView();
            btnUltimo = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            btnSalir = new Button();
            colMarca = new DataGridViewTextBoxColumn();
            colDeporte = new DataGridViewTextBoxColumn();
            colGenero = new DataGridViewTextBoxColumn();
            colColor = new DataGridViewTextBoxColumn();
            colModelo = new DataGridViewTextBoxColumn();
            colDescrip = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsulta).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvConsulta);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnUltimo);
            splitContainer1.Panel2.Controls.Add(btnSiguiente);
            splitContainer1.Panel2.Controls.Add(btnAnterior);
            splitContainer1.Panel2.Controls.Add(btnPrimero);
            splitContainer1.Panel2.Controls.Add(btnSalir);
            splitContainer1.Size = new Size(756, 397);
            splitContainer1.SplitterDistance = 311;
            splitContainer1.TabIndex = 0;
            // 
            // dgvConsulta
            // 
            dgvConsulta.AllowUserToAddRows = false;
            dgvConsulta.AllowUserToDeleteRows = false;
            dgvConsulta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsulta.Columns.AddRange(new DataGridViewColumn[] { colMarca, colDeporte, colGenero, colColor, colModelo, colDescrip, colPrecio });
            dgvConsulta.Dock = DockStyle.Fill;
            dgvConsulta.Location = new Point(0, 0);
            dgvConsulta.Name = "dgvConsulta";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvConsulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvConsulta.Size = new Size(756, 311);
            dgvConsulta.TabIndex = 1;
            dgvConsulta.CellContentClick += dgvConsulta_CellContentClick;
            // 
            // btnUltimo
            // 
            btnUltimo.Location = new Point(321, 22);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(75, 41);
            btnUltimo.TabIndex = 1;
            btnUltimo.Text = "Último";
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(230, 19);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(75, 41);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(137, 19);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 41);
            btnAnterior.TabIndex = 3;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.Location = new Point(45, 19);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(75, 41);
            btnPrimero.TabIndex = 4;
            btnPrimero.Text = "Primero";
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(636, 22);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 41);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // colMarca
            // 
            colMarca.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMarca.HeaderText = "Marca";
            colMarca.Name = "colMarca";
            // 
            // colDeporte
            // 
            colDeporte.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDeporte.HeaderText = "Deporte";
            colDeporte.Name = "colDeporte";
            // 
            // colGenero
            // 
            colGenero.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGenero.HeaderText = "Genero";
            colGenero.Name = "colGenero";
            // 
            // colColor
            // 
            colColor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colColor.HeaderText = "Color";
            colColor.Name = "colColor";
            // 
            // colModelo
            // 
            colModelo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colModelo.HeaderText = "Modelo";
            colModelo.Name = "colModelo";
            // 
            // colDescrip
            // 
            colDescrip.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescrip.HeaderText = "Descripcion";
            colDescrip.Name = "colDescrip";
            // 
            // colPrecio
            // 
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrecio.HeaderText = "Precio";
            colPrecio.Name = "colPrecio";
            // 
            // FrmZapatillasPorMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 397);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Name = "FrmZapatillasPorMarca";
            Text = "FrmZapatillasPorMarca";
            Load += FrmZapatillasPorGenero_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConsulta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvConsulta;
        private Button btnUltimo;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private Button btnSalir;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewTextBoxColumn colDeporte;
        private DataGridViewTextBoxColumn colGenero;
        private DataGridViewTextBoxColumn colColor;
        private DataGridViewTextBoxColumn colModelo;
        private DataGridViewTextBoxColumn colDescrip;
        private DataGridViewTextBoxColumn colPrecio;
    }
}