using System;
using EstrusturasDatos_Lab02.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstrusturasDatos_Lab02.Models
{
    public class PaginacionModel
    {
        public IEnumerable<string> Items { get; set; }
        public Pager Pager { get; set; }
    }

    public class Pager
    {
        public Pager(int ItemsTotales, int? Pagina, int pageSize = 10)
        {
            
            var PaginasTotales = (int)Math.Ceiling((decimal)ItemsTotales / (decimal)pageSize);
            var PaginaActual = Pagina != null ? (int)Pagina : 1;
            var PaginaInicio = PaginaActual - 5;
            var PaginaFinal = PaginaActual + 4;
            if (PaginaInicio<= 0)
            {
                PaginaFinal -= (PaginaInicio- 1);
                PaginaInicio = 1;
            }
            if (PaginaFinal> PaginasTotales)
            {
                PaginaFinal = PaginasTotales;
                if (PaginaFinal > 10)
                {
                    PaginaInicio = PaginaFinal- 9;
                }
            }

            TotalItems = ItemsTotales;
            CurrentPage = PaginaActual;
            PageSize = pageSize;
            TotalPages = PaginasTotales;
            StartPage = PaginaInicio;
            EndPage = PaginaFinal;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }
}
