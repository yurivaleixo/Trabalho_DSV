using MinhaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MinhaAPI.Data
{
    public class LockheedDbContext : DbContext
    {
        
        public DbSet<Carro>? Carro { get; set; } 
        public DbSet<CheckList>? CheckList { get; set; } 
        public DbSet<CheckListPeca>? CheckListPeca { get; set; } 
        public DbSet<Cliente>? Cliente { get; set; } 
        public DbSet<NotaFiscalPeca>? NotaFiscalPeca { get; set; } 
        public DbSet<NotaFiscalServico>? NotaFiscalServico { get; set; } 
        public DbSet<Peca>? Peca { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=lockheed.db;Cache=Shared");
        }
    }
}
