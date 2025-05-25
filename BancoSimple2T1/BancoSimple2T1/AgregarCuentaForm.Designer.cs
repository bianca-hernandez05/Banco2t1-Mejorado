namespace BancoSimple2T1
{
    partial class AgregarCuentaForm
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
            label1 = new Label();
            label2 = new Label();
            txtNumeroCuenta = new TextBox();
            numSaldoInicial = new NumericUpDown();
            btnAceptar = new Button();
            ((System.ComponentModel.ISupportInitialize)numSaldoInicial).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label1.Location = new Point(7, 20);
            label1.Name = "label1";
            label1.Size = new Size(128, 17);
            label1.TabIndex = 0;
            label1.Text = "Numero de cuenta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label2.Location = new Point(7, 56);
            label2.Name = "label2";
            label2.Size = new Size(87, 17);
            label2.TabIndex = 1;
            label2.Text = "Saldo Inicial";
            // 
            // txtNumeroCuenta
            // 
            txtNumeroCuenta.Location = new Point(143, 20);
            txtNumeroCuenta.Margin = new Padding(3, 2, 3, 2);
            txtNumeroCuenta.Name = "txtNumeroCuenta";
            txtNumeroCuenta.Size = new Size(145, 23);
            txtNumeroCuenta.TabIndex = 2;
            // 
            // numSaldoInicial
            // 
            numSaldoInicial.Location = new Point(143, 54);
            numSaldoInicial.Margin = new Padding(3, 2, 3, 2);
            numSaldoInicial.Name = "numSaldoInicial";
            numSaldoInicial.Size = new Size(145, 23);
            numSaldoInicial.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.ActiveBorder;
            btnAceptar.Location = new Point(30, 135);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(272, 32);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // AgregarCuentaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(331, 206);
            Controls.Add(btnAceptar);
            Controls.Add(numSaldoInicial);
            Controls.Add(txtNumeroCuenta);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AgregarCuentaForm";
            Text = "Agregar Cuenta";
            ((System.ComponentModel.ISupportInitialize)numSaldoInicial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNumeroCuenta;
        private NumericUpDown numSaldoInicial;
        private Button btnAceptar;
    }
}