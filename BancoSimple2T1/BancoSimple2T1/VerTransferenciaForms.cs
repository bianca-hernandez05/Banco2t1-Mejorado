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
        //Aqui mandamos a llamar a la clase BancoSimpleContext mediante
        //una instancia para tener conexion mediante el objeto (con)
        private BancoSimpleContext con = new BancoSimpleContext();
        public VerTransferenciaForms()
        {
            InitializeComponent();
            CargarTransferencias();
        }

        //Este metodo nos ayuda a ver las transferencias que se hicieron durante la ejecucion
        //del programa
        private void CargarTransferencias()
        {
            dgvTransferencias.DataSource = con.Transacciones.ToList();
        }

        private void VerTransferenciaForms_Load(object sender, EventArgs e)
        {

        }
    }
}
