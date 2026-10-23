namespace LibreriaApp2026.Windows.Helpers
{
    public record ItemSeleccion(int Id, string Texto)
    {
        //el CheckedListBox muestra lo que devuelve ToString()
        public override string ToString() => Texto;
    }

    // Maneja un CheckedListBox con buscador, casilla "Ver solo seleccionados" y contador.
    // Los seleccionados se guardan aparte, así no se pierden al filtrar la lista.
    public class SeleccionMultiple
    {
        private readonly TextBox _txtBuscar;
        private readonly CheckedListBox _lista;
        private readonly CheckBox _chkSoloSeleccionados;
        private readonly Label _lblCantidad;

        private List<ItemSeleccion> _items = new();
        private HashSet<int> _seleccionados = new();
        private bool _refrescando = false;

        public SeleccionMultiple(TextBox txtBuscar, CheckedListBox lista,
            CheckBox chkSoloSeleccionados, Label lblCantidad)
        {
            _txtBuscar = txtBuscar;
            _lista = lista;
            _chkSoloSeleccionados = chkSoloSeleccionados;
            _lblCantidad = lblCantidad;

            _txtBuscar.TextChanged += (s, e) => Refrescar();
            _chkSoloSeleccionados.CheckedChanged += (s, e) => Refrescar();
            _lista.ItemCheck += Lista_ItemCheck;
        }

        public int CantidadSeleccionados => _seleccionados.Count;

        public void Cargar(IEnumerable<ItemSeleccion> items, IEnumerable<int> seleccionados)
        {
            _items = items.OrderBy(i => i.Texto).ToList();
            _seleccionados = new HashSet<int>(seleccionados);
            Refrescar();
        }

        public List<int> ObtenerSeleccionados()
        {
            return _seleccionados.ToList();
        }

        public void Limpiar()
        {
            _seleccionados.Clear();
            _txtBuscar.Clear();
            _chkSoloSeleccionados.Checked = false;
            Refrescar();
        }

        private void Refrescar()
        {
            var texto = _txtBuscar.Text.Trim();
            var filtrados = _items
                .Where(i => texto.Length == 0 || i.Texto.Contains(texto, StringComparison.CurrentCultureIgnoreCase))
                .Where(i => !_chkSoloSeleccionados.Checked || _seleccionados.Contains(i.Id))
                .ToArray();

            //al rearmar la lista se marcan los seleccionados sin pasar por Lista_ItemCheck
            _refrescando = true;
            _lista.BeginUpdate();
            _lista.Items.Clear();
            _lista.Items.AddRange(filtrados);
            for (int i = 0; i < filtrados.Length; i++)
            {
                _lista.SetItemChecked(i, _seleccionados.Contains(filtrados[i].Id));
            }
            _lista.EndUpdate();
            _refrescando = false;

            MostrarCantidad();
        }

        private void Lista_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            if (_refrescando) return;

            //ItemCheck se dispara antes de cambiar la marca, por eso se usa NewValue
            var item = (ItemSeleccion)_lista.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                _seleccionados.Add(item.Id);
            }
            else
            {
                _seleccionados.Remove(item.Id);
            }
            MostrarCantidad();
        }

        private void MostrarCantidad()
        {
            _lblCantidad.Text = _seleccionados.Count == 1
                ? "1 seleccionado"
                : $"{_seleccionados.Count} seleccionados";
        }
    }
}
