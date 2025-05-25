using BancoSimple2T1.Data;
using BancoSimple2T1.Models;
using BancoSimple2T1.Services;
using Microsoft.EntityFrameworkCore;
namespace BancoSimple2T1
    
{
    public partial class Form1 : Form
    {
		// Instancia de BancoSimpleContext para acceder a la base de datos con _db.
		private readonly BancoSimpleContext _db = new();
        // Instancia de BancoServices para acceder a los servicios de banco.
        private BancoServices _servicio = new BancoServices();
        public Form1()
        {
            InitializeComponent();
            CargarInformacion();
        }

        //Metodo para cargar la informacion
        private void CargarInformacion()
        {
            dgvClientes.DataSource = _servicio.ObtenerClientes();
            dgvCuentas.DataSource = _servicio.ObtenerCuentasActivas();
        }

        //Este boton sirve para agregar a cada uno de los clientes
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            var form = new AgregarClienteForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _db.Cliente.Add(form.NuevoCliente);
                _db.SaveChanges();
                CargarInformacion();

            }
        }

        //Este boton sirve para agregar las cuentas de cada cliente
        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion(dgvClientes, 1, "Seleccione un cliente primero"))
                return;

            var clienteId = ObtenerIdSeleccionado(dgvClientes, "ClienteId");
            var form = new AgregarCuentaForm(clienteId);

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _servicio.AgregarCuenta(form.NuevaCuenta);
                    MessageBox.Show("Cuenta agregada con éxito.");
                    CargarInformacion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar cuenta: {ex.Message}");
                }
            }
        }

      

        //Este boton sirve para transferir el dinero de una cuenta a otra
        //teniendo en cuenta las dos cuentas seleccionadas
        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion(dgvCuentas, 2, "Seleccione exactamente 2 cuentas"))
                return;

            var cuentaOrigenId = ObtenerIdSeleccionado(dgvCuentas, "CuentaId", indexFila: 1);
            var cuentaDestinoId = ObtenerIdSeleccionado(dgvCuentas, "CuentaId", indexFila: 0);

            var form = new TransaccionesForms(cuentaOrigenId, cuentaDestinoId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _servicio.RealizarTransferencia(cuentaOrigenId, cuentaDestinoId, form.Monto);
                    MessageBox.Show("Transferencia realizada con éxito.");
                    CargarInformacion(); // Recarga después de cambios
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

        }

        //Este boton ayuda a desactivar la cuenta de un cliente que esta activa
        //y que talvez ya no la usara
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion(dgvCuentas, 1, "Seleccione solo una cuenta exactamente"))
                return;

            var cuentaId = ObtenerIdSeleccionado(dgvCuentas, "CuentaId");

            try
            {
                _servicio.DesactivarCuenta(cuentaId);
                MessageBox.Show("Cuenta desactivada correctamente.");
                CargarInformacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desactivar cuenta: {ex.Message}");
            }
        }

        //Este boton sirve para buscar el nombre del ciente que se require encontrar
        //dentro de la tabla de clientes del form1
        private void btnBuscarCliente_Click_1(object sender, EventArgs e)
        {
            //Busqueda de patrones con like
            var patron = txtBuscarCliente.Text;
            var cliente = _db.Cliente.Where(c => EF.Functions.Like(c.Nombre, $"%{patron}%")).ToList();

            dgvClientes.DataSource = cliente;

        }

        //Este boton nos ayuda a poder identificar las tranferencias que se han hecho 
        //durante la ejecucion del programa
        private void btnVerTransferencia_Click_1(object sender, EventArgs e)
        {
            var form = new VerTransferenciaForms();
            form.ShowDialog();

        }
		// Método para validar la selección en un DataGridView
		private bool ValidarSeleccion(DataGridView dgv, int cantidadEsperada, string mensajeError)
		{
			if (dgv.SelectedRows.Count != cantidadEsperada)
			{
				MessageBox.Show(mensajeError);
				return false;
			}
			return true;
		}

		// Método para obtener el Id seleccionado en un DataGridView, columna dada
		private int ObtenerIdSeleccionado(DataGridView dgv, string nombreColumna)
		{
			return (int)dgv.SelectedRows[0].Cells[nombreColumna].Value;
		}

		// Método para guardar cambios y recargar datos
		private void GuardarYCargar()
		{
			_db.SaveChanges();
			CargarInformacion();
		}

		// Sobrecarga método ObtenerIdSeleccionado para fila específica
		private int ObtenerIdSeleccionado(DataGridView dgv, string nombreColumna, int indexFila)
		{
			return (int)dgv.SelectedRows[indexFila].Cells[nombreColumna].Value;
		}


	}
}
