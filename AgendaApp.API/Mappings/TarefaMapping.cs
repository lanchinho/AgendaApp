using AgendaApp.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApp.API.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<TarefaEntity>
    {
        public void Configure(EntityTypeBuilder<TarefaEntity> builder)
        {
            builder.ToTable("T_TAREFA");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(t => t.DueTime)
                .HasColumnName("DUETIME")
                .IsRequired();

            builder.Property(t => t.Title)
                .HasColumnName("TITLE")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Done)
                .HasColumnName("DONE")
                .IsRequired();

        }
    }
}
