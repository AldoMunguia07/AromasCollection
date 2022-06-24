﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool verificarNumero(int numero)
        {
            string number = "123456";
            if (number.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SoloLetras(KeyPressEventArgs N)
        {
            if (Char.IsLetter(N.KeyChar))
            {
                N.Handled = false;
            }
            else if (Char.IsSeparator(N.KeyChar))
            {
                N.Handled = false;
            }
            else if (Char.IsControl(N.KeyChar))
            {
                N.Handled = false;
            }
            else
            {
                N.Handled = true;

            }
        }
        public static void SoloNumeros(KeyPressEventArgs N)
        {
            if (Char.IsDigit(N.KeyChar))
            {
                N.Handled = false;
            }
            else if (Char.IsSeparator(N.KeyChar))
            {
                N.Handled = false;
            }
            else if (Char.IsControl(N.KeyChar))
            {
                N.Handled = false;
            }
            else
            {
                N.Handled = true;

            }
        }
    }
}
