namespace TrabajoEdi3.Windows
{
    partial class FrmPrincipal
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
            btnColor = new Button();
            btnDeporte = new Button();
            btnMarca = new Button();
            btnSalir = new Button();
            BtnZapatilla = new Button();
            btnGenero = new Button();
            btnTalles = new Button();
            SuspendLayout();
            // 
            // btnColor
            // 
            btnColor.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_114056;
            btnColor.Location = new Point(404, 42);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(109, 89);
            btnColor.TabIndex = 1;
            btnColor.Text = "Color";
            btnColor.TextImageRelation = TextImageRelation.ImageAboveText;
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // btnDeporte
            // 
            btnDeporte.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_114007;
            btnDeporte.Location = new Point(233, 42);
            btnDeporte.Name = "btnDeporte";
            btnDeporte.Size = new Size(109, 89);
            btnDeporte.TabIndex = 2;
            btnDeporte.Text = "Deporte";
            btnDeporte.TextImageRelation = TextImageRelation.ImageAboveText;
            btnDeporte.UseVisualStyleBackColor = true;
            btnDeporte.Click += btnDeporte_Click;
            // 
            // btnMarca
            // 
            btnMarca.BackgroundImageLayout = ImageLayout.Center;
            btnMarca.Cursor = Cursors.No;
            btnMarca.ForeColor = Color.Black;
            btnMarca.Image = Properties.Resources.Captura_de_pantalla_2024_07_09_142506;
            btnMarca.Location = new Point(47, 42);
            btnMarca.Name = "btnMarca";
            btnMarca.Size = new Size(109, 89);
            btnMarca.TabIndex = 3;
            btnMarca.Text = "Marca";
            btnMarca.TextImageRelation = TextImageRelation.ImageAboveText;
            btnMarca.UseVisualStyleBackColor = true;
            btnMarca.Click += btnMarca_Click;
            // 
            // btnSalir
            // 
            btnSalir.Image = Properties.Resources.Cancel;
            btnSalir.Location = new Point(233, 314);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(109, 79);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // BtnZapatilla
            // 
            BtnZapatilla.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_114126;
            BtnZapatilla.Location = new Point(416, 187);
            BtnZapatilla.Name = "BtnZapatilla";
            BtnZapatilla.Size = new Size(109, 79);
            BtnZapatilla.TabIndex = 5;
            BtnZapatilla.Text = "Zapatilla";
            BtnZapatilla.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnZapatilla.UseVisualStyleBackColor = true;
            BtnZapatilla.Click += BtnZapatilla_Click;
            // 
            // btnGenero
            // 
            btnGenero.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_115743;
            btnGenero.Location = new Point(47, 184);
            btnGenero.Name = "btnGenero";
            btnGenero.Size = new Size(118, 84);
            btnGenero.TabIndex = 6;
            btnGenero.Text = "Genero";
            btnGenero.TextImageRelation = TextImageRelation.ImageAboveText;
            btnGenero.UseVisualStyleBackColor = true;
            btnGenero.Click += btnGenero_Click;
            // 
            // btnTalles
            // 
            btnTalles.Image = Properties.Resources.Captura_de_pantalla_2024_07_11_114036;
            btnTalles.Location = new Point(233, 187);
            btnTalles.Name = "btnTalles";
            btnTalles.Size = new Size(109, 79);
            btnTalles.TabIndex = 7;
            btnTalles.Text = "Talles";
            btnTalles.TextImageRelation = TextImageRelation.ImageAboveText;
            btnTalles.UseVisualStyleBackColor = true;
            btnTalles.Click += btnTalles_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(589, 415);
            ControlBox = false;
            Controls.Add(btnTalles);
            Controls.Add(btnSalir);
            Controls.Add(BtnZapatilla);
            Controls.Add(btnGenero);
            Controls.Add(btnColor);
            Controls.Add(btnDeporte);
            Controls.Add(btnMarca);
            Name = "FrmPrincipal";
            Text = "FrmPrincipal";
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnColor;
        private Button btnDeporte;
        private Button btnMarca;
        private Button btnSalir;
        private Button BtnZapatilla;
        private Button btnGenero;
        private Button btnTalles;
    }
}