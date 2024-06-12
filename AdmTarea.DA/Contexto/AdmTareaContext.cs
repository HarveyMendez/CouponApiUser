using AdmTarea.DA.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AdmTarea.DA.Contexto
{
    public  class AdmTareaContext : DbContext
    {
        public AdmTareaContext(DbContextOptions<AdmTareaContext> options)
            : base(options)
        {
        }
        public DbSet<TareaDA> TareaDA { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TareaDA>().ToTable("Tarea");
        }
    }
}

