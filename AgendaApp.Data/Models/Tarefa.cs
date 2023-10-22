using LiteDB;

namespace AgendaApp.Data.Models
{
    public class Tarefa
    {
        public ObjectId Id { get; set; }
        public DateTime? DueTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
