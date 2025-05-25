using BancoSimple2T1.Models;
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
    public partial class AgregarCuentaForm : Form
    {
        //Aqui mandamos a llamar a la clase cuenta para crear una cuenta cuenta para un cliente
        public Cuenta NuevaCuenta { get; private set; }
        private int _clienteId;

        //en este metodo se necesita el id del cliente al que queremos agregarle 
        //una nueva cuenta
        public AgregarCuentaForm(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
        }

        //Este boton se utiliza para aceptar de que estamos agregando
        //una nueva cuenta a un cliente en especifico
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumeroCuenta.Text))
                {
                    MessageBox.Show("El número de cuenta es requerido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NuevaCuenta = new Cuenta
                {
                    NumeroCuenta = txtNumeroCuenta.Text,
                    Saldo = numSaldoInicial.Value,
                    ClienteId = _clienteId,
                    Activa = true
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Formato inválido: " + ex.Message, "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Operación inválida: " + ex.Message, "Error de operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
