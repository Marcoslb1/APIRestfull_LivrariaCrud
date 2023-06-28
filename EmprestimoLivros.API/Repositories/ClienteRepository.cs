using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprestimoLivros.API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EmprestimoLivrosContext _context;

        public ClienteRepository(EmprestimoLivrosContext context)
        {
            _context = context;
        }

        async Task<bool> IClienteRepository.SalvarTudoAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        void IClienteRepository.Alterar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }

        void IClienteRepository.Excluir(Cliente cliente)
        {
            _context.Remove(cliente);
        }

        void IClienteRepository.Incluir(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
        }

        async Task<Cliente> IClienteRepository.SelecionarPorId(int id)
        {
            return await _context.Cliente.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        async Task<IEnumerable<Cliente>> IClienteRepository.SelecionarTodos()
        {
            return await _context.Cliente.ToListAsync();
        }
    }
}
