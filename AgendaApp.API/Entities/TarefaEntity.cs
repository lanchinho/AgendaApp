namespace AgendaApp.API.Entities
{
    public class TarefaEntity
    {
        public Guid Id { get; set; }
        public DateTime? DueTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
