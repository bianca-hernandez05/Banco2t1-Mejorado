using BancoSimple2T1.Data;
using BancoSimple2T1.Models;
using Microsoft.EntityFrameworkCore;
namespace BancoSimple2T1
    
{
    public partial class Form1 : Form
    {
        //Creamos una instancia de la clase BancoSimpleContext
        //para tener acceso a cada una de las clases (Tablas)

        private BancoSimpleContext _db = new BancoSimpleContext();
        public Form1()
        {
            InitializeComponent();
            CargarInformacion();
        }

        //Metodo para cargar la informacion
        private void CargarInformacion()
        {
            dgvClientes.DataSource = _db.Cliente.ToList();
            var cuenta = _db.Cuenta.
                Include(c => c.cliente).Where(c => c.Activa).
                Select(c => new
                {
                    c.CuentaId,
                    c.NumeroCuenta,
                    c.Saldo,
                    NombreCliente = c.cliente.Nombre,
                    c.Activa,
                    c.ClienteId
                }).ToList();
            dgvCuentas.DataSource = cuenta;
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
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente primero");
                return;
            }
            var clienteId = (int)dgvClientes.SelectedRows[0].Cells["ClienteId"].Value;
            var form = new AgregarCuentaForm(clienteId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _db.Cuenta.Add(form.NuevaCuenta);
                _db.SaveChanges();
                CargarInformacion();
            }
        }

        //Este metodo sirve para realizar las transaaciones (de dinero)
        //de la cuenta de un cliente a otra cuenta de otro cliente
        private void RealizarTransaccion(int cuentaOrigenId, int cuentaDestinoId, decimal monto)
        {

            using var transferencia = _db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                //Filtro y ordenacion
                var cuentaOrigen = _db.Cuenta.FirstOrDefault(c => c.CuentaId == cuentaOrigenId);
                var cuentaDestino = _db.Cuenta.FirstOrDefault(c => c.CuentaId == cuentaDestinoId);

                //Aqui se verifica si la cantidad del monnto de x cuenta es la adecuada 
                //para poder transferir a otra cuenta (monto suficiente)

                if (cuentaOrigen == null || cuentaDestino == null)
                    throw new Exception("Una o ambas cuentas no existen");

                if (!cuentaOrigen.Activa || !cuentaDestino.Activa)
                    throw new Exception("Una o ambas cuentas están inactivas");
                if (cuentaOrigen.Saldo < monto)
                    throw new Exception("Saldo Insuficiente en la cuenta Origen");

                cuentaOrigen.Saldo -= monto;
                cuentaDestino.Saldo += monto;

                //Aqui se registra la transaccion
                _db.Transacciones.Add(new Transaccion
                {
                    Monto = monto,
                    Fecha = DateTime.Now,
                    Descripcion = "Transferencia entre cuentas",
                    CuentaOrigenId = cuentaOrigenId,
                    CuentaDestinoId = cuentaDestinoId
                });

                _db.SaveChanges();

                //Aqui esta completada la Transaccion 
                transferencia.Commit();
                MessageBox.Show("Transferencia realizada");
                CargarInformacion();


            }
            catch (Exception ex)
            {
                transferencia.Rollback();

                var inner = ex.InnerException?.Message ?? "No hay InnerException";
                MessageBox.Show($"Error al guardar:\n{ex.Message}\n\nDetalle:\n{inner}");
            }

        }

        //Este boton sirve para transferir el dinero de una cuenta a otra
        //teniendo en cuenta las dos cuentas seleccionadas
        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count != 2)
            {
                MessageBox.Show("Seleccione exactamente 2 cuentas");
                return;
            }
            var cuentaOrigenId = (int)dgvCuentas.SelectedRows[1].Cells["CuentaId"].Value;
            var cuentaDestinoId = (int)dgvCuentas.SelectedRows[0].Cells["CuentaId"].Value;

            var form = new TransaccionesForms(cuentaOrigenId, cuentaDestinoId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RealizarTransaccion(cuentaOrigenId, cuentaDestinoId, form.Monto);
            }

        }

        //Este boton ayuda a desactivar la cuenta de un cliente que esta activa
        //y que talvez ya no la usara
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecciones solo una cuenta exactamente");
                return;
            }
            else
            {
                var cuentaId = (int)dgvCuentas.SelectedRows[0].Cells["CuentaId"].Value;
                var cuenta = _db.Cuenta.Find(cuentaId);
                cuenta.Activa = false;
                _db.SaveChanges();
                CargarInformacion();
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

       
    }
}
