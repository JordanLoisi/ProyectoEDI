
namespace TrabajoEdi3.Windows
{
    partial class FrmColor
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
            tstNuevo = new ToolStripButton();
            tstBorrar = new ToolStripButton();
            tstEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            tstSalir = new ToolStripButton();
            panelNavegacion = new Panel();
            txtCantidadRegistros = new TextBox();
            label1 = new Label();
            dgvDatos = new DataGridView();
            ColColor = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            panelNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tstNuevo, tstBorrar, tstEditar, toolStripSeparator1, toolStripSeparator2, tstSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(577, 57);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // tstNuevo
            // 
            tstNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tstNuevo.Image = Properties.Resources.NewPichon;
            tstNuevo.ImageScaling = ToolStripItemImageScaling.None;
            tstNuevo.ImageTransparentColor = Color.Magenta;
            tstNuevo.Name = "tstNuevo";
            tstNuevo.Size = new Size(54, 54);
            tstNuevo.Text = "Nuevo";
            tstNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tstNuevo.Click += tstNuevo_Click;
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
            // tstSalir
            // 
            tstSalir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tstSalir.Image = Properties.Resources.Cancel;
            tstSalir.ImageScaling = ToolStripItemImageScaling.None;
            tstSalir.ImageTransparentColor = Color.Magenta;
            tstSalir.Name = "tstSalir";
            tstSalir.Size = new Size(54, 54);
            tstSalir.Text = "Salir";
            tstSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            tstSalir.Click += tstSalir_Click;
            // 
            // panelNavegacion
            // 
            panelNavegacion.Controls.Add(txtCantidadRegistros);
            panelNavegacion.Controls.Add(label1);
            panelNavegacion.Dock = DockStyle.Bottom;
            panelNavegacion.Location = new Point(0, 202);
            panelNavegacion.Name = "panelNavegacion";
            panelNavegacion.Size = new Size(577, 75);
            panelNavegacion.TabIndex = 6;
            panelNavegacion.Paint += panelNavegacion_Paint;
            // 
            // txtCantidadRegistros
            // 
            txtCantidadRegistros.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCantidadRegistros.Location = new Point(113, 27);
            txtCantidadRegistros.Name = "txtCantidadRegistros";
            txtCantidadRegistros.ReadOnly = true;
            txtCantidadRegistros.Size = new Size(85, 24);
            txtCantidadRegistros.TabIndex = 19;
            txtCantidadRegistros.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 30);
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
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { ColColor });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 57);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(577, 145);
            dgvDatos.TabIndex = 8;
            // 
            // ColColor
            // 
            ColColor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColColor.HeaderText = "ColorName";
            ColColor.Name = "ColColor";
            ColColor.ReadOnly = true;
            // 
            // FrmColor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 277);
            ControlBox = false;
            Controls.Add(dgvDatos);
            Controls.Add(panelNavegacion);
            Controls.Add(toolStrip1);
            Name = "FrmColor";
            Text = "FrmColor";
            Load += FrmColor_Load_1;
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
        private ToolStripButton tstNuevo;
        private ToolStripButton tstBorrar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tstSalir;
        private Panel panelNavegacion;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn ColColor;
        private TextBox txtCantidadRegistros;
        private Label label1;
        private ToolStripButton tstEditar;
    }
}