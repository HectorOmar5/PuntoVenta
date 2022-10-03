using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public class itemDescuento : itemBase
    {

        public itemDescuento(int id, string nombreProd, decimal precio, decimal cantidad) :base(id, nombreProd, precio, cantidad)
        {

        }

        public decimal descuento { get; set; }
        public decimal ImpDescuento { get 
        {
                return precio * cantidad * descuento;
        } 
        }

        public override void imprimir()
        {
            Console.WriteLine($"id:{id}\nNombre Producto:{nombreProd}\nPrecio:{precio}\nCantidad:{cantidad}\nSubtotal:{Subtotal()}\nTotal:{Total()}\n");
        }

        public override decimal Total()
        {
            return base.Total() - ImpDescuento;
        }
    }
}
