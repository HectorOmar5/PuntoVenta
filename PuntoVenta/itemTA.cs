using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public class itemTA :itemBase
    {
        public string telefono { get; set; }
        public string compania { get; set; }
        public decimal comision { get; set; }

        public itemTA(int id, string nombreProd, decimal precio, decimal cantidad):base(id, nombreProd, precio, cantidad)
        {

        }

        public override void imprimir()
        {
            Console.WriteLine($"id:{id}\nNombre\nProducto:{nombreProd}\nPrecio:{precio}\nCantidad{cantidad}\nSubtotal:{Subtotal()}\nComision:{comision}\nTotal:{Total()}\n");
        }

        public override decimal Total()
        {
            return base.Total() + comision;
        }
    }
}
