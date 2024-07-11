
namespace TrabajoEdi3.Windows
{
    partial class FrmMarca
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
            BtnNuevo = new ToolStripButton();
            BtnBorrar = new ToolStripButton();
            BtnEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbConsultar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbCerrar = new ToolStripButton();
            panelNavegacion = new Panel();
            txtCantidadRegistros = new TextBox();
            label1 = new Label();
            dgvDatos = new DataGridView();
            ColMarca = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            panelNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { BtnNuevo, BtnBorrar, BtnEditar, toolStripSeparator1, tsbConsultar, toolStripSeparator2, tsbCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(549, 57);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // BtnNuevo
            // 
            BtnNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnNuevo.Image = Properties.Resources.NewPichon;
            BtnNuevo.ImageScaling = ToolStripItemImageScaling.None;
            BtnNuevo.ImageTransparentColor = Color.Magenta;
            BtnNuevo.Name = "BtnNuevo";
            BtnNuevo.Size = new Size(54, 54);
            BtnNuevo.Text = "Nuevo";
            BtnNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnNuevo.Click += BtnNuevo_Click;
            // 
            // BtnBorrar
            // 
            BtnBorrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnBorrar.Image = Properties.Resources.BorrarPichon;
            BtnBorrar.ImageScaling = ToolStripItemImageScaling.None;
            BtnBorrar.ImageTransparentColor = Color.Magenta;
            BtnBorrar.Name = "BtnBorrar";
            BtnBorrar.Size = new Size(54, 54);
            BtnBorrar.Text = "Borrar";
            BtnBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnBorrar.Click += BtnBorrar_Click;
            // 
            // BtnEditar
            // 
            BtnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnEditar.Image = Properties.Resources.Edit;
            BtnEditar.ImageScaling = ToolStripItemImageScaling.None;
            BtnEditar.ImageTransparentColor = Color.Magenta;
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(54, 54);
            BtnEditar.Text = "Editar";
            BtnEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnEditar.Click += BtnEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 57);
            // 
            // tsbConsultar
            // 
            tsbConsultar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbConsultar.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_113847;
            tsbConsultar.ImageScaling = ToolStripItemImageScaling.None;
            tsbConsultar.ImageTransparentColor = Color.Magenta;
            tsbConsultar.Name = "tsbConsultar";
            tsbConsultar.Size = new Size(52, 54);
            tsbConsultar.Text = "Consultar";
            tsbConsultar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbConsultar.Click += tsbConsultar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 57);
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
            tsbCerrar.Click += toolStripButton6_Click;
            // 
            // panelNavegacion
            // 
            panelNavegacion.Controls.Add(txtCantidadRegistros);
            panelNavegacion.Controls.Add(label1);
            panelNavegacion.Dock = DockStyle.Bottom;
            panelNavegacion.Location = new Point(0, 177);
            panelNavegacion.Name = "panelNavegacion";
            panelNavegacion.Size = new Size(549, 75);
            panelNavegacion.TabIndex = 5;
            // 
            // txtCantidadRegistros
            // 
            txtCantidadRegistros.Location = new Point(95, 22);
            txtCantidadRegistros.Name = "txtCantidadRegistros";
            txtCantidadRegistros.ReadOnly = true;
            txtCantidadRegistros.Size = new Size(85, 23);
            txtCantidadRegistros.TabIndex = 19;
            txtCantidadRegistros.TextChanged += txtCantidadRegistros_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 25);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 17;
            label1.Text = "Cantidad";
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { ColMarca });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 57);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(549, 120);
            dgvDatos.TabIndex = 6;
            // 
            // ColMarca
            // 
            ColMarca.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColMarca.HeaderText = "MarcaNombre";
            ColMarca.Name = "ColMarca";
            ColMarca.ReadOnly = true;
            // 
            // FrmMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 252);
            ControlBox = false;
            Controls.Add(dgvDatos);
            Controls.Add(panelNavegacion);
            Controls.Add(toolStrip1);
            Name = "FrmMarca";
            Text = "FrmMarca";
            Load += FrmMarca_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panelNavegacion.ResumeLayout(false);
            panelNavegacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void cboPaginas_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton BtnNuevo;
        private ToolStripButton BtnBorrar;
        private ToolStripButton BtnEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbConsultar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbCerrar;
        private Panel panelNavegacion;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn ColMarca;
        private TextBox txtCantidadRegistros;
        private Label label1;
    }
}