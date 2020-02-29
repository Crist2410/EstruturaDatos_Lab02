using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstrusturasDatos_Lab02.Models;
using EstrusturasDatos_Lab02.Clases;
using LibreriaGenerica.Estructuras;
using Microsoft.VisualBasic.FileIO;
using Microsoft.AspNetCore.Hosting;

namespace EstrusturasDatos_Lab02.Controllers
{
    public class PedidosController : Controller
    {
        public static ArbolBinarioBusqueda<NodoFarmacos> ArbolBusqueda = new ArbolBinarioBusqueda<NodoFarmacos>();
        public static List<NodoFarmacos> FarmacosVacios = new List<NodoFarmacos>();
        public static PedidosModel NuevoPedido = new PedidosModel();
        public static string RutaBase;
        private IWebHostEnvironment Environment;
        public void Editar(NodoFarmacos NodoAuxFarmaco)
        {
            List<Farmacos> ListaAux = new List<Farmacos>();

            using (TextFieldParser Archivo = new TextFieldParser(RutaBase))
            {
                Archivo.TextFieldType = FieldType.Delimited;
                Archivo.SetDelimiters(",");
                while (!Archivo.EndOfData)
                {
                    string[] Texto = Archivo.ReadFields();
                    try
                    {
                        Farmacos FarmacoMostrar = new Farmacos();
                        FarmacoMostrar.ID = Convert.ToInt32(Texto[0]);

                        if (Texto[1].Contains(','))
                            FarmacoMostrar.Nombre = "\"" + Texto[1] + "\"";
                        else
                            FarmacoMostrar.Nombre = Texto[1];
                        if (Texto[2].Contains(','))
                            FarmacoMostrar.Descripcion = "\"" + Texto[2] + "\"";
                        else
                            FarmacoMostrar.Descripcion = Texto[2];
                        if (Texto[3].Contains(','))
                            FarmacoMostrar.CasaProductora = "\"" + Texto[3] + "\"";
                        else
                            FarmacoMostrar.CasaProductora = Texto[3];
                        FarmacoMostrar.Precio = Convert.ToDouble(Texto[4].Substring(1));
                        FarmacoMostrar.Inventario = Convert.ToInt32(Texto[5]);
                        ListaAux.Add(FarmacoMostrar);
                    }
                    catch (Exception)
                    { }
                }

            }
            using (var EditArchivo = new StreamWriter(RutaBase))
            {
                EditArchivo.WriteLine("id,nombre,descripcion,casa_productora,precio,existencia");
                foreach (var FarmacoMostrar in ListaAux)
                {
                    var Linea = string.Format("{0},{1},{2},{3},${4},{5}", FarmacoMostrar.ID, FarmacoMostrar.Nombre, FarmacoMostrar.Descripcion, FarmacoMostrar.CasaProductora, FarmacoMostrar.Precio, FarmacoMostrar.Inventario);
                    if (NodoAuxFarmaco.ID == FarmacoMostrar.ID)
                    {
                        Linea = string.Format("{0},{1},{2},{3},${4},{5}", FarmacoMostrar.ID, FarmacoMostrar.Nombre, FarmacoMostrar.Descripcion, FarmacoMostrar.CasaProductora, FarmacoMostrar.Precio, NodoAuxFarmaco.Inventario);
                    }
                    EditArchivo.WriteLine(Linea);
                }
                EditArchivo.Flush();
            }

        }
        public Farmacos ObtenerFarmaco(NodoFarmacos NodoAuxFarmaco)
        {
            Farmacos FarmacoMostrar = new Farmacos();
            using (TextFieldParser Archivo = new TextFieldParser(RutaBase))
            {
                Archivo.TextFieldType = FieldType.Delimited;
                Archivo.SetDelimiters(",");
                while (!Archivo.EndOfData)
                {
                    try
                    {
                        if (NodoAuxFarmaco.ID == Archivo.LineNumber - 1)
                        {

                            string[] Texto = Archivo.ReadFields();
                            FarmacoMostrar.ID = Convert.ToInt32(Texto[0]);
                            FarmacoMostrar.Nombre = Texto[1];
                            FarmacoMostrar.Descripcion = Texto[2];
                            FarmacoMostrar.CasaProductora = Texto[3];
                            FarmacoMostrar.Precio = Convert.ToDouble(Texto[4].Substring(1));
                            FarmacoMostrar.Inventario = Convert.ToInt32(Texto[5]);
                            Archivo.ReadToEnd();
                        }
                       
                    }
                    catch (Exception)
                    {
                    }
                    Archivo.ReadLine();
                }
            }
            return FarmacoMostrar;
        }

