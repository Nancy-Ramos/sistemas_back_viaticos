using ApiSystemsATSM.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSystemsATSM.Data
{
    public class AtsmContext : DbContext
    {
        public AtsmContext(DbContextOptions<AtsmContext> options) 
            : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<ConceptoModel> Concepto { get; set; }
        public DbSet<CorteModel> Corte { get; set; }
    }
}