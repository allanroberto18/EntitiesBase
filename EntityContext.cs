using System;
using System.Data.Entity;
using Entities.Bases.Context;
using Entities.Models;

namespace Entities
{
    public class EntityContext : DbContext, IUnitOfWork
    {
        public EntityContext() 
            : base("name=EntityContext")
        {
            Database.SetInitializer<EntityContext>(new EntityContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuariosAcessos>()
                    .HasRequired<Usuarios>(s => s.Usuario)
                    .WithMany(s => s.UsuariosAcessos)
                    .HasForeignKey(s => s.UsuarioId);

            modelBuilder.Entity<AgendasMensagens>()
                    .HasRequired<Mensagens>(s => s.Mensagem)
                    .WithMany(s => s.AgendasMensagens)
                    .HasForeignKey(s => s.MensagemId);

            modelBuilder.Entity<ContatosMensagens>()
                    .HasRequired<Contatos>(s => s.Contato)
                    .WithMany(s => s.ContatosMensagens)
                    .HasForeignKey(s => s.ContatoId);

            modelBuilder.Entity<ContatosMensagens>()
                    .HasRequired<Mensagens>(s => s.Mensagem)
                    .WithMany(s => s.ContatosMensagens)
                    .HasForeignKey(s => s.MensagemId);

            modelBuilder.Entity<GruposContatos>()
                    .HasRequired<Contatos>(s => s.Contato)
                    .WithMany(s => s.GruposContatos)
                    .HasForeignKey(s => s.ContatoId);

            modelBuilder.Entity<GruposContatos>()
                    .HasRequired<Grupos>(s => s.Grupo)
                    .WithMany(s => s.GruposContatos)
                    .HasForeignKey(s => s.GrupoId);

            modelBuilder.Entity<GruposMensagens>()
                    .HasRequired<Grupos>(s => s.Grupo)
                    .WithMany(s => s.GruposMensagens)
                    .HasForeignKey(s => s.GrupoId);

            modelBuilder.Entity<GruposMensagens>()
                    .HasRequired<Mensagens>(s => s.Mensagem)
                    .WithMany(s => s.GruposMensagens)
                    .HasForeignKey(s => s.MensagemId);

            modelBuilder.Entity<MensagensDisparos>()
                    .HasRequired<Mensagens>(s => s.Mensagem)
                    .WithMany(s => s.MensagensDisparos)
                    .HasForeignKey(s => s.MensagemId);

            modelBuilder.Entity<MensagensDisparos>()
                    .HasRequired<Contatos>(s => s.Contato)
                    .WithMany(s => s.MensagensDisparos)
                    .HasForeignKey(s => s.ContatoId);

            modelBuilder.Entity<CodigosPromocionais>()
                    .HasRequired<Promocoes>(s => s.Promocao)
                    .WithMany(s => s.CodigosPromocionais)
                    .HasForeignKey(s => s.PromocaoId);

            modelBuilder.Entity<CodigosPromocionais>()
                    .HasRequired<Contatos>(s => s.Contato)
                    .WithMany(s => s.CodigosPromocionais)
                    .HasForeignKey(s => s.ContatoId);

            modelBuilder.Entity<Promocoes>()
                    .HasRequired<Mensagens>(s => s.Mensagem)
                    .WithMany(s => s.Promocoes)
                    .HasForeignKey(s => s.MensagemId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Licencas> Licencas { get; set; }

        public DbSet<Configuracoes> Configuracoes { get; set; }

        public DbSet<Contatos> Contatos { get; set; }

        public DbSet<Mensagens> Mensagens { get; set; }

        public DbSet<AgendasMensagens> AgendasMensagens { get; set; }

        public DbSet<ContatosMensagens> ContatosMensagens { get; set; }

        public DbSet<Grupos> Grupos { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<UsuariosAcessos> UsuariosAcessos { get; set; }
        
        public DbSet<GruposContatos> GruposContatos { get; set; }

        public DbSet<GruposMensagens> GruposMensagens { get; set; }

        public DbSet<MensagensDisparos> MensagensDisparos { get; set; }

        public DbSet<CodigosPromocionais> CodigosPromocionais { get; set; }

        public DbSet<Promocoes> Promocoes { get; set; }
        
        public DbSet<Sims> Sims { get; set; }

        public void Save()
        {
            base.SaveChanges();
        }
    }
}
