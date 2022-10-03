using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PuntoVenta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //POS.Presentacion();
            POS pOS = new POS();
            pOS.Presentacion();
        }
    }
}
