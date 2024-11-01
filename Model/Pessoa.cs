using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gerenciador_de_Tarefas.Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [Column("data_nascimento")]
        public DateTime DataNascimento { get; set; }

        public bool Disponivel { get; set; } = false;

        [JsonIgnore]
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}
