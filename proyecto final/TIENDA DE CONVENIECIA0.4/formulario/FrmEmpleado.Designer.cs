namespace TIENDA_DE_CONVENIECIA0._4.formulario
{
    partial class FrmEmpleado
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGestionarStock = new System.Windows.Forms.Button();
            this.btnConsultarStock = new System.Windows.Forms.Button();
            this.btnCerraSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "empleado menu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnGestionarStock
            // 
            this.btnGestionarStock.Location = new System.Drawing.Point(564, 63);
            this.btnGestionarStock.Name = "btnGestionarStock";
            this.btnGestionarStock.Size = new System.Drawing.Size(224, 54);
            this.btnGestionarStock.TabIndex = 1;
            this.btnGestionarStock.Text = "gestionar stock";
            this.btnGestionarStock.UseVisualStyleBackColor = true;
            this.btnGestionarStock.Click += new System.EventHandler(this.btnGestionarStock_Click);
            // 
            // btnConsultarStock
            // 
            this.btnConsultarStock.Location = new System.Drawing.Point(564, 115);
            this.btnConsultarStock.Name = "btnConsultarStock";
            this.btnConsultarStock.Size = new System.Drawing.Size(224, 52);
            this.btnConsultarStock.TabIndex = 2;
            this.btnConsultarStock.Text = "consultar stock";
            this.btnConsultarStock.UseVisualStyleBackColor = true;
            this.btnConsultarStock.Click += new System.EventHandler(this.btnConsultarStock_Click);
            // 
            // btnCerraSesion
            // 
            this.btnCerraSesion.Location = new System.Drawing.Point(564, 165);
            this.btnCerraSesion.Name = "btnCerraSesion";
            this.btnCerraSesion.Size = new System.Drawing.Size(224, 50);
            this.btnCerraSesion.TabIndex = 3;
            this.btnCerraSesion.Text = "cerra sesion";
            this.btnCerraSesion.UseVisualStyleBackColor = true;
            this.btnCerraSesion.Click += new System.EventHandler(this.btnCerraSesion_Click);
            // 
            // FrmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::TIENDA_DE_CONVENIECIA0._4.Properties.Resources.stock;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerraSesion);
            this.Controls.Add(this.btnConsultarStock);
            this.Controls.Add(this.btnGestionarStock);
            this.Controls.Add(this.label1);
            this.Name = "FrmEmpleado";
            this.Text = "FrmEmpleado";
            this.Load += new System.EventHandler(this.FrmEmpleado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGestionarStock;
        private System.Windows.Forms.Button btnConsultarStock;
        private System.Windows.Forms.Button btnCerraSesion;
    }
}