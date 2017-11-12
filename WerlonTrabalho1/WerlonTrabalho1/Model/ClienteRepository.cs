using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite.Net;

namespace WerlonTrabalho1.Model
{
    class ClienteRepository : IDisposable
    {
        private SQLiteConnection _conexao;

        public ClienteRepository()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "werlont1.db3"));
            _conexao.CreateTable<Cliente>();
        }

        public void Insert(Cliente cliente) {
            _conexao.Insert(cliente);
        }

        public void Update(Cliente cliente)
        {
            _conexao.Update(cliente);
        }

        public void Delete(Cliente cliente)
        {
            _conexao.Delete(cliente);
        }

        public List<Cliente> Listar()
        {
            return _conexao.Table<Cliente>().OrderBy(c => c.Nome).ToList();
        }

        public Cliente ObterPorId(int Id)
        {
            return _conexao.Table<Cliente>().FirstOrDefault(c => c.Id == Id);
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
