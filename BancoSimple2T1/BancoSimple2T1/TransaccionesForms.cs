using BancoSimple2T1.Data;
using BancoSimple2T1.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class TransaccionesForms : Form
    {
        public decimal Monto { get; private set; }

        //Se necesita 2 variables la cuenta que va a tranferir (dinero) y la 
        // cuenta que va a obtener el dinero

        private int _cuentaOrigenId;
        private int _cuentaDestinoId;

        //Llamamos a la clase BancoSimpleContext y creamos un objeto para comunicacion (db)
        private BancoSimpleContext db;

        //Para la ejecucion de este formulario se necesita la cuenta a transferir y la que 
        //obtendra la transferencia
        public TransaccionesForms(int cuentaOrigenId, int cuentaDestinoId)
        {
            InitializeComponent();
            _cuentaOrigenId = cuentaOrigenId;
            _cuentaDestinoId = cuentaDestinoId;

            db = new BancoSimpleContext();
            CargarInformacionCuenta();

        }

        //Este metodo nos ayuda a cargar la informacion de la transaccion
        //teniendo en cuenta losnombres de las personas y el mosto a transferir y a resivir
        private void CargarInformacionCuenta()
        {
			// CAMBIO: con el nuevo metodo
			var cuentaOrigen = ObtenerCuentaConCliente(_cuentaOrigenId);
			var cuentaDestino = ObtenerCuentaConCliente(_cuentaDestinoId);

			lblOrigen.Text = $"Nombre: {cuentaOrigen.cliente.Nombre} cuenta {cuentaOrigen.NumeroCuenta}";
            lblDestino.Text = $"Nombre: {cuentaDestino.cliente.Nombre} cuenta {cuentaDestino.NumeroCuenta}";
            lblDisponible.Text = $"Saldo Disponible : {cuentaOrigen.Saldo:c}";
        }

        //Este boton nos ayuda para aceptar la transaccion que se quiere realizar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtSaldo.Text, out decimal monto) && monto > 0)
            {
                Monto = monto;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ingrese un monto mayor a 0");
            }

        }

        //Este boton nos ayuda a cancelar la transaccion que ya no se quiere realizar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
		// CAMBIO: metodo para obtener la cuenta con su cliente
		private Cuenta ObtenerCuentaConCliente(int cuentaId)
		{
			return db.Cuenta.Include(c => c.cliente).First(c => c.CuentaId == cuentaId);
		}


	}
}
