using LiteDB;
using System.ComponentModel.DataAnnotations;

namespace AgendaApp.Services.Dtos
{
    public class TarefaDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe a data da tarefa.")]
        public DateTime? DueTime { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o título da tarefa.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Informe a descrição da tarefa.")]
        public string Description { get; set; }

        public bool Done { get; set; }
    }
}
