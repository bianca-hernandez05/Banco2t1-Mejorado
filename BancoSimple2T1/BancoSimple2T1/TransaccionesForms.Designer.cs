namespace BancoSimple2T1
{
    partial class TransaccionesForms
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
            lblOrigen = new Label();
            btnAceptar = new Button();
            lblMonto = new Label();
            lblDestino = new Label();
            btnCancelar = new Button();
            lblDisponible = new Label();
            txtSaldo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblOrigen.Location = new Point(132, 9);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(39, 15);
            lblOrigen.TabIndex = 0;
            lblOrigen.Text = "label1";
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.ActiveBorder;
            btnAceptar.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(12, 165);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(228, 31);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblMonto.Location = new Point(12, 50);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(41, 15);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Monto";
            // 
            // lblDestino
            // 
            lblDestino.AutoSize = true;
            lblDestino.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblDestino.Location = new Point(132, 116);
            lblDestino.Name = "lblDestino";
            lblDestino.Size = new Size(39, 15);
            lblDestino.TabIndex = 4;
            lblDestino.Text = "label3";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(255, 192, 192);
            btnCancelar.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(316, 192);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(93, 41);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblDisponible
            // 
            lblDisponible.AutoSize = true;
            lblDisponible.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDisponible.Location = new Point(251, 83);
            lblDisponible.Name = "lblDisponible";
            lblDisponible.Size = new Size(98, 15);
            lblDisponible.TabIndex = 6;
            lblDisponible.Text = "Monto disponible";
            // 
            // txtSaldo
            // 
            txtSaldo.Location = new Point(81, 47);
            txtSaldo.Margin = new Padding(3, 2, 3, 2);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.Size = new Size(110, 23);
            txtSaldo.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 116);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 8;
            label1.Text = "Cuenta Destino";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 9;
            label2.Text = "Cuenta Origen";
            // 
            // TransaccionesForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(458, 244);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSaldo);
            Controls.Add(lblDisponible);
            Controls.Add(btnCancelar);
            Controls.Add(lblDestino);
            Controls.Add(lblMonto);
            Controls.Add(btnAceptar);
            Controls.Add(lblOrigen);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TransaccionesForms";
            Text = "TransaccionesForms";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrigen;
        private Button btnAceptar;
        private Label lblMonto;
        private Label lblDestino;
        private Button btnCancelar;
        private Label lblDisponible;
        private TextBox txtSaldo;
        private Label label1;
        private Label label2;
    }
}