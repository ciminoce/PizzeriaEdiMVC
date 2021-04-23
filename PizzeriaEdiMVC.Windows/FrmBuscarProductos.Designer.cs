
namespace PizzeriaEdiMVC.Windows
{
    partial class FrmBuscarProductos
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.CancelarButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.TipoProductoComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Image = global::PizzeriaEdiMVC.Windows.Properties.Resources.Cancelar;
            this.CancelarButton.Location = new System.Drawing.Point(441, 139);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(99, 56);
            this.CancelarButton.TabIndex = 3;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Image = global::PizzeriaEdiMVC.Windows.Properties.Resources.Aceptar;
            this.OKButton.Location = new System.Drawing.Point(88, 139);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(99, 56);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // TipoProductoComboBox
            // 
            this.TipoProductoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoProductoComboBox.FormattingEnabled = true;
            this.TipoProductoComboBox.Location = new System.Drawing.Point(150, 64);
            this.TipoProductoComboBox.Name = "TipoProductoComboBox";
            this.TipoProductoComboBox.Size = new System.Drawing.Size(417, 21);
            this.TipoProductoComboBox.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tipo de Producto:";
            // 
            // FrmBuscarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 238);
            this.ControlBox = false;
            this.Controls.Add(this.TipoProductoComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.OKButton);
            this.Name = "FrmBuscarProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Producto...";
            this.Load += new System.EventHandler(this.FrmBuscarProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ComboBox TipoProductoComboBox;
        private System.Windows.Forms.Label label2;
    }
}