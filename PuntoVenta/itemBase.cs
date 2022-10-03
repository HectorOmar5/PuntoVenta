using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public abstract class itemBase
    {
        

        public int id;
        public string nombreProd;
        public decimal precio;
        public decimal cantidad;

        public itemBase(int id, string nombreProd, decimal precio, decimal cantidad)
        {
            this.id = id;
            this.nombreProd = nombreProd;
            this.precio = precio;
            this.cantidad = cantidad;
        }
        public abstract void imprimir(); //metodo abstracto (polimorfismo)

        public virtual decimal Total()
        {
            return precio * cantidad;
        }
        public virtual decimal Subtotal()
        {
            return precio * cantidad;
        }
    }
}
