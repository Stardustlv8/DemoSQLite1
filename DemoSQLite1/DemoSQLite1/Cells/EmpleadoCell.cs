using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoSQLite1.Cells
{
    class EmpleadoCell: ViewCell
    {
        public EmpleadoCell()
        {
            var idEmpleadoLabel = new Label
            {
                HorizontalOptions = LayoutOptions.End,
                HorizontalTextAlignment = TextAlignment.End
            };
            idEmpleadoLabel.SetBinding(Label.TextProperty, new Binding("IDEmpleado"));

            var nombresLabel = new Label
            {
                HorizontalOptions = LayoutOptions.End,

            };
            nombresLabel.SetBinding(Label.TextProperty, new Binding("Nombres"));

            var apellidosLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand

            };
            apellidosLabel.SetBinding(Label.TextProperty, new Binding("Apellidos"));

            var fechaContratoLabel = new Label
            {
                HorizontalOptions = LayoutOptions.End,
            };
            fechaContratoLabel.SetBinding(Label.TextProperty, new Binding("FechaContrato"));

            var salarioLabel = new Label
            {
                HorizontalOptions=LayoutOptions.EndAndExpand,
                HorizontalTextAlignment = TextAlignment.End
            };
            salarioLabel.SetBinding(Label.TextProperty, new Binding("SalarioEditado"));

            var activoSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Start,
                IsEnabled = false
            };
            activoSwitch.SetBinding(Switch.IsToggledProperty, new Binding("Activo"));

            var line1 = new StackLayout
            {
                Children =
                {
                    idEmpleadoLabel,
                    nombresLabel,
                    apellidosLabel,
                },
                Orientation = StackOrientation.Horizontal
            };
            var line2 = new StackLayout
            {
                Children =
                {
                    fechaContratoLabel,
                    salarioLabel,
                    activoSwitch
                },
                Orientation = StackOrientation.Horizontal

            };


            View = new StackLayout
            {
                Children =
                {
                    line1, line2
                },
                Orientation = StackOrientation.Vertical

            };
        }
    }
}
