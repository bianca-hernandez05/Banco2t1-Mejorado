using BancoSimple2T1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSimple2T1
{
    public partial class VerTransferenciaForms : Form
    {
		// Instancia de BancoSimpleContext para acceder a la base de datos con _db.
		private readonly BancoSimpleContext _db = new();
		public VerTransferenciaForms()
        {
            InitializeComponent();
            CargarTransferencias();
        }

        //Este metodo nos ayuda a ver las transferencias que se hicieron durante la ejecucion
        //del programa
        private void CargarTransferencias()
        {
            dgvTransferencias.DataSource = _db.Transacciones.ToList();
        }

        private void VerTransferenciaForms_Load(object sender, EventArgs e)
        {

        }
    }
}
