using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WerlonTrabalho1.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WerlonTrabalho1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private Cliente _cliente = null;
        public MainPage()
        {
            InitializeComponent();
            this.ListarTodos();
        }

        private void ListarTodos()
        {
            using (var dados = new ClienteRepository())
            {
                this.Lista.ItemsSource = dados.Listar();
            }
        }

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            var cliente = new Cliente {
                Nome = this.Nome.Text,
                Sobrenome = this.Sobrenome.Text,
                Cpf = this.Cpf.Text,
                Email = this.Email.Text
            };

            using (var dados = new ClienteRepository())
            {
                if (this._cliente != null)
                {
                    _cliente.Nome = this.Nome.Text;
                    _cliente.Sobrenome = this.Sobrenome.Text;
                    _cliente.Cpf = this.Cpf.Text;
                    _cliente.Email = this.Email.Text;
                    dados.Update(this._cliente);
                }
                else
                {
                    if (this.Nome != null)
                    {
                        this._cliente = new Cliente
                        {
                            Nome = this.Nome.Text,
                            Sobrenome = this.Sobrenome.Text,
                            Cpf = this.Cpf.Text,
                            Email = this.Email.Text
                        };
                        dados.Insert(this._cliente);
                    }
                }
                
                ListarTodos();
                LimparCampos();

            }
        }

        private void Editar_Clicked(object sender, EventArgs e)
        {
            this._cliente = this.Lista.SelectedItem as Cliente;
            if(this._cliente != null)
            {
                this.Nome.Text = this._cliente.Nome;
                this.Sobrenome.Text = this._cliente.Sobrenome;
                this.Email.Text = this._cliente.Email;
                this.Cpf.Text = this._cliente.Cpf;
            }
        }

        private void Excluir_Clicked(object sender, EventArgs e)
        {
            this._cliente = this.Lista.SelectedItem as Cliente;
            if (this._cliente != null)
            {
                using (var dados = new ClienteRepository())
                {
                    dados.Delete(this._cliente);

                    LimparCampos();
                    ListarTodos();
                    
                }
            }
        }

        private void LimparCampos()
        {
            this.Nome.Text = "";
            this.Sobrenome.Text = "";
            this.Email.Text = "";
            this.Cpf.Text = "";
            this._cliente = null;
        }
    }
}
