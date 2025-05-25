using BancoSimple2T1.Data;
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
    public partial class AgregarClienteForm : Form
    {
        private BancoSimpleContext _db = new BancoSimpleContext();
        //Aqui llamamos a la clase Cliente para crear un nuevo cliente

        public Cliente NuevoCliente { get; private set; }


        public AgregarClienteForm()
        {
            InitializeComponent();
        }

        //Este boton se utiliza para aceptar de que se esta agregando un nuevo cliente
        //tanto su nombre y su identificacion
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                MessageBox.Show("Todos los campos son necesarios");
                return;
            }

            //Mejora si ya existe un cliente 
            if (_db.Cliente.Any(NuevoCliente => NuevoCliente.Identificacion == txtIdentificacion.Text.Trim()))
            {
                MessageBox.Show("Ya existe un cliente con esta identificacion ");
                txtIdentificacion.Focus();
                return;
            }
            else
            {
                NuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Identificacion = txtIdentificacion.Text
                };
                DialogResult = DialogResult.OK;
                Close();

            }

            //Mejora el nombre del cliente
            if (txtNombre.Text.Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres");
                txtNombre.Focus();
                return;


            }

            //Mejora identificacion del cliente 
            if (txtIdentificacion.Text.Length < 6)
            {
                MessageBox.Show("La identificacion debe tener al menos 6 caracteres");
                txtIdentificacion.Focus();
                return;

            }



            
        }

        //Este boton se utiliza para cancelar o eliminar
        //es decir cuando ya no queremos agregar a x cliente
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
