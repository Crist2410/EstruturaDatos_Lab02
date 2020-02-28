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
            using (var textWriter = new StreamWriter(RutaBase))
            {
                var writer = new CsvWriter(textWriter);
                writer.Configuration.Delimiter = ",";

                foreach (var item in list)
                {
                    writer.WriteField("a");
                    writer.WriteField(2);
                    writer.WriteField(true);
                    writer.NextRecord();
                }
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
                    if (NodoAuxFarmaco.ID == Archivo.LineNumber-1)
                    {
                        try
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
                        catch (Exception)
                        {
                        }
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
            return View(ObtenerFarmaco(NodoAuxFarmaco));
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
            if (EditarFarmaco.Inventario >= Descontar && Descontar > 0)
            {
                if (NuevoPedido.PedidoFarmacos.Exists(x => x.Nombre == EditarFarmaco.Nombre))
                {
                    FarmacoAux = NuevoPedido.PedidoFarmacos.Find(x => x.Nombre == EditarFarmaco.Nombre);
                    NuevoPedido.PedidoFarmacos.Remove(FarmacoAux);
                }
                EditarFarmaco.Inventario -= Descontar;
                ArbolBusqueda.Edit(EditarFarmaco, EditarFarmaco.BuscarNombre);
                FarmacoAux.CantidadComprada += Descontar;
                FarmacoAux.PrecioTotal = Math.Round(FarmacoAux.Precio * Descontar,2);
                NuevoPedido.PedidoFarmacos.Add(FarmacoAux);
                NuevoPedido.Total = 0;
                foreach (Farmacos item in NuevoPedido.PedidoFarmacos)
                {
                    NuevoPedido.Total += item.PrecioTotal;
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

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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