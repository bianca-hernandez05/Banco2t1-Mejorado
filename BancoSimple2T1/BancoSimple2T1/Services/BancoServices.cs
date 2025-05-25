using BancoSimple2T1.Data;
using BancoSimple2T1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSimple2T1.Services
{
    public class BancoServices
        //Creacion de una nueva clase para manipulacion de datos de manera mas rapida
    {
        private  BancoSimpleContext _db = new BancoSimpleContext();

        public List<Cliente> ObtenerClientes()
        {
            return _db.Cliente.ToList();
        }

        public List<object> ObtenerCuentasActivas()
        {
            return _db.Cuenta
                     .Include(c => c.cliente)
                     .Where(c => c.Activa)
                     .Select(c => new {
                         c.CuentaId,
                         c.NumeroCuenta,
                         c.Saldo,
                         NombreCliente = c.cliente.Nombre,
                         c.Activa,
                         c.ClienteId
                     })
                     .ToList<object>();
        }

        public void AgregarCliente(Cliente nuevo)
        {
            try
            {
                _db.Cliente.Add(nuevo);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error en un log o volverlo a lanzar
                throw new Exception("Error al agregar cliente", ex);
            }
        }

        public void AgregarCuenta(Cuenta nueva)
        {
            _db.Cuenta.Add(nueva);
            _db.SaveChanges();
        }

        public void DesactivarCuenta(int cuentaId)
        {
            var cuenta = _db.Cuenta.Find(cuentaId);
            if (cuenta == null)
                throw new Exception("Cuenta no encontrada");

            cuenta.Activa = false;
            _db.SaveChanges();
        }

        /// Realiza una transferencia de dinero entre dos cuentas si ambas existen,
        /// están activas y la cuenta origen tiene saldo suficiente.
        /// Utiliza una transacción para asegurar la integridad de los datos.

        public void RealizarTransferencia(int cuentaOrigenId, int cuentaDestinoId, decimal monto)
        {
            using var transferencia = _db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                var cuentaOrigen = _db.Cuenta.FirstOrDefault(c => c.CuentaId == cuentaOrigenId);
                var cuentaDestino = _db.Cuenta.FirstOrDefault(c => c.CuentaId == cuentaDestinoId);

                if (cuentaOrigen == null || cuentaDestino == null)
                    throw new Exception("Una o ambas cuentas no existen");

                if (!cuentaOrigen.Activa || !cuentaDestino.Activa)
                    throw new Exception("Una o ambas cuentas están inactivas");

                if (cuentaOrigen.Saldo < monto)
                    throw new Exception("Saldo insuficiente");

                cuentaOrigen.Saldo -= monto;
                cuentaDestino.Saldo += monto;

                _db.Transacciones.Add(new Transaccion
                {
                    Monto = monto,
                    Fecha = DateTime.Now,
                    Descripcion = "Transferencia entre cuentas",
                    CuentaOrigenId = cuentaOrigenId,
                    CuentaDestinoId = cuentaDestinoId
                });

                _db.SaveChanges();
                transferencia.Commit();
            }
            catch (Exception ex)
            {
                transferencia.Rollback();
                throw new Exception("Error al realizar la transferencia", ex);
            }
        }

        }
}
