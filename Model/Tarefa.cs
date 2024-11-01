using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gerenciador_de_Tarefas.Model
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } = "pendente"; // ou usar o enum

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Column("id_pessoa_responsavel")]
        public int? IdPessoaResponsavel { get; set; }

        [JsonIgnore]
        public Pessoa? PessoaResponsavel { get; set; }
        
    }
}
