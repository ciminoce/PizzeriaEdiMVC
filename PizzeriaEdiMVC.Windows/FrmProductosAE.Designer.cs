
namespace PizzeriaEdiMVC.Windows
{
    partial class FrmProductosAE
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
            this.ActivoCheckBox = new System.Windows.Forms.CheckBox();
            this.TipoProductoComboBox = new System.Windows.Forms.ComboBox();
            this.DetallesTextBox = new System.Windows.Forms.TextBox();
            this.PrecioTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.BuscarImagenButton = new System.Windows.Forms.Button();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ActivoCheckBox
            // 
            this.ActivoCheckBox.AutoSize = true;
            this.ActivoCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ActivoCheckBox.Location = new System.Drawing.Point(110, 310);
            this.ActivoCheckBox.Name = "ActivoCheckBox";
            this.ActivoCheckBox.Size = new System.Drawing.Size(56, 17);
            this.ActivoCheckBox.TabIndex = 4;
            this.ActivoCheckBox.Text = "Activo";
            this.ActivoCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ActivoCheckBox.UseVisualStyleBackColor = true;
            // 
            // TipoProductoComboBox
            // 
            this.TipoProductoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoProductoComboBox.FormattingEnabled = true;
            this.TipoProductoComboBox.Location = new System.Drawing.Point(153, 79);
            this.TipoProductoComboBox.Name = "TipoProductoComboBox";
            this.TipoProductoComboBox.Size = new System.Drawing.Size(417, 21);
            this.TipoProductoComboBox.TabIndex = 1;
            // 
            // DetallesTextBox
            // 
            this.DetallesTextBox.Location = new System.Drawing.Point(151, 176);
            this.DetallesTextBox.MaxLength = 250;
            this.DetallesTextBox.Multiline = true;
            this.DetallesTextBox.Name = "DetallesTextBox";
            this.DetallesTextBox.Size = new System.Drawing.Size(420, 109);
            this.DetallesTextBox.TabIndex = 3;
            // 
            // PrecioTextBox
            // 
            this.PrecioTextBox.Location = new System.Drawing.Point(151, 134);
            this.PrecioTextBox.MaxLength = 18;
            this.PrecioTextBox.Name = "PrecioTextBox";
            this.PrecioTextBox.Size = new System.Drawing.Size(420, 20);
            this.PrecioTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Descripción:";
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.Location = new System.Drawing.Point(151, 39);
            this.DescripcionTextBox.MaxLength = 50;
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(420, 20);
            this.DescripcionTextBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Precio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tipo de Producto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Producto:";
            // 
            // CancelarButton
            // 
            this.CancelarButton.Image = global::PizzeriaEdiMVC.Windows.Properties.Resources.Cancelar;
            this.CancelarButton.Location = new System.Drawing.Point(649, 382);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(99, 56);
            this.CancelarButton.TabIndex = 7;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Image = global::PizzeriaEdiMVC.Windows.Properties.Resources.Aceptar;
            this.OKButton.Location = new System.Drawing.Point(296, 382);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(99, 56);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // BuscarImagenButton
            // 
            this.BuscarImagenButton.Image = global::PizzeriaEdiMVC.Windows.Properties.Resources.search_24px;
            this.BuscarImagenButton.Location = new System.Drawing.Point(686, 291);
            this.BuscarImagenButton.Name = "BuscarImagenButton";
            this.BuscarImagenButton.Size = new System.Drawing.Size(269, 53);
            this.BuscarImagenButton.TabIndex = 5;
            this.BuscarImagenButton.Text = "Buscar Imagen";
            this.BuscarImagenButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BuscarImagenButton.UseVisualStyleBackColor = true;
            this.BuscarImagenButton.Click += new System.EventHandler(this.BuscarImagenButton_Click);
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagePictureBox.Location = new System.Drawing.Point(686, 39);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(269, 246);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagePictureBox.TabIndex = 26;
            this.ImagePictureBox.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmProductosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 467);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.BuscarImagenButton);
            this.Controls.Add(this.ImagePictureBox);
            this.Controls.Add(this.ActivoCheckBox);
            this.Controls.Add(this.TipoProductoComboBox);
            this.Controls.Add(this.DetallesTextBox);
            this.Controls.Add(this.PrecioTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DescripcionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmProductosAE";
            this.Text = "FrmProductosAE";
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BuscarImagenButton;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.CheckBox ActivoCheckBox;
        private System.Windows.Forms.ComboBox TipoProductoComboBox;
        private System.Windows.Forms.TextBox DetallesTextBox;
        private System.Windows.Forms.TextBox PrecioTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}