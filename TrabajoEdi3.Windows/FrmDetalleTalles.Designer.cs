namespace TrabajoEdi3.Windows
{
    partial class FrmDetalleTalles
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
            toolStrip1 = new ToolStrip();
            tstBorrar = new ToolStripButton();
            tstEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colTalle = new DataGridViewTextBoxColumn();
            ColStock = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tstBorrar, tstEditar, toolStripSeparator1, toolStripSeparator2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(679, 57);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // tstBorrar
            // 
            tstBorrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tstBorrar.Image = Properties.Resources.BorrarPichon;
            tstBorrar.ImageScaling = ToolStripItemImageScaling.None;
            tstBorrar.ImageTransparentColor = Color.Magenta;
            tstBorrar.Name = "tstBorrar";
            tstBorrar.Size = new Size(54, 54);
            tstBorrar.Text = "Borrar";
            tstBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tstBorrar.Click += tstBorrar_Click;
            // 
            // tstEditar
            // 
            tstEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tstEditar.Image = Properties.Resources.Edit;
            tstEditar.ImageScaling = ToolStripItemImageScaling.None;
            tstEditar.ImageTransparentColor = Color.Magenta;
            tstEditar.Name = "tstEditar";
            tstEditar.Size = new Size(54, 54);
            tstEditar.Text = "Editar";
            tstEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            tstEditar.Click += tstEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 57);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 57);
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
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            splitContainer1.Size = new Size(679, 267);
            splitContainer1.SplitterDistance = 235;
            splitContainer1.TabIndex = 4;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colTalle, ColStock });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(679, 235);
            dgvDatos.TabIndex = 5;
            // 
            // colTalle
            // 
            colTalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTalle.HeaderText = "Talle";
            colTalle.Name = "colTalle";
            colTalle.ReadOnly = true;
            // 
            // ColStock
            // 
            ColStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColStock.HeaderText = "Stock";
            ColStock.Name = "ColStock";
            ColStock.ReadOnly = true;
            // 
            // FrmDetalleTalles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 324);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Name = "FrmDetalleTalles";
            Text = "FrmDetalleTalles";
            Load += FrmDetalleTalles_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tstBorrar;
        private ToolStripButton tstEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private SplitContainer splitContainer1;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colTalle;
        private DataGridViewTextBoxColumn ColStock;
    }
}