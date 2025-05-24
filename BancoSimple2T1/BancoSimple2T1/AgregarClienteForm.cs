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
            NuevoCliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Identificacion = txtIdentificacion.Text
            };
            DialogResult = DialogResult.OK;
            Close();
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
