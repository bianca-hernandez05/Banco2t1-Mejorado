namespace BancoSimple2T1
{
    partial class VerTransferenciaForms
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
            dgvTransferencias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTransferencias).BeginInit();
            SuspendLayout();
            // 
            // dgvTransferencias
            // 
            dgvTransferencias.BackgroundColor = SystemColors.ControlLightLight;
            dgvTransferencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransferencias.Location = new Point(26, 27);
            dgvTransferencias.Margin = new Padding(3, 2, 3, 2);
            dgvTransferencias.Name = "dgvTransferencias";
            dgvTransferencias.RowHeadersWidth = 51;
            dgvTransferencias.Size = new Size(536, 249);
            dgvTransferencias.TabIndex = 0;
            // 
            // VerTransferenciaForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(610, 338);
            Controls.Add(dgvTransferencias);
            Margin = new Padding(3, 2, 3, 2);
            Name = "VerTransferenciaForms";
            Text = "Transferencia Cliente";
            Load += VerTransferenciaForms_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTransferencias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTransferencias;
    }
}