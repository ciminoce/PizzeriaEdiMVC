
namespace PizzeriaEdiMVC.Windows
{
    partial class FrmTipoProductosAE
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.TipoProductoTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.CancelarButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Producto:";
            // 
            // TipoProductoTextBox
            // 
            this.TipoProductoTextBox.Location = new System.Drawing.Point(171, 52);
            this.TipoProductoTextBox.Name = "TipoProductoTextBox";
            this.TipoProductoTextBox.Size = new System.Drawing.Size(344, 20);
            this.TipoProductoTextBox.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Image = global::PizzeriaEdiMVC.Windows.Properties.Resources.Cancelar;
            this.CancelarButton.Location = new System.Drawing.Point(416, 118);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(99, 56);
            this.CancelarButton.TabIndex = 2;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Image = global::PizzeriaEdiMVC.Windows.Properties.Resources.Aceptar;
            this.OKButton.Location = new System.Drawing.Point(63, 118);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(99, 56);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // FrmTipoProductosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 221);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.TipoProductoTextBox);
            this.Controls.Add(this.label1);
            this.Name = "FrmTipoProductosAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTipoProductosAE";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TipoProductoTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}