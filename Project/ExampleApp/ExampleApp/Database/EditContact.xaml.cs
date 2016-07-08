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
            : base()
        {
            InitializeComponent();

            _contato = contato;
            Title = "Manter";
            Deletar.IsVisible = true;

            SetDados();
        }

        public EditContact()
        {
            InitializeComponent();

            _contato = new Contato();
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

                if (Salvar.CommandParameter == null)
                {
                    dados.Insert(_contato);
                }
                else
                {
                    _contato.Id = int.Parse(Salvar.CommandParameter.ToString());
                    dados.Update(_contato);
                }

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
