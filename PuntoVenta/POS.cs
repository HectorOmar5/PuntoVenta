using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class POS
    {
        private List<Articulo> _listArticulo = new List<Articulo>();
        private List<itemBase> _listVentas = new List<itemBase>();
        public POS()
        {
            MostarLista();
        }

        public void Mostrartxt(string ruta)
        {
            StreamReader archivo = new StreamReader(ruta);
            Console.WriteLine(archivo.ReadToEnd());
            archivo.Close();
        }
        public void MostarLista()
        {
            StreamReader sr = new StreamReader(@"C:\Users\Tichs\Desktop\Archivos Skype\Punto Venta\Articulos.json");
            string jsonString = sr.ReadToEnd();
            _listArticulo = JsonConvert.DeserializeObject<List<Articulo>>(jsonString);
            sr.Close();
        }

        public void Presentacion()
        {
            while (true)
            {
                Console.WriteLine("¿Quieres Agregar Un Articulo?");
                string Respuesta = Console.ReadLine();
                if (Respuesta == "Si")
                {
                    Console.WriteLine("Ingrese ID Del Articulo");
                    string idArticulo = Console.ReadLine();
                    Articulo articulo = _listArticulo.Find(arti => arti.id == int.Parse(idArticulo));
                    Console.WriteLine("Ingrese La Cantidad De Articulos");
                    decimal cantidadArticulos = decimal.Parse(Console.ReadLine());
                    switch (articulo.tipo)
                    {
                        case TipoArticulo.normal:
                            CrearNormal(articulo, cantidadArticulos);
                            break;
                        case TipoArticulo.conDescuento:
                            CrearDescuento(articulo, cantidadArticulos);
                            break;
                        case TipoArticulo.TiempoAigre:
                            CrearTA(articulo, cantidadArticulos);
                            break;
                    }
                }
                else if(Respuesta == "No")
                {
                    ImprimirTicket();
                    break;
                }
                    
            }
            
        }
        public void CrearNormal(Articulo articulo, decimal cantidadArticulos)
        {
            item itemNormal = new item(articulo.id, articulo.nombre, articulo.precio, cantidadArticulos);

            itemNormal.imprimir();
            _listVentas.Add(itemNormal);
            Console.ReadKey();


        }
        public void CrearDescuento(Articulo articulo, decimal cantidadArticulos)
        {
            itemDescuento itemDesc = new itemDescuento(articulo.id, articulo.nombre, articulo.precio, cantidadArticulos);
            Console.WriteLine("Ingrese Descuento: ");
            decimal descuento = decimal.Parse(Console.ReadLine());
            itemDesc.descuento = descuento;
            itemDesc.imprimir();
            _listVentas.Add(itemDesc);
            Console.ReadKey();
        }
        public void CrearTA(Articulo articulo, decimal cantidadArticulos)
        {
            Console.WriteLine("Ingrese Numero Telefonico: ");
            string telefono = Console.ReadLine();

            Console.WriteLine("Ingrese Su Compañia: ");
            string compania = Console.ReadLine();

            Console.WriteLine("Ingrese La Comision: ");
            decimal comision = decimal.Parse(Console.ReadLine());

            itemTA itemAigre = new itemTA(articulo.id, articulo.nombre, articulo.precio, cantidadArticulos);
            itemAigre.telefono = telefono;

            itemAigre.compania = compania;
            itemAigre.comision = comision;
            itemAigre.imprimir();

            _listVentas.Add(itemAigre);
            Console.ReadKey();
        }

        public void ImprimirTicket()
        {
            Console.WriteLine("===== EMPRESA TICH =====");
            foreach(itemBase item in _listVentas)
            {
                item.imprimir();
            }
            Console.WriteLine($"Total Articulos: {_listVentas.Count()}");
            Console.WriteLine($"Total:{_listVentas.Sum(sum => sum.Total())}");
            Console.ReadKey();
        }
        
    }
}
