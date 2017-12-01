using ChamadosTI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ChamadosTI.Contexto
{
    public class DBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<TipoChamado> TipoChamado { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }



        public System.Data.Entity.DbSet<ChamadosTI.Models.TipoStatus> Status { get; set; }

        public System.Data.Entity.DbSet<ChamadosTI.Models.TipoUsuario> TipoUsuarios { get; set; }
    }
}