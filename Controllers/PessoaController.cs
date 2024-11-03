using Gerenciador_de_Tarefas.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_de_Tarefas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly AppDbContext? _context;

        public PessoaController(AppDbContext context) 
        {
            _context = context;

        }

        // Endpoint para cadastrar uma pesoa
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa) 
        {   
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
        }

        // Endpoint para ler todas as pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            var pessoas = await _context.Pessoas.ToListAsync();
            return Ok(pessoas);
        }


        // Endpoint para ler uma pessoa pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null) return NotFound();
            return pessoa;
        }

        // Endpoint para atualizar uma pessoa
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id) return BadRequest();
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        // Endpoint para deletar pessoa
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            var pessoa = await _context.Pessoas.Include(p => p.Tarefas)
                                               .FirstOrDefaultAsync(p => p.Id == id);
            if (pessoa == null) return NotFound();
            if (pessoa.Tarefas.Any(t => t.Status != "concluída"))
                return BadRequest("Não é possível excluir uma pessoa com tarefas pendentes.");

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
