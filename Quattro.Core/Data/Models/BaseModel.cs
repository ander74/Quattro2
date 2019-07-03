using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Quattro.Core.Data.Models {

    public class BaseModel : INotifyPropertyChanged {


        // ====================================================================================================
        #region EVENTO PROPERTY CHANGED
        // ====================================================================================================

        /// <summary>
        /// Evento que se lanzará para notificar el cambio en una propiedad.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Establece el objeto como modificado e invoca el evento 'PropertyChanged'.
        /// </summary>
        public void PropiedadCambiada([CallerMemberName] string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        /// <summary>
        /// Si el valor de la propiedad es diferente al que se quiere asignar, se cambia y se lanza el
        /// evento PropertyChanged correspondiente a la propiedad. Para ello, hay que pasar el campo
        /// privado por referencia.
        /// <typeparam name="T">Tipo de la propiedad a la que se asigna el valor.</typeparam>
        /// <param name="backingField">Campo privado enlazado a la propiedad.</param>
        /// <param name="value">Valor asignado a la propiedad.</param>
        /// <param name="propertyName">Nombre de la propiedad modificada. Si no se escribe, se infiere su nombre.</param>
        /// <returns>True si se modifica el valor de la propiedad o false si el valor no es modificado por ser igual que el que se pasa.</returns>
        /// </summary>
        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null) {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) {
                return false;
            }
            backingField = value;
            PropiedadCambiada(propertyName);
            return true;
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        #endregion
        // ====================================================================================================

    }
}
