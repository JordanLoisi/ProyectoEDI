﻿namespace TrabajoEdi3.Windows
{
    partial class FrmAgregarTalles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarTalles));
            btnCancelar = new Button();
            btnOk = new Button();
            cboTalles = new ComboBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            label2 = new Label();
            txtStock = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(393, 118);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 20;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(66, 118);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 19;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // cboTalles
            // 
            cboTalles.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTalles.FormattingEnabled = true;
            cboTalles.Location = new Point(115, 32);
            cboTalles.Name = "cboTalles";
            cboTalles.Size = new Size(383, 23);
            cboTalles.TabIndex = 18;
            cboTalles.SelectedIndexChanged += cboTalles_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 35);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 17;
            label1.Text = "Talles:";
            label1.Click += label1_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 76);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 21;
            label2.Text = "Stock";
            label2.Click += label2_Click;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(98, 68);
            txtStock.MaxLength = 50;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(124, 23);
            txtStock.TabIndex = 29;
            txtStock.TextChanged += txtStock_TextChanged;
            // 
            // FrmAgregarTalles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 223);
            ControlBox = false;
            Controls.Add(txtStock);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(cboTalles);
            Controls.Add(label1);
            Name = "FrmAgregarTalles";
            Text = "FrmAgregarTalles";
            Load += FrmAgregarTalles_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnOk;
        private ComboBox cboTalles;
        private Label label1;
        private ErrorProvider errorProvider1;
        private Label label2;
        private TextBox txtStock;
    }
}