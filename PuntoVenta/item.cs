using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public class item : itemBase
    {
        public item(int id, string nombreProd, decimal precio, decimal cantidad) : base(id, nombreProd, precio, cantidad)
        {
        }

        public override void imprimir()
        {
            Console.WriteLine($"id:{id}\nNombre\nProducto:{nombreProd}\nPrecio:{precio}\nCantidad:{cantidad}\nSubtotal:{Subtotal()}\nTotal:{Total()}\n");
        }
    }
}
