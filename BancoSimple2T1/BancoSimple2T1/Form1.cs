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
            //El uso del try, previene que la aplicacion se bloquee si hay un error en la conexion a la base de datos
            //o un problema con los datos; si lo hay informara del problema al usuario con un mensaje.
            try
            {
                dgvClientes.DataSource = _servicio.ObtenerClientes();
                dgvCuentas.DataSource = _servicio.ObtenerCuentasActivas();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la informacion: " + ex.Message);

            }
           
        }

        //Este boton sirve para agregar a cada uno de los clientes
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new AgregarClienteForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _db.Cliente.Add(form.NuevoCliente);
                    _db.SaveChanges();
                    CargarInformacion();
                    MessageBox.Show("Cliente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Error al guardar en la base de datos. Verifique los datos ingresados.", "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //Este boton sirve para agregar las cuentas de cada cliente
        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarSeleccion(dgvClientes, 1, "Seleccione un cliente primero"))
                    return;

                var clienteId = ObtenerIdSeleccionado(dgvClientes, "ClienteId");

                if (clienteId == null)
                {
                    MessageBox.Show("No se pudo obtener el ID del cliente seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var form = new AgregarCuentaForm(clienteId);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _servicio.AgregarCuenta(form.NuevaCuenta);
                        MessageBox.Show("Cuenta agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarInformacion();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Datos inválidos: {ex.Message}", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"Operación no permitida: {ex.Message}", "Error de operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado al agregar la cuenta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        //Este boton sirve para transferir el dinero de una cuenta a otra
        //teniendo en cuenta las dos cuentas seleccionadas
        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya exactamente 2 cuentas seleccionadas
                if (!ValidarSeleccion(dgvCuentas, 2, "Seleccione exactamente 2 cuentas"))
                    return;

                var cuentaOrigenId = ObtenerIdSeleccionado(dgvCuentas, "CuentaId", indexFila: 1);
                var cuentaDestinoId = ObtenerIdSeleccionado(dgvCuentas, "CuentaId", indexFila: 0);

                if (cuentaOrigenId == null || cuentaDestinoId == null)
                {
                    MessageBox.Show("No se pudieron obtener los IDs de las cuentas seleccionadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var form = new TransaccionesForms(cuentaOrigenId, cuentaDestinoId);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _servicio.RealizarTransferencia(cuentaOrigenId, cuentaDestinoId, form.Monto);
                        MessageBox.Show("Transferencia realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarInformacion();
                    }
                    catch (InvalidOperationException ex)
                    {
                        if (ex.Message.Contains("insuficiente", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Monto insuficiente en la cuenta origen.", "Fondos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show($"Operación inválida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Parámetro incorrecto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ha ocurrido un error al realizar la transferencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Este boton ayuda a desactivar la cuenta de un cliente que esta activa
        //y que talvez ya no la usara
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarSeleccion(dgvCuentas, 1, "Seleccione solo una cuenta exactamente"))
                    return;

                var cuentaId = ObtenerIdSeleccionado(dgvCuentas, "CuentaId");

                if (cuentaId == null)
                {
                    MessageBox.Show("No se pudo obtener el ID de la cuenta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _servicio.DesactivarCuenta(cuentaId);
                MessageBox.Show("Cuenta desactivada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInformacion();
            }
            catch (InvalidOperationException ex)
            {
                // Ejemplo: cuenta ya está desactivada o no se puede desactivar por alguna regla de negocio
                MessageBox.Show($"No se puede desactivar la cuenta: {ex.Message}", "Operación inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (KeyNotFoundException ex)
            {
                // Ejemplo: cuenta no encontrada
                MessageBox.Show($"Cuenta no encontrada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al desactivar cuenta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Este boton sirve para buscar el nombre del ciente que se require encontrar
        //dentro de la tabla de clientes del form1
        private void btnBuscarCliente_Click_1(object sender, EventArgs e)
        {
            try
            {
                var patron = txtBuscarCliente.Text;

                if (string.IsNullOrWhiteSpace(patron))
                {
                    MessageBox.Show("Por favor, ingrese al menos una letra del nombre del cliente a buscar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var clientes = _db.Cliente
                    .Where(c => EF.Functions.Like(c.Nombre, $"%{patron}%"))
                    .ToList();

                if (clientes.Count == 0)
                {
                    MessageBox.Show(" Lo siento,No se encontraron clientes con ese nombre.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvClientes.DataSource = null; // Limpia el grid si no hay resultados
                }
                else
                {
                    dgvClientes.DataSource = clientes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
