namespace TrabajoEdi3.Windows
{
    partial class FrmZapatilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZapatilla));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tstBorrar = new ToolStripButton();
            tstEditar = new ToolStripButton();
            tsbFiltrar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbActualizar = new ToolStripButton();
            tsbOrden = new ToolStripDropDownButton();
            aZToolStripMenuItem = new ToolStripMenuItem();
            zAToolStripMenuItem = new ToolStripMenuItem();
            menorPrecioToolStripMenuItem = new ToolStripMenuItem();
            mayorPrecioToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbTalle = new ToolStripButton();
            tsbAsignarTalle = new ToolStripButton();
            toolStripButton6 = new ToolStripButton();
            panelNavegacion = new Panel();
            CantidadZapatillasLbl = new Label();
            label2 = new Label();
            CantidadPaginasLbl = new Label();
            label3 = new Label();
            PaginaActualLbl = new Label();
            label1 = new Label();
            btnUltimo = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            dgvDatos = new DataGridView();
            colMarca = new DataGridViewTextBoxColumn();
            colDeporte = new DataGridViewTextBoxColumn();
            colGenero = new DataGridViewTextBoxColumn();
            colColor = new DataGridViewTextBoxColumn();
            colModelo = new DataGridViewTextBoxColumn();
            colDescrip = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            panelNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tstBorrar, tstEditar, tsbFiltrar, toolStripSeparator1, tsbActualizar, tsbOrden, toolStripSeparator2, tsbTalle, tsbAsignarTalle, toolStripButton6 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 62);
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
            tsbNuevo.Size = new Size(54, 59);
            tsbNuevo.Text = "Nuevo";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tstBorrar
            // 
            tstBorrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tstBorrar.Image = Properties.Resources.BorrarPichon;
            tstBorrar.ImageScaling = ToolStripItemImageScaling.None;
            tstBorrar.ImageTransparentColor = Color.Magenta;
            tstBorrar.Name = "tstBorrar";
            tstBorrar.Size = new Size(54, 59);
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
            tstEditar.Size = new Size(54, 59);
            tstEditar.Text = "Editar";
            tstEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            tstEditar.Click += tstEditar_Click;
            // 
            // tsbFiltrar
            // 
            tsbFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbFiltrar.Image = (Image)resources.GetObject("tsbFiltrar.Image");
            tsbFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.Size = new Size(41, 59);
            tsbFiltrar.Text = "Filtrar";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbFiltrar.Click += tsbFiltrar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 62);
            // 
            // tsbActualizar
            // 
            tsbActualizar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbActualizar.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_114215;
            tsbActualizar.ImageScaling = ToolStripItemImageScaling.None;
            tsbActualizar.ImageTransparentColor = Color.Magenta;
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(47, 59);
            tsbActualizar.Text = "Actualizar";
            tsbActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbActualizar.Click += tsbActualizar_Click;
            // 
            // tsbOrden
            // 
            tsbOrden.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbOrden.DropDownItems.AddRange(new ToolStripItem[] { aZToolStripMenuItem, zAToolStripMenuItem, menorPrecioToolStripMenuItem, mayorPrecioToolStripMenuItem });
            tsbOrden.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_115948;
            tsbOrden.ImageScaling = ToolStripItemImageScaling.None;
            tsbOrden.ImageTransparentColor = Color.Magenta;
            tsbOrden.Name = "tsbOrden";
            tsbOrden.Size = new Size(63, 59);
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
            // menorPrecioToolStripMenuItem
            // 
            menorPrecioToolStripMenuItem.Name = "menorPrecioToolStripMenuItem";
            menorPrecioToolStripMenuItem.Size = new Size(180, 22);
            menorPrecioToolStripMenuItem.Text = "Menor Precio";
            menorPrecioToolStripMenuItem.Click += menorPrecioToolStripMenuItem_Click;
            // 
            // mayorPrecioToolStripMenuItem
            // 
            mayorPrecioToolStripMenuItem.Name = "mayorPrecioToolStripMenuItem";
            mayorPrecioToolStripMenuItem.Size = new Size(180, 22);
            mayorPrecioToolStripMenuItem.Text = "Mayor Precio";
            mayorPrecioToolStripMenuItem.Click += mayorPrecioToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 62);
            // 
            // tsbTalle
            // 
            tsbTalle.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_114036;
            tsbTalle.ImageScaling = ToolStripItemImageScaling.None;
            tsbTalle.ImageTransparentColor = Color.Magenta;
            tsbTalle.Name = "tsbTalle";
            tsbTalle.Size = new Size(43, 59);
            tsbTalle.Text = "Talles";
            tsbTalle.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbTalle.Click += tsbTalle_Click;
            // 
            // tsbAsignarTalle
            // 
            tsbAsignarTalle.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_114358;
            tsbAsignarTalle.ImageScaling = ToolStripItemImageScaling.None;
            tsbAsignarTalle.ImageTransparentColor = Color.Magenta;
            tsbAsignarTalle.Name = "tsbAsignarTalle";
            tsbAsignarTalle.Size = new Size(79, 59);
            tsbAsignarTalle.Text = "Agregar Talle";
            tsbAsignarTalle.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbAsignarTalle.Click += tsbAsignarTalle_Click;
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton6.Image = Properties.Resources.Cancel;
            toolStripButton6.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(54, 59);
            toolStripButton6.Text = "Salir";
            toolStripButton6.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton6.Click += toolStripButton6_Click;
            // 
            // panelNavegacion
            // 
            panelNavegacion.Controls.Add(CantidadZapatillasLbl);
            panelNavegacion.Controls.Add(label2);
            panelNavegacion.Controls.Add(CantidadPaginasLbl);
            panelNavegacion.Controls.Add(label3);
            panelNavegacion.Controls.Add(PaginaActualLbl);
            panelNavegacion.Controls.Add(label1);
            panelNavegacion.Controls.Add(btnUltimo);
            panelNavegacion.Controls.Add(btnSiguiente);
            panelNavegacion.Controls.Add(btnAnterior);
            panelNavegacion.Controls.Add(btnPrimero);
            panelNavegacion.Dock = DockStyle.Bottom;
            panelNavegacion.Location = new Point(0, 375);
            panelNavegacion.Name = "panelNavegacion";
            panelNavegacion.Size = new Size(800, 75);
            panelNavegacion.TabIndex = 4;
            // 
            // CantidadZapatillasLbl
            // 
            CantidadZapatillasLbl.AutoSize = true;
            CantidadZapatillasLbl.BackColor = SystemColors.ActiveCaptionText;
            CantidadZapatillasLbl.ForeColor = Color.FromArgb(224, 224, 224);
            CantidadZapatillasLbl.Location = new Point(714, 31);
            CantidadZapatillasLbl.Name = "CantidadZapatillasLbl";
            CantidadZapatillasLbl.Size = new Size(13, 15);
            CantidadZapatillasLbl.TabIndex = 27;
            CantidadZapatillasLbl.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaptionText;
            label2.ForeColor = Color.FromArgb(224, 224, 224);
            label2.Location = new Point(581, 31);
            label2.Name = "label2";
            label2.Size = new Size(127, 15);
            label2.TabIndex = 26;
            label2.Text = "Cantidad de Zapatillas:";
            // 
            // CantidadPaginasLbl
            // 
            CantidadPaginasLbl.AutoSize = true;
            CantidadPaginasLbl.BackColor = SystemColors.ActiveCaptionText;
            CantidadPaginasLbl.ForeColor = Color.FromArgb(224, 224, 224);
            CantidadPaginasLbl.Location = new Point(182, 31);
            CantidadPaginasLbl.Name = "CantidadPaginasLbl";
            CantidadPaginasLbl.Size = new Size(19, 15);
            CantidadPaginasLbl.TabIndex = 25;
            CantidadPaginasLbl.Text = "10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaptionText;
            label3.ForeColor = Color.FromArgb(224, 224, 224);
            label3.Location = new Point(156, 31);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 24;
            label3.Text = "de";
            // 
            // PaginaActualLbl
            // 
            PaginaActualLbl.AutoSize = true;
            PaginaActualLbl.BackColor = SystemColors.ActiveCaptionText;
            PaginaActualLbl.ForeColor = Color.FromArgb(224, 224, 224);
            PaginaActualLbl.Location = new Point(137, 31);
            PaginaActualLbl.Name = "PaginaActualLbl";
            PaginaActualLbl.Size = new Size(13, 15);
            PaginaActualLbl.TabIndex = 23;
            PaginaActualLbl.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(91, 30);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 22;
            label1.Text = "Página";
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.Last;
            btnUltimo.Location = new Point(461, 17);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(75, 41);
            btnUltimo.TabIndex = 18;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.Next_page;
            btnSiguiente.Location = new Point(380, 17);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(75, 41);
            btnSiguiente.TabIndex = 19;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.Prev;
            btnAnterior.Location = new Point(299, 17);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 41);
            btnAnterior.TabIndex = 20;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.Previous;
            btnPrimero.Location = new Point(218, 17);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(75, 41);
            btnPrimero.TabIndex = 21;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colMarca, colDeporte, colGenero, colColor, colModelo, colDescrip, colPrecio });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 62);
            dgvDatos.Name = "dgvDatos";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(800, 313);
            dgvDatos.TabIndex = 5;
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
            // FrmZapatilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(dgvDatos);
            Controls.Add(panelNavegacion);
            Controls.Add(toolStrip1);
            Name = "FrmZapatilla";
            Text = "FrmZapatilla";
            Load += FrmZapatilla_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panelNavegacion.ResumeLayout(false);
            panelNavegacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tstBorrar;
        private ToolStripButton tstEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton6;
        private Panel panelNavegacion;
        private DataGridView dgvDatos;
        private ToolStripButton tsbActualizar;
        private ToolStripDropDownButton tsbOrden;
        private ToolStripMenuItem aZToolStripMenuItem;
        private ToolStripMenuItem zAToolStripMenuItem;
        private ToolStripMenuItem menorPrecioToolStripMenuItem;
        private ToolStripMenuItem mayorPrecioToolStripMenuItem;
        private ToolStripButton tsbTalle;
        private ToolStripButton tsbAsignarTalle;
        private Label CantidadZapatillasLbl;
        private Label label2;
        private Label CantidadPaginasLbl;
        private Label label3;
        private Label PaginaActualLbl;
        private Label label1;
        private Button btnUltimo;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private DataGridView dgvConsulta;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewTextBoxColumn colDeporte;
        private DataGridViewTextBoxColumn colGenero;
        private DataGridViewTextBoxColumn colColor;
        private DataGridViewTextBoxColumn colModelo;
        private DataGridViewTextBoxColumn colDescrip;
        private DataGridViewTextBoxColumn colPrecio;
        private ToolStripButton tsbFiltrar;
    }
}