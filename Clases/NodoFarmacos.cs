using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstrusturasDatos_Lab02.Clases
{
    public class NodoFarmacos: IComparable
    {
       public int ID { get; set; }
       public string Nombre { get; set; }
       public int Invetario { get; set; }
       public int Index { get; set; }

        public Comparison<NodoFarmacos> BuscarID = delegate (NodoFarmacos Far1, NodoFarmacos Far2)
        {
            return Far1.ID.CompareTo(Far2.ID);
        };
        public Comparison<NodoFarmacos> BuscarIndex = delegate (NodoFarmacos Far1, NodoFarmacos Far2)
        {
            return Far1.Index.CompareTo(Far2.Index);
        };
        public Comparison<NodoFarmacos> BuscarNombre = delegate (NodoFarmacos Far1, NodoFarmacos Far2)
        {
            return Far1.Nombre.CompareTo(Far2.Nombre);
        };
        public Comparison<NodoFarmacos> BuscarIventario = delegate (NodoFarmacos Far1, NodoFarmacos Far2)
        {
            return Far1.Invetario.CompareTo(Far2.Invetario);
        };
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
