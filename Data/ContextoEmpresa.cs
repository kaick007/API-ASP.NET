using Microsoft.EntityFrameworkCore;

namespace ProjetoAPI.Data
{   
    public class ContextoEmpresa : DbContext
    {
        public ContextoEmpresa(DbContextOptions<ContextoEmpresa> options) : base(options) 
        {
            
        }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }

       
        
    }
}
