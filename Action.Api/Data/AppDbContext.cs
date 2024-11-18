using Action.Api.Enum;
using Action.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Action.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Solicitacao>? Solicitacoes { get; set; }
        public DbSet<DataAction>? DataActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Solicitacao

            modelBuilder.Entity<Solicitacao>().HasKey(s => s.Id);
            modelBuilder.Entity<Solicitacao>().Property(s => s.EmailSolicitante).IsRequired();
            modelBuilder.Entity<Solicitacao>().Property(s => s.DataSolicitacao).IsRequired();
            modelBuilder.Entity<Solicitacao>().Property(s => s.Aprovador).IsRequired();
            //modelBuilder.Entity<Solicitacao>().Property(s => s.Status).HasDefaultValue(StatusSolicitacao.PendenteAprovacao).IsRequired();
            modelBuilder.Entity<Solicitacao>().Property(s => s.Status).IsRequired();
            modelBuilder.Entity<Solicitacao>().HasMany(s => s.Actions).WithOne().IsRequired();

            #endregion

            #region DataAction

            modelBuilder.Entity<DataAction>().HasKey(d => d.Id);
            modelBuilder.Entity<DataAction>().HasIndex(d => d.Action).IsUnique();
            modelBuilder.Entity<DataAction>().Property(d => d.Business).IsRequired();
            modelBuilder.Entity<DataAction>().Property(d => d.BusinessChannel).IsRequired();
            modelBuilder.Entity<DataAction>().Property(d => d.Environment).IsRequired();
            modelBuilder.Entity<DataAction>().Property(d => d.CustomPath).IsRequired();
            modelBuilder.Entity<DataAction>().Property(d => d.GA4).IsRequired();
            modelBuilder.Entity<DataAction>().Property(d => d.DualTagging).IsRequired();
            modelBuilder.Entity<DataAction>().Property(d => d.InteractionStudio).IsRequired();
            modelBuilder.Entity<DataAction>().Property(d => d.FullStory).IsRequired();

            #endregion
        }
    }
}