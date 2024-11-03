using Gerenciador_de_Tarefas.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_de_Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : Controller
    {

        private readonly AppDbContext _context;


        public TarefaController(AppDbContext context) 
        {
            _context = context;
        }


        // Endpoint para criação de tarefas.
        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
        }

        // Endpoint para pegar todas as tarefas
        [HttpGet]
        public async Task<ActionResult<Tarefa>> GetTarefas()
        {

            var tarefas = await _context.Tarefas.ToListAsync();
            return Ok(tarefas);

        }

        // Endpoint para pegar tarefa pelo id
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            var tarefa = await _context.Tarefas.Include(t => t.PessoaResponsavel).FirstOrDefaultAsync(t => t.Id == id);
            if (tarefa == null) return NotFound();
            return tarefa;
        }

        // Endpoint para atualizar tarefas
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id) return BadRequest();
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Endpoint para associar tarefa a uma pessoa
        [HttpPut("{id}/associar/{pessoaId}")]
        public async Task<IActionResult> AssociarTarefa(int id, int pessoaId)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            var pessoa = await _context.Pessoas.FindAsync(pessoaId);
            if (tarefa == null || pessoa == null) return NotFound();

            tarefa.IdPessoaResponsavel = pessoaId;
            pessoa.Disponivel = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Endpoint para desassociar tarefa de uma pessoa
        [HttpPut("{id}/desassociar")]
        public async Task<IActionResult> DesassociarTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();

            tarefa.IdPessoaResponsavel = null;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Excluir tarefa
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
