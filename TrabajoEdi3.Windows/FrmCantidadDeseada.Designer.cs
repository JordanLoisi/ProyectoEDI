namespace TrabajoEdi3.Windows
{
    partial class FrmCantidadDeseada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCantidadDeseada));
            txtCantidad = new TextBox();
            label2 = new Label();
            btnCancelar = new Button();
            btnOk = new Button();
            Cantidad = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(175, 34);
            txtCantidad.MaxLength = 50;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(90, 23);
            txtCantidad.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(-84, 40);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 32;
            label2.Text = "Stock";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(205, 98);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(71, 48);
            btnCancelar.TabIndex = 31;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(25, 98);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(135, 48);
            btnOk.TabIndex = 30;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // Cantidad
            // 
            Cantidad.AutoSize = true;
            Cantidad.Location = new Point(59, 42);
            Cantidad.Name = "Cantidad";
            Cantidad.Size = new Size(55, 15);
            Cantidad.TabIndex = 34;
            Cantidad.Text = "Cantidad";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmCantidadDeseada
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 192);
            ControlBox = false;
            Controls.Add(Cantidad);
            Controls.Add(txtCantidad);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Name = "FrmCantidadDeseada";
            Text = "FrmCantidadDeseada";
            Load += FrmCantidadDeseada_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCantidad;
        private Label label2;
        private Button btnCancelar;
        private Button btnOk;
        private Label Cantidad;
        private ErrorProvider errorProvider1;
    }
}