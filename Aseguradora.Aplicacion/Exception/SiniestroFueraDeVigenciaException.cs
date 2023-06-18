    using System;
    namespace Aseguradora.Aplicacion;

    public class SiniestroFueraDeVigenciaException : Exception
    {
        public SiniestroFueraDeVigenciaException()
        {
        }

        public SiniestroFueraDeVigenciaException(string mensaje)
            : base(mensaje)
        {
        }
    }
