﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Core.Common {

    public enum Fondo {
        Normal,
        Alterno,
        NormalSeleccionado,
        AlternoSeleccionado,
    }

    public enum Mes {
        Desconocido,
        Enero,
        Febrero,
        Marzo,
        Abril,
        Mayo,
        Junio,
        Julio,
        Agosto,
        Septiembre,
        Octubre,
        Noviembre,
        Diciembre
    }

    public enum MesAbreviado {
        Des,
        Ene,
        Feb,
        Mar,
        Abr,
        May,
        Jun,
        Jul,
        Ago,
        Sep,
        Oct,
        Nov,
        Dic
    }

    public enum DiaSemana {
        Domingo,
        Lunes,
        Martes,
        Miércoles,
        Jueves,
        Viernes,
        Sábado,
    }

    public enum DiaSemanaAbreviado {
        Dom,
        Lun,
        Mar,
        Mié,
        Jue,
        Vie,
        Sáb,
    }

    public enum TipoCompañero {
        Normal,
        Bueno,
        Malo,
    }

    public enum TipoHoraAjena {
        Manual,
        FinAño,
    }

    public enum TipoIncidencia {
        Desconocido,
        Trabajo,
        FranqueoTrabajado,
        FiestaOtroDia,
        Franqueo,
        TrabajoSinAcumular,
        JornadaMedia,
    }

    public enum ModelState {
        SinCambios,
        NoUsada,
        Borrado,
        Modificado,
        Añadido,
    }
}