        public PedidosController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        // GET: Pedidos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RealizarPedidos()
        {
            NuevoPedido = new PedidosModel();
            ViewBag.Farmacos = NuevoPedido.PedidoFarmacos;
            return View(NuevoPedido);
        }

        //Vista Importar  AgregarFarmaco
        public ActionResult CargarFarmacos()
        {
            return View("ImportarFarmacos");
        }
        public ActionResult AgregarFarmaco(string Texto)
        {
            NodoFarmacos NodoAuxFarmaco = new NodoFarmacos();
            NodoAuxFarmaco.Nombre = Texto;
            NodoAuxFarmaco = ArbolBusqueda.Get(NodoAuxFarmaco, NodoAuxFarmaco.BuscarNombre);
            if (NodoAuxFarmaco != null)
            {
                return View(ObtenerFarmaco(NodoAuxFarmaco));
            }
            else
            {
                ViewBag.Farmacos = NuevoPedido.PedidoFarmacos;
                return View("RealizarPedidos", NuevoPedido);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarFarmaco(IFormCollection collection)
        {
            NodoFarmacos EditarFarmaco = new NodoFarmacos();
            EditarFarmaco.Nombre = collection["Nombre"];
            EditarFarmaco = ArbolBusqueda.Get(EditarFarmaco, EditarFarmaco.BuscarNombre);
            int Descontar = int.Parse(collection["Inventario"]);
            Farmacos FarmacoAux = ObtenerFarmaco(EditarFarmaco);
            if (EditarFarmaco.Inventario >= Descontar && Descontar >= 0)
            {
                //Borra el nodo de un farmaco exitente
                if (NuevoPedido.PedidoFarmacos.Exists(x => x.Nombre == EditarFarmaco.Nombre))
                {
                    FarmacoAux = NuevoPedido.PedidoFarmacos.Find(x => x.Nombre == EditarFarmaco.Nombre);
                    NuevoPedido.PedidoFarmacos.Remove(FarmacoAux);
                }
                //Resta la cantidad a Inventario
                EditarFarmaco.Inventario -= Descontar;
                //Edita el Nodo en el Arbol
                ArbolBusqueda.Edit(EditarFarmaco, EditarFarmaco.BuscarNombre);
                //Agrego la Cantidad Caprada al producto
                FarmacoAux.CantidadComprada += Descontar;
                FarmacoAux.PrecioTotal = Math.Round(FarmacoAux.Precio * Descontar,2);
                NuevoPedido.PedidoFarmacos.Add(FarmacoAux);
                NuevoPedido.Total = 0;
                foreach (Farmacos item in NuevoPedido.PedidoFarmacos)
                {
                    NuevoPedido.Total += item.PrecioTotal;
                }
                if (EditarFarmaco.Inventario == 0)
                {
                    FarmacosVacios.Add(EditarFarmaco);
                    ArbolBusqueda.Delete(EditarFarmaco,EditarFarmaco.BuscarNombre);
                }
                Editar(EditarFarmaco);
                ViewBag.Farmacos = NuevoPedido.PedidoFarmacos;
                return View("RealizarPedidos",NuevoPedido);
            }
            else
            {
                return View("AgregarFarmaco", FarmacoAux);
            }
        }


        [HttpPost]
        public IActionResult ImportarFarmacos(IFormFile ArchivoCargado)
        {
            if (ArchivoCargado.FileName.Contains(".csv"))
            {
                string Ruta = Path.Combine(Environment.WebRootPath,"Documentos/");
                if (!Directory.Exists(Ruta))
                    Directory.CreateDirectory(Ruta);
                using (FileStream stream = new FileStream(Path.Combine(Ruta, ArchivoCargado.FileName), FileMode.Create))
                {
                    ArchivoCargado.CopyTo(stream);
                }
                RutaBase = Ruta + ArchivoCargado.FileName;
                using (TextFieldParser Archivo = new TextFieldParser(RutaBase))
                {
                    Archivo.TextFieldType = FieldType.Delimited;
                    Archivo.SetDelimiters(",");
                    while (!Archivo.EndOfData)
                    {
                        string[] Texto = Archivo.ReadFields();
                       NodoFarmacos NodoFarmaco = new NodoFarmacos();
                        try
                        {
                            NodoFarmaco.Nombre = Texto[1];
                            NodoFarmaco.Inventario = Convert.ToInt32(Texto[5]);
                            NodoFarmaco.ID = Convert.ToInt32(Texto[0]);
                            ArbolBusqueda.Add(NodoFarmaco, NodoFarmaco.BuscarNombre);
                        }
                        catch (Exception)
                        {
                        }
                    } 
                    ViewBag.Farmacos = ArbolBusqueda.Mostrar();
                    return View("InventarioFarmacos");
                }
            }
            else { return View("ImportarFarmacos"); }
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedidos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedidos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}