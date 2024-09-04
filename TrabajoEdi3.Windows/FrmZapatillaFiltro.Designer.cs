namespace TrabajoEdi3.Windows
{
    partial class FrmZapatillaFiltro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZapatillaFiltro));
            cboMarca = new ComboBox();
            label7 = new Label();
            cboGenero = new ComboBox();
            label8 = new Label();
            cboColor = new ComboBox();
            label4 = new Label();
            cboDeporte = new ComboBox();
            label3 = new Label();
            btnCancelar = new Button();
            btnOk = new Button();
            errorProvider1 = new ErrorProvider(components);
            cboTalleMaximo = new ComboBox();
            cboTalle = new ComboBox();
            chekSize = new CheckBox();
            label1 = new Label();
            label9 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cboMarca
            // 
            cboMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMarca.FormattingEnabled = true;
            cboMarca.Location = new Point(103, 232);
            cboMarca.Name = "cboMarca";
            cboMarca.Size = new Size(272, 23);
            cboMarca.TabIndex = 75;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(42, 240);
            label7.Name = "label7";
            label7.Size = new Size(40, 15);
            label7.TabIndex = 73;
            label7.Text = "Marca";
            // 
            // cboGenero
            // 
            cboGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGenero.FormattingEnabled = true;
            cboGenero.Location = new Point(103, 153);
            cboGenero.Name = "cboGenero";
            cboGenero.Size = new Size(272, 23);
            cboGenero.TabIndex = 76;
            cboGenero.SelectedIndexChanged += cboGenero_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(42, 156);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 74;
            label8.Text = "Genero";
            // 
            // cboColor
            // 
            cboColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColor.FormattingEnabled = true;
            cboColor.Location = new Point(103, 86);
            cboColor.Name = "cboColor";
            cboColor.Size = new Size(272, 23);
            cboColor.TabIndex = 69;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 87);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 67;
            label4.Text = "Color";
            // 
            // cboDeporte
            // 
            cboDeporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDeporte.FormattingEnabled = true;
            cboDeporte.Location = new Point(103, 27);
            cboDeporte.Name = "cboDeporte";
            cboDeporte.Size = new Size(272, 23);
            cboDeporte.TabIndex = 70;
            cboDeporte.SelectedIndexChanged += cboDeporte_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 28);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 68;
            label3.Text = "Deporte";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(580, 291);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 77;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(164, 291);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 78;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // cboTalleMaximo
            // 
            cboTalleMaximo.Enabled = false;
            cboTalleMaximo.FormattingEnabled = true;
            cboTalleMaximo.Location = new Point(608, 151);
            cboTalleMaximo.Name = "cboTalleMaximo";
            cboTalleMaximo.Size = new Size(121, 23);
            cboTalleMaximo.TabIndex = 84;
            // 
            // cboTalle
            // 
            cboTalle.FormattingEnabled = true;
            cboTalle.Location = new Point(580, 112);
            cboTalle.Name = "cboTalle";
            cboTalle.Size = new Size(121, 23);
            cboTalle.TabIndex = 83;
            // 
            // chekSize
            // 
            chekSize.AutoSize = true;
            chekSize.Location = new Point(644, 85);
            chekSize.Name = "chekSize";
            chekSize.Size = new Size(35, 19);
            chekSize.TabIndex = 82;
            chekSize.Text = "Si";
            chekSize.UseVisualStyleBackColor = true;
            chekSize.CheckedChanged += chekSize_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(465, 86);
            label1.Name = "label1";
            label1.Size = new Size(173, 15);
            label1.TabIndex = 81;
            label1.Text = "Desea filtrar por rango de Sizes?";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(462, 154);
            label9.Name = "label9";
            label9.Size = new Size(140, 15);
            label9.TabIndex = 79;
            label9.Text = "Seleccionar Size Maximo:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(464, 115);
            label10.Name = "label10";
            label10.Size = new Size(110, 15);
            label10.TabIndex = 80;
            label10.Text = "Seleccionar un Size:";
            // 
            // FrmZapatillaFiltro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(899, 391);
            ControlBox = false;
            Controls.Add(cboTalleMaximo);
            Controls.Add(cboTalle);
            Controls.Add(chekSize);
            Controls.Add(label1);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(cboMarca);
            Controls.Add(label7);
            Controls.Add(cboGenero);
            Controls.Add(label8);
            Controls.Add(cboColor);
            Controls.Add(label4);
            Controls.Add(cboDeporte);
            Controls.Add(label3);
            Name = "FrmZapatillaFiltro";
            Text = "FrmZapatillaFiltro";
            Load += FrmZapatillaFiltro_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboMarca;
        private Label label7;
        private ComboBox cboGenero;
        private Label label8;
        private ComboBox cboColor;
        private Label label4;
        private ComboBox cboDeporte;
        private Label label3;
        private Button btnCancelar;
        private Button btnOk;
        private ErrorProvider errorProvider1;
        private ComboBox cboTalleMaximo;
        private ComboBox cboTalle;
        private CheckBox chekSize;
        private Label label1;
        private Label label9;
        private Label label10;
    }
}