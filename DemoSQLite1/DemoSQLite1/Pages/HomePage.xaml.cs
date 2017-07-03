using DemoSQLite1.Cells;
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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
           
            listaListView.ItemTemplate = new DataTemplate(typeof(EmpleadoCell));

            listaListView.ItemTapped += listaView_ItemTapped;

            agregarButton.Clicked += agregarButtonClicked;

            using (var datos = new DataAccess())
            {
                listaListView.ItemsSource = datos.GetEmpleados();
            }
        }
        private async void listaView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new EditPages(e.Item as Empleado));
        }

        private async void agregarButtonClicked(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(salarioEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar Salario", "Aceptar");
                salarioEntry.Focus();
                return;
            }

            Empleado empleado = new Empleado()
            {
                Nombres = nombresEntry.Text,
                Apellidos = apellidosEntry.Text,
                FechaContrato = fechaContratoDatePicker.Date,
                Salario = decimal.Parse(salarioEntry.Text),
                Activo = activoSwitch.IsToggled
            };

            using (var datos = new DataAccess())
            {
                datos.InsertEmpleado(empleado);
                listaListView.ItemsSource = datos.GetEmpleados();
            }

            nombresEntry.Text = string.Empty;
            apellidosEntry.Text = string.Empty;
            salarioEntry.Text = string.Empty;
            fechaContratoDatePicker.Date = DateTime.Now;
            activoSwitch.IsToggled = true;
            await DisplayAlert("Confirmacion", "Empleado agregado", "Aceptar");
        }

    }
}