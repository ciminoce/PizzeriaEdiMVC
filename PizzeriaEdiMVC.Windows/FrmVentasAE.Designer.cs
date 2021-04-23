
namespace PizzeriaEdiMVC.Windows
{
    partial class FrmVentasAE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ProductosComboBox = new System.Windows.Forms.ComboBox();
            this.TiposComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CantidadNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PrecioUnitTextBox = new System.Windows.Forms.TextBox();
            this.CancelarProductoButton = new System.Windows.Forms.Button();
            this.AceptarProductoButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.PrecioTotalTextBox = new System.Windows.Forms.TextBox();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.TotalPedidoTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PedidoDataGridView = new System.Windows.Forms.DataGridView();
            this.cmnProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBorrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmnEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PedidoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CancelarButton);
            this.splitContainer1.Panel2.Controls.Add(this.OKButton);
            this.splitContainer1.Panel2.Controls.Add(this.TotalPedidoTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.PedidoDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(873, 481);
            this.splitContainer1.SplitterDistance = 163;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ProductosComboBox);
            this.groupBox3.Controls.Add(this.TiposComboBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.CantidadNumericUpDown);
            this.groupBox3.Controls.Add(this.PrecioUnitTextBox);
            this.groupBox3.Controls.Add(this.CancelarProductoButton);
            this.groupBox3.Controls.Add(this.AceptarProductoButton);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.PrecioTotalTextBox);
            this.groupBox3.Location = new System.Drawing.Point(25, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(825, 129);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Producto ";
            // 
            // ProductosComboBox
            // 
            this.ProductosComboBox.Enabled = false;
            this.ProductosComboBox.FormattingEnabled = true;
            this.ProductosComboBox.Location = new System.Drawing.Point(72, 50);
            this.ProductosComboBox.Name = "ProductosComboBox";
            this.ProductosComboBox.Size = new System.Drawing.Size(309, 21);
            this.ProductosComboBox.TabIndex = 2;
            this.ProductosComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductosComboBox_SelectedIndexChanged);
            // 
            // TiposComboBox
            // 
            this.TiposComboBox.FormattingEnabled = true;
            this.TiposComboBox.Location = new System.Drawing.Point(72, 20);
            this.TiposComboBox.Name = "TiposComboBox";
            this.TiposComboBox.Size = new System.Drawing.Size(258, 21);
            this.TiposComboBox.TabIndex = 1;
            this.TiposComboBox.SelectedIndexChanged += new System.EventHandler(this.TiposComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Producto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Tipo:";
            // 
            // CantidadNumericUpDown
            // 
            this.CantidadNumericUpDown.Location = new System.Drawing.Point(453, 21);
            this.CantidadNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CantidadNumericUpDown.Name = "CantidadNumericUpDown";
            this.CantidadNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.CantidadNumericUpDown.TabIndex = 29;
            this.CantidadNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PrecioUnitTextBox
            // 
            this.PrecioUnitTextBox.Location = new System.Drawing.Point(72, 77);
            this.PrecioUnitTextBox.Name = "PrecioUnitTextBox";
            this.PrecioUnitTextBox.Size = new System.Drawing.Size(94, 20);
            this.PrecioUnitTextBox.TabIndex = 2;
            // 
            // CancelarProductoButton
            // 
            this.CancelarProductoButton.Location = new System.Drawing.Point(715, 75);
            this.CancelarProductoButton.Name = "CancelarProductoButton";
            this.CancelarProductoButton.Size = new System.Drawing.Size(96, 43);
            this.CancelarProductoButton.TabIndex = 4;
            this.CancelarProductoButton.Text = "Cancelar";
            this.CancelarProductoButton.UseVisualStyleBackColor = true;
            this.CancelarProductoButton.Click += new System.EventHandler(this.CancelarProductoButton_Click);
            // 
            // AceptarProductoButton
            // 
            this.AceptarProductoButton.Location = new System.Drawing.Point(715, 19);
            this.AceptarProductoButton.Name = "AceptarProductoButton";
            this.AceptarProductoButton.Size = new System.Drawing.Size(95, 43);
            this.AceptarProductoButton.TabIndex = 3;
            this.AceptarProductoButton.Text = "Aceptar";
            this.AceptarProductoButton.UseVisualStyleBackColor = true;
            this.AceptarProductoButton.Click += new System.EventHandler(this.AceptarProductoButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(398, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Cantidad:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(383, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Precio Total:";
            // 
            // PrecioTotalTextBox
            // 
            this.PrecioTotalTextBox.Location = new System.Drawing.Point(456, 50);
            this.PrecioTotalTextBox.Name = "PrecioTotalTextBox";
            this.PrecioTotalTextBox.ReadOnly = true;
            this.PrecioTotalTextBox.Size = new System.Drawing.Size(92, 20);
            this.PrecioTotalTextBox.TabIndex = 4;
            this.PrecioTotalTextBox.TabStop = false;
            this.PrecioTotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CancelarButton
            // 
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Location = new System.Drawing.Point(477, 248);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(102, 50);
            this.CancelarButton.TabIndex = 1;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(239, 248);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(102, 50);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // TotalPedidoTextBox
            // 
            this.TotalPedidoTextBox.Location = new System.Drawing.Point(655, 234);
            this.TotalPedidoTextBox.Name = "TotalPedidoTextBox";
            this.TotalPedidoTextBox.ReadOnly = true;
            this.TotalPedidoTextBox.Size = new System.Drawing.Size(116, 20);
            this.TotalPedidoTextBox.TabIndex = 70;
            this.TotalPedidoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(603, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Total:";
            // 
            // PedidoDataGridView
            // 
            this.PedidoDataGridView.AllowUserToAddRows = false;
            this.PedidoDataGridView.AllowUserToDeleteRows = false;
            this.PedidoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PedidoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnProducto,
            this.cmnPrecioUnitario,
            this.cmnCantidad,
            this.cmnTotal,
            this.btnBorrar,
            this.cmnEditar});
            this.PedidoDataGridView.Location = new System.Drawing.Point(25, 19);
            this.PedidoDataGridView.MultiSelect = false;
            this.PedidoDataGridView.Name = "PedidoDataGridView";
            this.PedidoDataGridView.ReadOnly = true;
            this.PedidoDataGridView.RowHeadersVisible = false;
            this.PedidoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PedidoDataGridView.Size = new System.Drawing.Size(825, 209);
            this.PedidoDataGridView.TabIndex = 68;
            // 
            // cmnProducto
            // 
            this.cmnProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnProducto.HeaderText = "Producto";
            this.cmnProducto.Name = "cmnProducto";
            this.cmnProducto.ReadOnly = true;
            // 
            // cmnPrecioUnitario
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnPrecioUnitario.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmnPrecioUnitario.HeaderText = "Precio Unitario";
            this.cmnPrecioUnitario.Name = "cmnPrecioUnitario";
            this.cmnPrecioUnitario.ReadOnly = true;
            // 
            // cmnCantidad
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnCantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.cmnCantidad.HeaderText = "Cantidad";
            this.cmnCantidad.Name = "cmnCantidad";
            this.cmnCantidad.ReadOnly = true;
            // 
            // cmnTotal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.cmnTotal.HeaderText = "Total";
            this.cmnTotal.Name = "cmnTotal";
            this.cmnTotal.ReadOnly = true;
            // 
            // btnBorrar
            // 
            this.btnBorrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.btnBorrar.HeaderText = "Borrar";
            this.btnBorrar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.ReadOnly = true;
            this.btnBorrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnBorrar.Width = 41;
            // 
            // cmnEditar
            // 
            this.cmnEditar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnEditar.HeaderText = "Editar";
            this.cmnEditar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.cmnEditar.Name = "cmnEditar";
            this.cmnEditar.ReadOnly = true;
            this.cmnEditar.Width = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Precio Unit:";
            // 
            // FrmVentasAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 481);
            this.Controls.Add(this.splitContainer1);
            this.MaximumSize = new System.Drawing.Size(889, 520);
            this.MinimumSize = new System.Drawing.Size(889, 520);
            this.Name = "FrmVentasAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVentasAE";
            this.Load += new System.EventHandler(this.FrmVentasAE_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PedidoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ProductosComboBox;
        private System.Windows.Forms.ComboBox TiposComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown CantidadNumericUpDown;
        private System.Windows.Forms.TextBox PrecioUnitTextBox;
        private System.Windows.Forms.Button CancelarProductoButton;
        private System.Windows.Forms.Button AceptarProductoButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox PrecioTotalTextBox;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox TotalPedidoTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView PedidoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTotal;
        private System.Windows.Forms.DataGridViewImageColumn btnBorrar;
        private System.Windows.Forms.DataGridViewImageColumn cmnEditar;
        private System.Windows.Forms.Label label9;
    }
}