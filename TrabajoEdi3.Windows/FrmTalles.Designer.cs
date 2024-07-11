namespace TrabajoEdi3.Windows
{
    partial class FrmTalles
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbOrden = new ToolStripDropDownButton();
            aZToolStripMenuItem = new ToolStripMenuItem();
            zAToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator3 = new ToolStripSeparator();
            tsbCerrar = new ToolStripButton();
            dgvDatos = new DataGridView();
            colTalle = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            CantidadTallesLbl = new Label();
            label2 = new Label();
            CantidadPaginasLbl = new Label();
            label3 = new Label();
            PaginaActualLbl = new Label();
            label1 = new Label();
            btnUltimo = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, tsbEditar, toolStripSeparator1, tsbOrden, toolStripSeparator2, toolStripSeparator3, tsbCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(692, 57);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNuevo.Image = Properties.Resources.NewPichon;
            tsbNuevo.ImageScaling = ToolStripItemImageScaling.None;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(54, 54);
            tsbNuevo.Text = "Nuevo";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbBorrar
            // 
            tsbBorrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbBorrar.Image = Properties.Resources.BorrarPichon;
            tsbBorrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBorrar.ImageTransparentColor = Color.Magenta;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(54, 54);
            tsbBorrar.Text = "Borrar";
            tsbBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBorrar.Click += tsbBorrar_Click;
            // 
            // tsbEditar
            // 
            tsbEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEditar.Image = Properties.Resources.Edit;
            tsbEditar.ImageScaling = ToolStripItemImageScaling.None;
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(54, 54);
            tsbEditar.Text = "Editar";
            tsbEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbEditar.Click += tsbEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 57);
            // 
            // tsbOrden
            // 
            tsbOrden.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbOrden.DropDownItems.AddRange(new ToolStripItem[] { aZToolStripMenuItem, zAToolStripMenuItem });
            tsbOrden.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_115948;
            tsbOrden.ImageScaling = ToolStripItemImageScaling.None;
            tsbOrden.ImageTransparentColor = Color.Magenta;
            tsbOrden.Name = "tsbOrden";
            tsbOrden.Size = new Size(63, 54);
            tsbOrden.Text = "Orden";
            tsbOrden.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbOrden.Click += tsbOrden_Click;
            // 
            // aZToolStripMenuItem
            // 
            aZToolStripMenuItem.Name = "aZToolStripMenuItem";
            aZToolStripMenuItem.Size = new Size(180, 22);
            aZToolStripMenuItem.Text = "A-Z";
            aZToolStripMenuItem.Click += aZToolStripMenuItem_Click;
            // 
            // zAToolStripMenuItem
            // 
            zAToolStripMenuItem.Name = "zAToolStripMenuItem";
            zAToolStripMenuItem.Size = new Size(180, 22);
            zAToolStripMenuItem.Text = "Z-A";
            zAToolStripMenuItem.Click += zAToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 57);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 57);
            // 
            // tsbCerrar
            // 
            tsbCerrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbCerrar.Image = Properties.Resources.Cancel;
            tsbCerrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbCerrar.ImageTransparentColor = Color.Magenta;
            tsbCerrar.Name = "tsbCerrar";
            tsbCerrar.Size = new Size(54, 54);
            tsbCerrar.Text = "Salir";
            tsbCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbCerrar.Click += tsbCerrar_Click;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(224, 224, 224);
            dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colTalle });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 57);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(692, 314);
            dgvDatos.TabIndex = 2;
            dgvDatos.CellContentClick += dgvDatos_CellContentClick;
            // 
            // colTalle
            // 
            colTalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTalle.HeaderText = "Talles";
            colTalle.Name = "colTalle";
            colTalle.ReadOnly = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 57);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(CantidadTallesLbl);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(CantidadPaginasLbl);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(PaginaActualLbl);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(btnUltimo);
            splitContainer1.Panel2.Controls.Add(btnSiguiente);
            splitContainer1.Panel2.Controls.Add(btnAnterior);
            splitContainer1.Panel2.Controls.Add(btnPrimero);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(692, 314);
            splitContainer1.SplitterDistance = 233;
            splitContainer1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(224, 224, 224);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(692, 233);
            dataGridView1.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.HeaderText = "Talles";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // CantidadTallesLbl
            // 
            CantidadTallesLbl.AutoSize = true;
            CantidadTallesLbl.BackColor = SystemColors.ActiveCaptionText;
            CantidadTallesLbl.ForeColor = Color.FromArgb(224, 224, 224);
            CantidadTallesLbl.Location = new Point(633, 29);
            CantidadTallesLbl.Name = "CantidadTallesLbl";
            CantidadTallesLbl.Size = new Size(13, 15);
            CantidadTallesLbl.TabIndex = 17;
            CantidadTallesLbl.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaptionText;
            label2.ForeColor = Color.FromArgb(224, 224, 224);
            label2.Location = new Point(518, 28);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 16;
            label2.Text = "Cantidad de talles:";
            // 
            // CantidadPaginasLbl
            // 
            CantidadPaginasLbl.AutoSize = true;
            CantidadPaginasLbl.BackColor = SystemColors.ActiveCaptionText;
            CantidadPaginasLbl.ForeColor = Color.FromArgb(224, 224, 224);
            CantidadPaginasLbl.Location = new Point(119, 28);
            CantidadPaginasLbl.Name = "CantidadPaginasLbl";
            CantidadPaginasLbl.Size = new Size(19, 15);
            CantidadPaginasLbl.TabIndex = 15;
            CantidadPaginasLbl.Text = "10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaptionText;
            label3.ForeColor = Color.FromArgb(224, 224, 224);
            label3.Location = new Point(93, 28);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 14;
            label3.Text = "de";
            // 
            // PaginaActualLbl
            // 
            PaginaActualLbl.AutoSize = true;
            PaginaActualLbl.BackColor = SystemColors.ActiveCaptionText;
            PaginaActualLbl.ForeColor = Color.FromArgb(224, 224, 224);
            PaginaActualLbl.Location = new Point(74, 28);
            PaginaActualLbl.Name = "PaginaActualLbl";
            PaginaActualLbl.Size = new Size(13, 15);
            PaginaActualLbl.TabIndex = 13;
            PaginaActualLbl.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(28, 27);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 12;
            label1.Text = "Página";
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.Last;
            btnUltimo.Location = new Point(398, 14);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(75, 41);
            btnUltimo.TabIndex = 8;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.Next_page;
            btnSiguiente.Location = new Point(317, 14);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(75, 41);
            btnSiguiente.TabIndex = 9;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.Prev;
            btnAnterior.Location = new Point(236, 14);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 41);
            btnAnterior.TabIndex = 10;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.ForeColor = SystemColors.ActiveCaptionText;
            btnPrimero.Image = Properties.Resources.Previous;
            btnPrimero.Location = new Point(155, 14);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(75, 41);
            btnPrimero.TabIndex = 11;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // FrmTalles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 371);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(dgvDatos);
            Controls.Add(toolStrip1);
            Name = "FrmTalles";
            Text = "FrmTalles";
            Load += FrmTalles_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbBorrar;
        private ToolStripButton tsbEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tsbCerrar;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colTalle;
        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Button btnUltimo;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private Label CantidadTallesLbl;
        private Label label2;
        private Label CantidadPaginasLbl;
        private Label label3;
        private Label PaginaActualLbl;
        private Label label1;
        private ToolStripDropDownButton tsbOrden;
        private ToolStripMenuItem aZToolStripMenuItem;
        private ToolStripMenuItem zAToolStripMenuItem;
    }
}