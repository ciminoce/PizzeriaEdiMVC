
namespace PizzeriaEdiMVC.Windows
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TipoProductosButton = new System.Windows.Forms.Button();
            this.ProductosButton = new System.Windows.Forms.Button();
            this.VentasButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TipoProductosButton
            // 
            this.TipoProductosButton.Location = new System.Drawing.Point(63, 72);
            this.TipoProductosButton.Name = "TipoProductosButton";
            this.TipoProductosButton.Size = new System.Drawing.Size(142, 40);
            this.TipoProductosButton.TabIndex = 0;
            this.TipoProductosButton.Text = "Tipos de Productos";
            this.TipoProductosButton.UseVisualStyleBackColor = true;
            this.TipoProductosButton.Click += new System.EventHandler(this.TipoProductosButton_Click);
            // 
            // ProductosButton
            // 
            this.ProductosButton.Location = new System.Drawing.Point(63, 140);
            this.ProductosButton.Name = "ProductosButton";
            this.ProductosButton.Size = new System.Drawing.Size(142, 40);
            this.ProductosButton.TabIndex = 0;
            this.ProductosButton.Text = "Productos";
            this.ProductosButton.UseVisualStyleBackColor = true;
            this.ProductosButton.Click += new System.EventHandler(this.ProductosButton_Click);
            // 
            // VentasButton
            // 
            this.VentasButton.Location = new System.Drawing.Point(226, 72);
            this.VentasButton.Name = "VentasButton";
            this.VentasButton.Size = new System.Drawing.Size(153, 108);
            this.VentasButton.TabIndex = 0;
            this.VentasButton.Text = "Ventas";
            this.VentasButton.UseVisualStyleBackColor = true;
            this.VentasButton.Click += new System.EventHandler(this.VentasButton_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VentasButton);
            this.Controls.Add(this.ProductosButton);
            this.Controls.Add(this.TipoProductosButton);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TipoProductosButton;
        private System.Windows.Forms.Button ProductosButton;
        private System.Windows.Forms.Button VentasButton;
    }
}

