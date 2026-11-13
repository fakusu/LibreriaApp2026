namespace LibreriaApp2026.Windows.Helpers
{
    /// <summary>
    /// Impide tipear caracteres no permitidos en un TextBox.
    /// Es solo una ayuda: si se pega texto, igual se valida al aceptar (ValidarDatos y el servicio).
    /// </summary>
    public static class FiltroTeclado
    {
        public static void SoloDigitos(params TextBox[] cajas) =>
            Aplicar(char.IsDigit, cajas);

        public static void Telefono(params TextBox[] cajas) =>
            Aplicar(c => char.IsDigit(c) || " +-()".Contains(c), cajas);

        public static void Isbn(params TextBox[] cajas) =>
            Aplicar(c => char.IsDigit(c) || c is '-' or 'x' or 'X', cajas);

        // nombres, apellidos, nacionalidades, países, provincias
        public static void SoloLetras(params TextBox[] cajas) =>
            Aplicar(c => char.IsLetter(c) || " '.-".Contains(c), cajas);

        public static void LetrasYDigitos(params TextBox[] cajas) =>
            Aplicar(char.IsLetterOrDigit, cajas);

        private static void Aplicar(Func<char, bool> permitido, TextBox[] cajas)
        {
            foreach (var caja in cajas)
            {
                caja.KeyPress += (s, e) =>
                {
                    //las teclas de control (borrar, Ctrl+C, Ctrl+V...) siempre se permiten
                    if (!char.IsControl(e.KeyChar) && !permitido(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                };
            }
        }
    }
}
