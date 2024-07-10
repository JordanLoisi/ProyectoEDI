namespace TrabajoEdi3.Windows
{
    partial class FrmZapatillaAE
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZapatillaAE));
            lblNuevoColor = new Label();
            lblNuevoDeporte = new Label();
            btnAgregarColor = new Button();
            btnDeporte = new Button();
            btnCancelar = new Button();
            btnOk = new Button();
            cboColor = new ComboBox();
            label4 = new Label();
            cboDeporte = new ComboBox();
            label3 = new Label();
            txtModelo = new TextBox();
            label5 = new Label();
            txtPrecio = new TextBox();
            label2 = new Label();
            txtZapatilla = new TextBox();
            label1 = new Label();
            lblNuevoGenero = new Label();
            btnAgregarMarca = new Button();
            btnAgregarGenero = new Button();
            cboMarca = new ComboBox();
            label7 = new Label();
            cboGenero = new ComboBox();
            label8 = new Label();
            lblNuevaMarca = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblNuevoColor
            // 
            lblNuevoColor.AutoSize = true;
            lblNuevoColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNuevoColor.ForeColor = Color.Red;
            lblNuevoColor.Location = new Point(110, 246);
            lblNuevoColor.Name = "lblNuevoColor";
            lblNuevoColor.Size = new Size(76, 15);
            lblNuevoColor.TabIndex = 58;
            lblNuevoColor.Text = "Nuevo Color";
            lblNuevoColor.Visible = false;
            // 
            // lblNuevoDeporte
            // 
            lblNuevoDeporte.AutoSize = true;
            lblNuevoDeporte.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNuevoDeporte.ForeColor = Color.Red;
            lblNuevoDeporte.Location = new Point(110, 186);
            lblNuevoDeporte.Name = "lblNuevoDeporte";
            lblNuevoDeporte.Size = new Size(94, 15);
            lblNuevoDeporte.TabIndex = 57;
            lblNuevoDeporte.Text = "Nuevo Deporte";
            lblNuevoDeporte.Visible = false;
            // 
            // btnAgregarColor
            // 
            btnAgregarColor.Location = new Point(404, 205);
            btnAgregarColor.Name = "btnAgregarColor";
            btnAgregarColor.Size = new Size(57, 32);
            btnAgregarColor.TabIndex = 56;
            btnAgregarColor.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAgregarColor.UseVisualStyleBackColor = true;
            btnAgregarColor.Click += btnAgregarColor_Click;
            // 
            // btnDeporte
            // 
            btnDeporte.Location = new Point(404, 146);
            btnDeporte.Name = "btnDeporte";
            btnDeporte.Size = new Size(57, 32);
            btnDeporte.TabIndex = 55;
            btnDeporte.TextImageRelation = TextImageRelation.ImageAboveText;
            btnDeporte.UseVisualStyleBackColor = true;
            btnDeporte.Click += btnDeporte_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(914, 313);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 53;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(546, 242);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 54;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // cboColor
            // 
            cboColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColor.FormattingEnabled = true;
            cboColor.Location = new Point(110, 211);
            cboColor.Name = "cboColor";
            cboColor.Size = new Size(272, 23);
            cboColor.TabIndex = 51;
            cboColor.SelectedIndexChanged += cboColor_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 212);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 49;
            label4.Text = "Color";
            // 
            // cboDeporte
            // 
            cboDeporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDeporte.FormattingEnabled = true;
            cboDeporte.Location = new Point(110, 152);
            cboDeporte.Name = "cboDeporte";
            cboDeporte.Size = new Size(272, 23);
            cboDeporte.TabIndex = 52;
            cboDeporte.SelectedIndexChanged += cboDeporte_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 153);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 50;
            label3.Text = "Deporte";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(108, 110);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(433, 23);
            txtModelo.TabIndex = 46;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 113);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 43;
            label5.Text = "Modelo";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(108, 69);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(433, 23);
            txtPrecio.TabIndex = 47;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 72);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 44;
            label2.Text = "P. Costo:";
            // 
            // txtZapatilla
            // 
            txtZapatilla.Location = new Point(102, 26);
            txtZapatilla.MaxLength = 100;
            txtZapatilla.Name = "txtZapatilla";
            txtZapatilla.Size = new Size(433, 23);
            txtZapatilla.TabIndex = 48;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 34);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 45;
            label1.Text = "Zapatilla";
            // 
            // lblNuevoGenero
            // 
            lblNuevoGenero.AutoSize = true;
            lblNuevoGenero.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNuevoGenero.ForeColor = Color.Red;
            lblNuevoGenero.Location = new Point(110, 313);
            lblNuevoGenero.Name = "lblNuevoGenero";
            lblNuevoGenero.Size = new Size(89, 15);
            lblNuevoGenero.TabIndex = 65;
            lblNuevoGenero.Text = "Nuevo Genero";
            lblNuevoGenero.Visible = false;
            // 
            // btnAgregarMarca
            // 
            btnAgregarMarca.Location = new Point(404, 348);
            btnAgregarMarca.Name = "btnAgregarMarca";
            btnAgregarMarca.Size = new Size(57, 32);
            btnAgregarMarca.TabIndex = 64;
            btnAgregarMarca.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAgregarMarca.UseVisualStyleBackColor = true;
            btnAgregarMarca.Click += btnAgregarMarca_Click;
            // 
            // btnAgregarGenero
            // 
            btnAgregarGenero.Location = new Point(404, 278);
            btnAgregarGenero.Name = "btnAgregarGenero";
            btnAgregarGenero.Size = new Size(57, 32);
            btnAgregarGenero.TabIndex = 63;
            btnAgregarGenero.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAgregarGenero.UseVisualStyleBackColor = true;
            btnAgregarGenero.Click += btnAgregarGenero_Click;
            // 
            // cboMarca
            // 
            cboMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMarca.FormattingEnabled = true;
            cboMarca.Location = new Point(110, 357);
            cboMarca.Name = "cboMarca";
            cboMarca.Size = new Size(272, 23);
            cboMarca.TabIndex = 61;
            cboMarca.SelectedIndexChanged += cboMarca_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(49, 365);
            label7.Name = "label7";
            label7.Size = new Size(40, 15);
            label7.TabIndex = 59;
            label7.Text = "Marca";
            // 
            // cboGenero
            // 
            cboGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGenero.FormattingEnabled = true;
            cboGenero.Location = new Point(110, 278);
            cboGenero.Name = "cboGenero";
            cboGenero.Size = new Size(272, 23);
            cboGenero.TabIndex = 62;
            cboGenero.SelectedIndexChanged += cboGenero_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(49, 281);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 60;
            label8.Text = "Genero";
            // 
            // lblNuevaMarca
            // 
            lblNuevaMarca.AutoSize = true;
            lblNuevaMarca.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNuevaMarca.ForeColor = Color.Red;
            lblNuevaMarca.Location = new Point(115, 383);
            lblNuevaMarca.Name = "lblNuevaMarca";
            lblNuevaMarca.Size = new Size(80, 15);
            lblNuevaMarca.TabIndex = 66;
            lblNuevaMarca.Text = "Nueva Marca";
            lblNuevaMarca.Visible = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmZapatillaAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1089, 400);
            ControlBox = false;
            Controls.Add(lblNuevaMarca);
            Controls.Add(lblNuevoGenero);
            Controls.Add(btnAgregarMarca);
            Controls.Add(btnAgregarGenero);
            Controls.Add(cboMarca);
            Controls.Add(label7);
            Controls.Add(cboGenero);
            Controls.Add(label8);
            Controls.Add(lblNuevoColor);
            Controls.Add(lblNuevoDeporte);
            Controls.Add(btnAgregarColor);
            Controls.Add(btnDeporte);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(cboColor);
            Controls.Add(label4);
            Controls.Add(cboDeporte);
            Controls.Add(label3);
            Controls.Add(txtModelo);
            Controls.Add(label5);
            Controls.Add(txtPrecio);
            Controls.Add(label2);
            Controls.Add(txtZapatilla);
            Controls.Add(label1);
            Name = "FrmZapatillaAE";
            Text = "FrmZapatillaAE";
            Load += FrmZapatillaAE_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNuevoColor;
        private Label lblNuevoDeporte;
        private Button btnAgregarColor;
        private Button btnDeporte;
        private Button btnCancelar;
        private Button btnOk;
        private ComboBox cboColor;
        private Label label4;
        private ComboBox cboDeporte;
        private Label label3;
        private TextBox txtModelo;
        private Label label5;
        private TextBox txtPrecio;
        private Label label2;
        private TextBox txtZapatilla;
        private Label label1;
        private Label lblNuevoGenero;
        private Button btnAgregarMarca;
        private Button btnAgregarGenero;
        private ComboBox cboMarca;
        private Label label7;
        private ComboBox cboGenero;
        private Label label8;
        private Label lblNuevaMarca;
        private ErrorProvider errorProvider1;
    }
}