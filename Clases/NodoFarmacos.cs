using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstrusturasDatos_Lab02.Clases
{
    public class NodoFarmacos: IComparable
    {
       public int ID { get; set; }
       public string Nombre { get; set; }
       public int Inventario { get; set; }

        public Comparison<NodoFarmacos> BuscarID = delegate (NodoFarmacos Far1, NodoFarmacos Far2)
        {
            return Far1.ID.CompareTo(Far2.ID);
        };
        public Comparison<NodoFarmacos> BuscarNombre = delegate (NodoFarmacos Far1, NodoFarmacos Far2)
        {
            return Far1.Nombre.CompareTo(Far2.Nombre);
        };
        public Comparison<NodoFarmacos> BuscarIventario = delegate (NodoFarmacos Far1, NodoFarmacos Far2)
        {
            return Far1.Inventario.CompareTo(Far2.Inventario);
        };
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
