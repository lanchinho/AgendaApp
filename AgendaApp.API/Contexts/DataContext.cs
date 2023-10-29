using AgendaApp.API.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary>
        /// Adicionar os mapeamentos das entidades
        /// </summary>        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMapping());
        }
    }
}
