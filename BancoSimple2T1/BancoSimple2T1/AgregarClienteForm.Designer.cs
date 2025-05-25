namespace BancoSimple2T1
{
    partial class AgregarClienteForm
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
            txtNombre = new TextBox();
            btnAceptar = new Button();
            txtIdentificacion = new TextBox();
            label2 = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label1.Location = new Point(22, 10);
            label1.Name = "label1";
            label1.Size = new Size(61, 17);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(150, 8);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(152, 23);
            txtNombre.TabIndex = 1;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.ActiveBorder;
            btnAceptar.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(12, 104);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(301, 32);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(150, 54);
            txtIdentificacion.Margin = new Padding(3, 2, 3, 2);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(152, 23);
            txtIdentificacion.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label2.Location = new Point(22, 54);
            label2.Name = "label2";
            label2.Size = new Size(96, 17);
            label2.TabIndex = 3;
            label2.Text = "Identificacion";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(255, 192, 192);
            btnCancelar.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(258, 165);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 38);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AgregarClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(368, 214);
            Controls.Add(btnCancelar);
            Controls.Add(txtIdentificacion);
            Controls.Add(label2);
            Controls.Add(btnAceptar);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AgregarClienteForm";
            Text = "Agregar Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Button btnAceptar;
        private TextBox txtIdentificacion;
        private Label label2;
        private Button btnCancelar;
    }
}