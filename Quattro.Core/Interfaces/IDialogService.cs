﻿using System;

namespace Quattro.Core.Interfaces {

    public interface IDialogService {

        void Alert(string mensaje, string titulo, string textoBotonOk);

        void Alert(string mensaje, string titulo, string textoBotonOk, Action confirmar);

        void Confirmar(string mensaje, string titulo, string textoBotonOk, string textoBotonCancel, Action confirmar, Action cancelar);

        void ShortToast(string mensaje);

        void LongToast(string mensaje);

        void Input(string titulo, string textoBotonOk, string textoBotonCancel, Action<string> confirmar);

        void InputNuevaLinea(Action<string, string> confirmar);
    }
}
