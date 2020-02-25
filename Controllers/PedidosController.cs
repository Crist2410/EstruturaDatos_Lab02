using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstrusturasDatos_Lab02.Models;
using EstrusturasDatos_Lab02.Clases;
using LibreriaGenerica.Estructuras;

namespace EstrusturasDatos_Lab02.Controllers
{
    public class PedidosController : Controller
    {
        public static List<Farmacos> InvetarioFarmacos = new List<Farmacos>();
        public static ArbolBinarioBusqueda<NodoFarmacos> ArbolBusqueda = new ArbolBinarioBusqueda<NodoFarmacos>();
        // GET: Pedidos
        public ActionResult Index()
        {
            return View();
        }

        //Vista Importar Farmacos
        public ActionResult CargarFarmacos()
        {
            return View("ImportarFarmacos");
        }

        [HttpPost]
        public IActionResult ImportarFarmacos(IFormFile ArchivoCargado)
        {
            if (ArchivoCargado.FileName.Contains(".txt"))
            {

                using (var stream = new StreamReader(ArchivoCargado.OpenReadStream()))
                {
                    string Texto = stream.ReadToEnd();
                    foreach (string Fila in Texto.Split("\r\n"))
                    {
                        Farmacos Farmaco1 = new Farmacos();
                        NodoFarmacos NodoFarmaco = new NodoFarmacos();
                        if (!string.IsNullOrEmpty(Fila))
                        {
                            try
                            {
                                Farmaco1.Nombre = Fila.Split(",")[0];
                                Farmaco1.Descripcion = Fila.Split(",")[1];
                                Farmaco1.Inventario = Convert.ToInt32(Fila.Split(",")[2]);
                                Farmaco1.Solucion = Fila.Split(",")[3];
                                //Farmaco1.ID = (Fila.Split(",")[0]).GetHashCode();
                                InvetarioFarmacos.Add(Farmaco1);
                                NodoFarmaco.Index = InvetarioFarmacos.IndexOf(Farmaco1);
                                //NodoFarmaco.ID = Farmaco1.ID;
                                NodoFarmaco.Nombre = Farmaco1.Nombre;
                                NodoFarmaco.Invetario = Farmaco1.Inventario;
                                ArbolBusqueda.Add(NodoFarmaco, NodoFarmaco.BuscarNombre);

                            }
                            catch (Exception) 
                            { 

                            }
                        }
                    }
                }
                var ImprimirArbol = ArbolBusqueda.Mostrar();
                ViewBag.Farmacos = ImprimirArbol;
                return View("InventarioFarmacos");
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