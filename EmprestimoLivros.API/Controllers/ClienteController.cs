using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository cliente)
        {
            _clienteRepository = cliente;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return Ok(await _clienteRepository.SelecionarTodos());
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarCliente(Cliente cliente)
        {
            _clienteRepository.Incluir(cliente);

            if(await _clienteRepository.SalvarTudoAsync())
            {
                return Ok("Cliente cadastrado com sucesso!");
            }
            else
            {
                return BadRequest("Ocorreu um erro ao salvar o cliente!");
            }
        }

        [HttpPut]
        public async Task<ActionResult> AlterarCliente(Cliente cliente)
        {
            _clienteRepository.Alterar(cliente);

            if (await _clienteRepository.SalvarTudoAsync())
            {
                return Ok("Cliente Alterado com sucesso!");
            }
            else
            {
                return BadRequest("Ocorreu um erro ao alterar o cliente!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarCliente(int id)
        {
            var cliente = await _clienteRepository.SelecionarPorId(id);
            if(cliente == null)
            {
                return NotFound("usuário não encontrado");
            }

            _clienteRepository.Excluir(cliente);

            if (await _clienteRepository.SalvarTudoAsync())
            {
                return Ok("Cliente deletado com sucesso!");
            }
            else
            {
                return BadRequest("Ocorreu um erro ao deletado o cliente!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> SelecionarCliente(int id)
        {
            var cliente = await _clienteRepository.SelecionarPorId(id);

            if(cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }
            return Ok(cliente);
        }
    }
}
