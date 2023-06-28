using EmprestimoLivros.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmprestimoLivros.API.Interfaces
{
    public interface IClienteRepository
    {
        public void Incluir(Cliente cliente);
        public void Alterar(Cliente cliente);
        public void Excluir(Cliente cliente);
        public Task<Cliente> SelecionarPorId(int id);
        public Task<IEnumerable<Cliente>> SelecionarTodos();
        public Task<bool> SalvarTudoAsync();

    }
}
