using DemoSQLite1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoSQLite1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPages : ContentPage
    {
        private Empleado empleado;
        public EditPages(Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;
            actualizarButton.Clicked += actualizarButtonClicked;
            borrarButton.Clicked += borrarButtonClicked;

            nombresEntry.Text = empleado.Nombres;
            apellidosEntry.Text = empleado.Apellidos;
            fechaContratoDatePicker.Date = empleado.FechaContrato;
            salariosEntry.Text = empleado.Salario.ToString();
            activoSwitch.IsToggled = empleado.Activo;
        }

        private async void actualizarButtonClicked(Object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombresEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar nombres", "Aceptar");
                nombresEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(apellidosEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar Apellidos", "Aceptar");
                apellidosEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(salariosEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar Salario", "Aceptar");
                salariosEntry.Focus();
                return;
            }

            empleado.Nombres = nombresEntry.Text;
            empleado.Apellidos = apellidosEntry.Text;
            empleado.Salario = decimal.Parse(salariosEntry.Text);
            empleado.FechaContrato = fechaContratoDatePicker.Date;
            empleado.Activo = activoSwitch.IsToggled;

            using (var datos = new DataAccess())
            {
                datos.UpdateEmpleado(empleado);
            }
            await DisplayAlert("Confirmacion", "Empleado actualizado correctamente", "Aceptar");
            await Navigation.PushAsync(new HomePage());
        }

        private async void borrarButtonClicked(Object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Confirmacion", "¿Desea Borrar el empleado?", "Si", "No");

            if (!rta)
            {
                return;
            }
            using (var datos = new DataAccess())
            {
                datos.DeleteEmpleado(empleado);
            }
            await DisplayAlert("Confirmacion", "Empleado Borrado Correctamente", "Aceptar");
            await Navigation.PushAsync(new HomePage());
        }

    }
}