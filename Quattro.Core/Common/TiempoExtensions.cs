using System;
using System.Data.Common;

namespace Quattro.Core.Common {
    public static class TiempoExtensions {

        /// <summary>
        /// Devuelve los minutos de la hora de un objeto Tiempo o DbNull si hora es nulo.
        /// </summary>
        /// <param name="hora">Hora de la que devolver los minutos</param>
        /// <returns>Número de minutos que representa el objeto Tiempo o DbNull, si es nulo.</returns>
        public static object ToMinutosOrDbNull(this Tiempo hora) {
            if (hora == null) return DBNull.Value;
            return hora.TotalMinutos;
        }


        /// <summary>
        /// Extrae un campo de tipo Tiempo del un DbDataReader.
        /// </summary>
        /// <param name="lector">Lector del que se extraerá el campo.</param>
        /// <param name="campo">Campo que se va a extraer</param>
        /// <returns>Un objeto Tiempo con el valor almacenado en el campo.</returns>
        public static Tiempo ToTiempo(this DbDataReader lector, string campo) {
            if (lector == null || lector[campo] is DBNull) return null;
            return Tiempo.FromMinutos(Convert.ToInt32(lector[campo]));
        }

    }
}
