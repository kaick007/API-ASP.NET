using ProjetoAPI.Data;
using System.Runtime.Serialization;

namespace ProjetoAPI.ModelView
{
    public class VFuncionario
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DepartamentoId { get; set; }
        public string Rg { get; set; }
    }
}
