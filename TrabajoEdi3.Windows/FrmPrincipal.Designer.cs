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
            SuspendLayout();
            // 
            // btnColor
            // 
            btnColor.Location = new Point(354, 53);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(109, 79);
            btnColor.TabIndex = 1;
            btnColor.Text = "Color";
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // btnDeporte
            // 
            btnDeporte.Location = new Point(209, 53);
            btnDeporte.Name = "btnDeporte";
            btnDeporte.Size = new Size(109, 79);
            btnDeporte.TabIndex = 2;
            btnDeporte.Text = "Deporte";
            btnDeporte.UseVisualStyleBackColor = true;
            btnDeporte.Click += btnDeporte_Click;
            // 
            // btnMarca
            // 
            btnMarca.Location = new Point(63, 53);
            btnMarca.Name = "btnMarca";
            btnMarca.Size = new Size(109, 79);
            btnMarca.TabIndex = 3;
            btnMarca.Text = "Marca";
            btnMarca.UseVisualStyleBackColor = true;
            btnMarca.Click += btnMarca_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(209, 297);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(109, 79);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // BtnZapatilla
            // 
            BtnZapatilla.Location = new Point(354, 173);
            BtnZapatilla.Name = "BtnZapatilla";
            BtnZapatilla.Size = new Size(109, 79);
            BtnZapatilla.TabIndex = 5;
            BtnZapatilla.Text = "Zapatilla";
            BtnZapatilla.UseVisualStyleBackColor = true;
            BtnZapatilla.Click += BtnZapatilla_Click;
            // 
            // btnGenero
            // 
            btnGenero.Location = new Point(109, 173);
            btnGenero.Name = "btnGenero";
            btnGenero.Size = new Size(109, 79);
            btnGenero.TabIndex = 6;
            btnGenero.Text = "Genero";
            btnGenero.UseVisualStyleBackColor = true;
            btnGenero.Click += btnGenero_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 415);
            ControlBox = false;
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
    }
}