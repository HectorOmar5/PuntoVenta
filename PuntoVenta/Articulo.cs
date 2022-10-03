using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public class Articulo
    {
        //private static List<Articulo> _listArticulo = new List<Articulo>();

        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public TipoArticulo tipo { get; set; }

        
    }

    
}
