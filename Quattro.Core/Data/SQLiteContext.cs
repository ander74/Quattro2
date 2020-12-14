using System.IO;
using Xamarin.Essentials;

namespace Quattro.Core.Data {

    public class SQLiteContext {

        // ====================================================================================================
        #region CAMPOS PRIVADOS
        // ====================================================================================================

        private string dataBaseFile;
        //SQLiteConnection db;

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public SQLiteContext() {
            dataBaseFile = Path.Combine(FileSystem.AppDataDirectory, "database.qt2");
            //db = new SQLiteConnection(dataBaseFile);
            //ConfirmarBaseDatos();
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PRIVADOS
        // ====================================================================================================

        //private void ConfirmarBaseDatos() {

        //    db.RunInTransaction(() => {
        //        // Crear las tablas si no existen.
        //        db.CreateTable<LineaEntity>();
        //        db.CreateTable<ServicioLineaEntity>();
        //        db.CreateTable<ServicioSecundarioEntity>();
        //        db.CreateTable<DiaCalendarioEntity>();
        //        db.CreateTable<ServicioDiaEntity>();
        //        db.CreateTable<IncidenciaEntity>();
        //        db.CreateTable<HoraAjenaEntity>();
        //        db.CreateTable<CompañeroEntity>();

        //        // Si no hay incidencias, creamos las incidencias por defecto.
        //        var numeroIncidencias = db.ExecuteScalar<int>("SELECT Count(*) FROM Incidencias;");
        //        if (numeroIncidencias == 0) {
        //            db.InsertAll(new List<IncidenciaEntity> {
        //                new IncidenciaEntity { Id = 00, Codigo = -1,},
        //                new IncidenciaEntity { Id = 01, Codigo = 0, Descripcion = "Repite día anterior", Tipo = TipoIncidencia.Desconocido, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 02, Codigo = 1, Descripcion = "Trabajo", Tipo = TipoIncidencia.Trabajo, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 03, Codigo = 2, Descripcion = "Franqueo", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 04, Codigo = 3, Descripcion = "Vacaciones", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 05, Codigo = 4, Descripcion = "F.O.D.", Tipo = TipoIncidencia.FiestaOtroDia, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 06, Codigo = 5, Descripcion = "Franqueo a trabajar", Tipo = TipoIncidencia.FranqueoTrabajado, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 07, Codigo = 6, Descripcion = "Enferma/o", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 08, Codigo = 7, Descripcion = "Accidentada/o", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 09, Codigo = 8, Descripcion = "Permiso", Tipo = TipoIncidencia.JornadaMedia, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 10, Codigo = 9, Descripcion = "F.N.R. año actual", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 11, Codigo = 10, Descripcion = "F.N.R. año anterior", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 12, Codigo = 11, Descripcion = "Nos hacen el día", Tipo = TipoIncidencia.Trabajo, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 13, Codigo = 12, Descripcion = "Hacemos el día", Tipo = TipoIncidencia.TrabajoSinAcumular, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 14, Codigo = 13, Descripcion = "Sanción", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 15, Codigo = 14, Descripcion = "En otro destino", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 16, Codigo = 15, Descripcion = "Huelga", Tipo = TipoIncidencia.TrabajoSinAcumular, Notas = "Incidencia Protegida." },
        //                new IncidenciaEntity { Id = 17, Codigo = 16, Descripcion = "Día por H. Acumuladas", Tipo = TipoIncidencia.FiestaOtroDia, Notas = "Incidencia Protegida." }
        //            });
        //        }
        //        if (db.ExecuteScalar<int>("SELECT Count(*) FROM Lineas") == 0) db.Insert(new LineaEntity { Id = 0 });
        //        if (db.ExecuteScalar<int>("SELECT Count(*) FROM Companeros") == 0) db.Insert(new CompañeroEntity { Id = 0 });
        //        //var numeroLineas = db.ExecuteScalar<int>("SELECT Count(*) FROM Lineas;");
        //        //if (numeroLineas == 0) {
        //        //    db.InsertAll(new List<LineaEntity> {
        //        //        new LineaEntity { Id = 01, Numero = "", Descripcion = "" },
        //        //        new LineaEntity { Id = 02, Numero = "", Descripcion = "Nueva Línea" }
        //        //    });
        //        //}
        //        //var numeroCompañeros = db.ExecuteScalar<int>("SELECT Count(*) FROM Companeros;");
        //        //if (numeroCompañeros == 0) {
        //        //    db.InsertAll(new List<CompañeroEntity> {
        //        //        new CompañeroEntity { Id = 01, Matricula = 0, Apellidos = "Desconocido" },
        //        //        new CompañeroEntity { Id = 02, Matricula = 0, Apellidos = "Nuevo Compañero" }
        //        //    });
        //        //}
        //    });
        //}


        //private int GetUltimoId() {
        //    return db.ExecuteScalar<int>("SELECT last_insert_rowid()");
        //}




        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS CALENDARIO
        // ====================================================================================================

        //public IEnumerable<DiaCalendarioEntity> GetMes(DateTime fecha) {
        //    var fecha1 = new DateTime(fecha.Year, fecha.Month, 1);
        //    var fecha2 = fecha1.AddMonths(1);
        //    List<DiaCalendarioEntity> dias = null;
        //    db.RunInTransaction(() => {
        //        dias = db.Query<DiaCalendarioEntity>("SELECT * FROM Calendario WHERE Fecha >= ? AND Fecha < ?", fecha1, fecha2);
        //        if (dias == null || dias.Count == 0) {
        //            for (int dia = 1; dia <= DateTime.DaysInMonth(fecha.Year, fecha.Month); dia++) {
        //                db.Insert(new DiaCalendarioEntity { Fecha = new DateTime(fecha.Year, fecha.Month, dia) });
        //            }
        //            dias = db.Query<DiaCalendarioEntity>("SELECT * FROM Calendario WHERE Fecha >= ? AND Fecha < ?", fecha1, fecha2);
        //        }
        //        foreach (var dia in dias) {
        //            dia.Incidencia = GetIncidenciaById(dia.IncidenciaId);
        //            dia.Linea = GetLineaById(dia.LineaId);
        //            dia.Relevo = GetCompañeroById(dia.RelevoId);
        //            dia.Susti = GetCompañeroById(dia.SustiId);
        //        }
        //    });
        //    return dias ?? new List<DiaCalendarioEntity>();
        //}


        //public void GuardarDiasCalendario(IEnumerable<DiaCalendarioEntity> dias) {
        //    db.RunInTransaction(() => {
        //        foreach (var dia in dias) GuardarDiaCalendario(dia);
        //    });
        //}


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS DIA CALENDARIO
        // ====================================================================================================

        //public DiaCalendarioEntity GetDiaCalendarioById(int id, bool incluirServicios = false) {
        //    DiaCalendarioEntity dia = null;
        //    db.RunInTransaction(() => {
        //        dia = db.Get<DiaCalendarioEntity>(id);
        //        if (dia != null && incluirServicios) dia.Servicios = GetServiciosDia(dia.Id);
        //    });
        //    return dia;
        //}

        //public DiaCalendarioEntity GetDiaCalendario(DateTime fecha, bool incluirServicios = false) {
        //    DiaCalendarioEntity dia = null;
        //    db.RunInTransaction(() => {
        //        dia = db.Get<DiaCalendarioEntity>(d => d.Fecha == fecha);
        //        if (dia != null && incluirServicios) dia.Servicios = GetServiciosDia(dia.Id);
        //    });
        //    return dia;
        //}


        //public void GuardarDiaCalendario(DiaCalendarioEntity dia) {
        //    if (dia == null) return;
        //    db.RunInTransaction(() => {
        //        if (dia.Id == 0) {
        //            db.Insert(dia);
        //            dia.Id = GetUltimoId();
        //        } else {
        //            db.Update(dia);
        //        }
        //        if (dia.Servicios != null && dia.Servicios.Count() > 0) {
        //            foreach (var serv in dia.Servicios) {
        //                serv.IdDiaCalendario = dia.Id;
        //                GuardarServicioDia(serv);
        //            }
        //        }
        //        GuardarIncidencia(dia.Incidencia);
        //        GuardarLinea(dia.Linea);
        //        GuardarCompañero(dia.Relevo);
        //        GuardarCompañero(dia.Susti);
        //    });
        //}


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS LÍNEAS
        // ====================================================================================================

        //public LineaEntity GetLineaById(int id, bool incluirServicios = false) {
        //    LineaEntity linea = null;
        //    db.RunInTransaction(() => {
        //        linea = db.Get<LineaEntity>(id);
        //        if (linea != null && incluirServicios) linea.Servicios = GetServiciosLinea(linea.Id);
        //    });
        //    return linea;
        //}


        //public void GuardarLinea(LineaEntity linea) {
        //    if (linea == null) return;
        //    if (linea.Id == 0) {
        //        db.Insert(linea);
        //        linea.Id = GetUltimoId();
        //    } else {
        //        db.Update(linea);
        //    }
        //    if (linea.Servicios != null && linea.Servicios.Count() > 0) {
        //        foreach (var serv in linea.Servicios) {
        //            serv.IdLinea = linea.Id;
        //            GuardarServicioLinea(serv);
        //        }
        //    }

        //}

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS COMPAÑEROS
        // ====================================================================================================

        //public CompañeroEntity GetCompañeroById(int id) {
        //    return db.Get<CompañeroEntity>(id);
        //}


        //public void GuardarCompañero(CompañeroEntity compañero) {
        //    if (compañero == null) return;
        //    if (compañero.Id == 0) {
        //        db.Insert(compañero);
        //        compañero.Id = GetUltimoId();
        //    } else {
        //        db.Update(compañero);
        //    }
        //}


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS INCIDENCIAS
        // ====================================================================================================

        //public IEnumerable<IncidenciaEntity> GetIncidencias() {
        //    return db.Query<IncidenciaEntity>("SELECT * FROM Incidencias ORDERBY Codigo");
        //}


        //public IncidenciaEntity GetIncidenciaById(int id) {
        //    return db.Get<IncidenciaEntity>(id);
        //}

        //public void GuardarIncidencia(IncidenciaEntity incidencia) {
        //    if (incidencia == null) return;
        //    if (incidencia.Id == 0) {
        //        db.Insert(incidencia);
        //        incidencia.Id = GetUltimoId();
        //    } else {
        //        db.Update(incidencia);
        //    }
        //}



        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS SERVICIOS LÍNEA
        // ====================================================================================================

        //public IEnumerable<ServicioLineaEntity> GetServiciosLinea(int idLinea) {
        //    return db.Query<ServicioLineaEntity>("SELECT * FROM ServiciosLinea WHERE IdLinea = ?", idLinea);
        //}

        //public ServicioLineaEntity GetServicioLineaById(int id) {
        //    return db.Get<ServicioLineaEntity>(id);
        //}

        //public void GuardarServicioLinea(ServicioLineaEntity servicioLinea) {
        //    if (servicioLinea == null) return;
        //    db.RunInTransaction(() => {
        //        if (servicioLinea.Id == 0) {
        //            db.Insert(servicioLinea);
        //            servicioLinea.Id = GetUltimoId();
        //        } else {
        //            db.Update(servicioLinea);
        //        }
        //        if (servicioLinea.Servicios != null && servicioLinea.Servicios.Count() > 0) {
        //            foreach (var serv in servicioLinea.Servicios) {
        //                serv.IdServicioLinea = servicioLinea.Id;
        //                GuardarServicioSecundario(serv);
        //            }
        //        }
        //    });
        //}
        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS SERVICIOS DIA
        // ====================================================================================================

        //public IEnumerable<ServicioDiaEntity> GetServiciosDia(int idDiaCalendario) {
        //    return db.Query<ServicioDiaEntity>("SELECT * FROM ServiciosDia WHERE IdDiaCalendario = ?", idDiaCalendario);
        //}

        //public ServicioDiaEntity GetServicioDiaById(int id) {
        //    return db.Get<ServicioDiaEntity>(id);
        //}

        //public void GuardarServicioDia(ServicioDiaEntity servicioDia) {
        //    if (servicioDia == null) return;
        //    if (servicioDia.Id == 0) {
        //        db.Insert(servicioDia);
        //        servicioDia.Id = GetUltimoId();
        //    } else {
        //        db.Update(servicioDia);
        //    }

        //}
        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS SERVICIOS SECUNDARIOS
        // ====================================================================================================

        //public IEnumerable<ServicioSecundarioEntity> GetServiciosSecundarios(int idServicioLinea) {
        //    return db.Query<ServicioSecundarioEntity>("SELECT * FROM ServiciosSecundarios WHERE IdDiaCalendario = ?", idServicioLinea);
        //}

        //public ServicioSecundarioEntity GetServicioSecundarioById(int id) {
        //    return db.Get<ServicioSecundarioEntity>(id);
        //}

        //public void GuardarServicioSecundario(ServicioSecundarioEntity servicioSecundario) {
        //    if (servicioSecundario == null) return;
        //    if (servicioSecundario.Id == 0) {
        //        db.Insert(servicioSecundario);
        //        servicioSecundario.Id = GetUltimoId();
        //    } else {
        //        db.Update(servicioSecundario);
        //    }

        //}
        #endregion
        // ====================================================================================================


    }
}
