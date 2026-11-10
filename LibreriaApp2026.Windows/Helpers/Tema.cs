namespace LibreriaApp2026.Windows.Helpers
{
    /// <summary>
    /// Tema visual "Biblioteca" (marrón, pergamino y bordó).
    /// Se aplica desde el constructor de cada form con: Helpers.Tema.Aplicar(this);
    /// Cambiar los colores de acá cambia toda la aplicación.
    /// </summary>
    public static class Tema
    {
        // Paleta
        public static readonly Color Fondo = Html("#ECE2CF");
        public static readonly Color Superficie = Html("#F7F0E1");
        public static readonly Color Campo = Html("#FBF6EA");
        public static readonly Color Texto = Html("#33231B");
        public static readonly Color TextoSuave = Html("#7D6654");
        public static readonly Color Linea = Html("#CDBB9C");
        public static readonly Color Barra = Html("#4A2C20");
        public static readonly Color BarraTexto = Html("#F3E6D0");
        public static readonly Color Menu = Html("#5A382A");
        public static readonly Color MenuTexto = Html("#E6D3B6");
        public static readonly Color MenuActivo = Html("#7B2D36");
        public static readonly Color Acento = Html("#8C2F39");
        public static readonly Color AcentoTexto = Html("#FFF4E0");
        public static readonly Color FilaAlterna = Html("#F1E7D3");
        public static readonly Color Encabezado = Html("#D9C7A6");
        public static readonly Color EncabezadoTexto = Html("#3D2A1F");
        public static readonly Color Hover = Html("#E6D6B4");

        // Botón "Filtrar" de los listados: resaltado cuando hay un filtro activo
        public static readonly Color FiltroActivo = Html("#C9962B");
        public static readonly Color FiltroInactivo = Color.Empty;

        private static Color Html(string hex) => ColorTranslator.FromHtml(hex);

        public static void Aplicar(Form form)
        {
            form.BackColor = Fondo;
            form.ForeColor = Texto;
            Recorrer(form);
        }

        private static void Recorrer(Control padre)
        {
            foreach (Control c in padre.Controls)
            {
                Estilizar(c);
                Recorrer(c);
            }
        }

        private static void Estilizar(Control c)
        {
            switch (c)
            {
                case Panel p when p.Name == "panelTop":
                    p.BackColor = Barra;
                    p.ForeColor = BarraTexto;
                    break;
                case Panel p when p.Name == "panelMenu":
                    p.BackColor = Menu;
                    p.ForeColor = MenuTexto;
                    break;
                case Label l when l.Font.Size >= 14F:
                    l.Font = new Font("Georgia", l.Font.Size, FontStyle.Bold);
                    break;
                case Button b when b.Parent?.Name == "panelMenu":
                    EstiloBotonMenu(b);
                    break;
                case Button b:
                    EstiloBoton(b);
                    break;
                case DataGridView g:
                    EstiloGrilla(g);
                    break;
                case SplitContainer s:
                    s.BackColor = Linea;
                    s.Panel1.BackColor = Fondo;
                    s.Panel2.BackColor = Fondo;
                    break;
                case ToolStrip t:
                    t.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    t.Renderer = new ToolStripProfessionalRenderer(new ColoresToolStrip()) { RoundedEdges = false };
                    t.BackColor = Superficie;
                    t.ForeColor = Texto;
                    break;
                case TextBox or ComboBox or NumericUpDown or ListBox or CheckedListBox:
                    c.BackColor = Campo;
                    c.ForeColor = Texto;
                    break;
            }
        }

        private static void EstiloBoton(Button b)
        {
            bool principal = b.DialogResult == DialogResult.OK
                || b.Text is "Aceptar" or "Guardar" or "OK";
            b.FlatStyle = FlatStyle.Flat;
            b.UseVisualStyleBackColor = false;
            b.FlatAppearance.BorderColor = principal ? Acento : Linea;
            b.BackColor = principal ? Acento : Superficie;
            b.ForeColor = principal ? AcentoTexto : Texto;
            b.FlatAppearance.MouseOverBackColor = principal ? MenuActivo : Hover;
            b.FlatAppearance.MouseDownBackColor = principal ? Barra : Encabezado;
            b.Cursor = Cursors.Hand;
        }

        private static void EstiloBotonMenu(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.UseVisualStyleBackColor = false;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Menu;
            b.ForeColor = MenuTexto;
            b.FlatAppearance.MouseOverBackColor = MenuActivo;
            b.FlatAppearance.MouseDownBackColor = Acento;
            b.Font = new Font("Segoe UI", 10F);
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.Padding = new Padding(14, 0, 0, 0);
            b.Cursor = Cursors.Hand;
        }

        private static void EstiloGrilla(DataGridView g)
        {
            g.EnableHeadersVisualStyles = false;
            g.BackgroundColor = Fondo;
            g.BorderStyle = BorderStyle.None;
            g.GridColor = Linea;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            var enc = g.ColumnHeadersDefaultCellStyle;
            enc.BackColor = Encabezado;
            enc.ForeColor = EncabezadoTexto;
            enc.SelectionBackColor = Encabezado;
            enc.SelectionForeColor = EncabezadoTexto;
            enc.Font = new Font("Georgia", 9.5F, FontStyle.Bold);

            var celda = g.DefaultCellStyle;
            celda.BackColor = Superficie;
            celda.ForeColor = Texto;
            celda.SelectionBackColor = Acento;
            celda.SelectionForeColor = AcentoTexto;

            var alterna = g.AlternatingRowsDefaultCellStyle;
            alterna.BackColor = FilaAlterna;
            alterna.ForeColor = Texto;
            alterna.SelectionBackColor = Acento;
            alterna.SelectionForeColor = AcentoTexto;
        }

        private sealed class ColoresToolStrip : ProfessionalColorTable
        {
            public ColoresToolStrip() { UseSystemColors = false; }

            public override Color ToolStripGradientBegin => Superficie;
            public override Color ToolStripGradientMiddle => Superficie;
            public override Color ToolStripGradientEnd => Superficie;
            public override Color ToolStripBorder => Linea;
            public override Color ToolStripDropDownBackground => Superficie;
            public override Color ImageMarginGradientBegin => Superficie;
            public override Color ImageMarginGradientMiddle => Superficie;
            public override Color ImageMarginGradientEnd => Superficie;
            public override Color MenuBorder => Linea;
            public override Color SeparatorDark => Linea;
            public override Color SeparatorLight => Superficie;
            public override Color GripDark => Linea;
            public override Color GripLight => Superficie;

            public override Color ButtonSelectedHighlight => Hover;
            public override Color ButtonSelectedGradientBegin => Hover;
            public override Color ButtonSelectedGradientMiddle => Hover;
            public override Color ButtonSelectedGradientEnd => Hover;
            public override Color ButtonSelectedBorder => Acento;
            public override Color ButtonPressedHighlight => Encabezado;
            public override Color ButtonPressedGradientBegin => Encabezado;
            public override Color ButtonPressedGradientMiddle => Encabezado;
            public override Color ButtonPressedGradientEnd => Encabezado;
            public override Color ButtonPressedBorder => Acento;
            public override Color ButtonCheckedGradientBegin => Encabezado;
            public override Color ButtonCheckedGradientMiddle => Encabezado;
            public override Color ButtonCheckedGradientEnd => Encabezado;

            public override Color MenuItemSelected => Hover;
            public override Color MenuItemBorder => Acento;
            public override Color MenuItemSelectedGradientBegin => Hover;
            public override Color MenuItemSelectedGradientEnd => Hover;
            public override Color MenuItemPressedGradientBegin => Encabezado;
            public override Color MenuItemPressedGradientMiddle => Encabezado;
            public override Color MenuItemPressedGradientEnd => Encabezado;

            public override Color OverflowButtonGradientBegin => Superficie;
            public override Color OverflowButtonGradientMiddle => Superficie;
            public override Color OverflowButtonGradientEnd => Superficie;
        }
    }
}
