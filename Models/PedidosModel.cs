using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstrusturasDatos_Lab02.Clases;

namespace EstrusturasDatos_Lab02.Models
{
    public class PedidosModel
    {
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public string Nit { get; set; }
        public double Total { get; set; }

        public List<Farmacos> PedidoFarmacos = new List<Farmacos>();
    }
}
