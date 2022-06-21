using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromasCollection.Clases
{
    public class Validacion
    {
        public bool verificarContenidoTexto(string texto)
        {
            if(string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }

            return true;
        }

        public bool verificarTextoLargo(string texto, int cantidadMaxima)
        {
            int textoLenght = texto.Length;

            if(!verificarContenidoTexto(texto))
            {
                return false;
            }

            if(textoLenght > cantidadMaxima)
            {
                return false;
            }

            return true;
        }
    }
}
