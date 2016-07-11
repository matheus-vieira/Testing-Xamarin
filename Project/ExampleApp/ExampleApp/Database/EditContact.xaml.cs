using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExampleApp.Database
{
    public partial class EditContact : ContentPage
    {
        private Contato _contato;
        public EditContact(Contato contato)
        {
            InitializeComponent();

            _contato = contato ?? new Contato();

            Title = contato != null ? "Manter" : "Novo";
            Deletar.IsVisible = contato != null;

            SetDados();
        }

        protected void DeletarClicked(object sender, EventArgs e)
        {
            using (var dados = new DAO())
            {
                dados.Delete(_contato);

                Navigation.PopAsync();
            }
        }

        protected void SalvarClicked(object sender, EventArgs e)
        {
            using (var dados = new DAO())
            {
                _contato.Nome = Nome.Text;
                _contato.Email = Email.Text;
                _contato.Telefone = Telefone.Text;
                _contato.Id = int.Parse(Salvar.CommandParameter.ToString());

                dados.Save(_contato);

                Navigation.PopAsync();
            }
        }

        private void SetDados()
        {
            Salvar.CommandParameter = _contato.Id;
            Nome.Text = _contato.Nome ?? string.Empty;
            Email.Text = _contato.Email ?? string.Empty;
            Telefone.Text = _contato.Telefone ?? string.Empty;
        }
    }
}
