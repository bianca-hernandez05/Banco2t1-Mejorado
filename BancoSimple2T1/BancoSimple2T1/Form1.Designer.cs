namespace BancoSimple2T1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvClientes = new DataGridView();
            btnAgregarCliente = new Button();
            dgvCuentas = new DataGridView();
            btnAgregarCuenta = new Button();
            label1 = new Label();
            label2 = new Label();
            btnTransferencia = new Button();
            btnBuscarCliente = new Button();
            txtBuscarCliente = new TextBox();
            btnVerTransferencia = new Button();
            btnDesactivar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.BackgroundColor = SystemColors.ControlLightLight;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 88);
            dgvClientes.Margin = new Padding(3, 2, 3, 2);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(347, 215);
            dgvClientes.TabIndex = 0;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.BackColor = SystemColors.ActiveCaption;
            btnAgregarCliente.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarCliente.Location = new Point(12, 317);
            btnAgregarCliente.Margin = new Padding(3, 2, 3, 2);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(170, 29);
            btnAgregarCliente.TabIndex = 1;
            btnAgregarCliente.Text = "AgregarCliente";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // dgvCuentas
            // 
            dgvCuentas.BackgroundColor = SystemColors.ControlLightLight;
            dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCuentas.Location = new Point(424, 34);
            dgvCuentas.Margin = new Padding(3, 2, 3, 2);
            dgvCuentas.Name = "dgvCuentas";
            dgvCuentas.RowHeadersWidth = 51;
            dgvCuentas.Size = new Size(518, 215);
            dgvCuentas.TabIndex = 2;
            // 
            // btnAgregarCuenta
            // 
            btnAgregarCuenta.BackColor = SystemColors.ActiveCaption;
            btnAgregarCuenta.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarCuenta.Location = new Point(413, 253);
            btnAgregarCuenta.Margin = new Padding(3, 2, 3, 2);
            btnAgregarCuenta.Name = "btnAgregarCuenta";
            btnAgregarCuenta.Size = new Size(168, 29);
            btnAgregarCuenta.TabIndex = 3;
            btnAgregarCuenta.Text = "AgregarCuenta";
            btnAgregarCuenta.UseVisualStyleBackColor = false;
            btnAgregarCuenta.Click += btnAgregarCuenta_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 60);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 4;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(424, 16);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 5;
            label2.Text = "Cuenta";
            // 
            // btnTransferencia
            // 
            btnTransferencia.BackColor = Color.FromArgb(192, 255, 192);
            btnTransferencia.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTransferencia.Location = new Point(502, 359);
            btnTransferencia.Margin = new Padding(3, 2, 3, 2);
            btnTransferencia.Name = "btnTransferencia";
            btnTransferencia.Size = new Size(125, 43);
            btnTransferencia.TabIndex = 6;
            btnTransferencia.Text = "Transferencia";
            btnTransferencia.UseVisualStyleBackColor = false;
            btnTransferencia.Click += btnTransferencia_Click;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.BackColor = Color.Transparent;
            btnBuscarCliente.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscarCliente.Location = new Point(12, 11);
            btnBuscarCliente.Margin = new Padding(3, 2, 3, 2);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(127, 26);
            btnBuscarCliente.TabIndex = 7;
            btnBuscarCliente.Text = "Buscar Cliente";
            btnBuscarCliente.UseVisualStyleBackColor = false;
            btnBuscarCliente.Click += btnBuscarCliente_Click_1;
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(145, 13);
            txtBuscarCliente.Margin = new Padding(3, 2, 3, 2);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(214, 23);
            txtBuscarCliente.TabIndex = 8;
            // 
            // btnVerTransferencia
            // 
            btnVerTransferencia.BackColor = Color.FromArgb(192, 192, 255);
            btnVerTransferencia.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerTransferencia.Location = new Point(651, 359);
            btnVerTransferencia.Margin = new Padding(3, 2, 3, 2);
            btnVerTransferencia.Name = "btnVerTransferencia";
            btnVerTransferencia.Size = new Size(125, 43);
            btnVerTransferencia.TabIndex = 9;
            btnVerTransferencia.Text = "Ver Transferencia";
            btnVerTransferencia.UseVisualStyleBackColor = false;
            btnVerTransferencia.Click += btnVerTransferencia_Click_1;
            // 
            // btnDesactivar
            // 
            btnDesactivar.BackColor = Color.FromArgb(255, 192, 192);
            btnDesactivar.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDesactivar.Location = new Point(801, 359);
            btnDesactivar.Margin = new Padding(3, 2, 3, 2);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(125, 43);
            btnDesactivar.TabIndex = 10;
            btnDesactivar.Text = "Desactivar Cuenta";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(954, 413);
            Controls.Add(btnDesactivar);
            Controls.Add(btnVerTransferencia);
            Controls.Add(txtBuscarCliente);
            Controls.Add(btnBuscarCliente);
            Controls.Add(btnTransferencia);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAgregarCuenta);
            Controls.Add(dgvCuentas);
            Controls.Add(btnAgregarCliente);
            Controls.Add(dgvClientes);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
         
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientes;
        private Button btnAgregarCliente;
        private DataGridView dgvCuentas;
        private Button btnAgregarCuenta;
        private Label label1;
        private Label label2;
        private Button btnTransferencia;
        private Button btnBuscarCliente;
        private TextBox txtBuscarCliente;
        private Button btnVerTransferencia;
        private Button btnDesactivar;
    }
}
