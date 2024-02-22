using System.Runtime.Serialization;

namespace ProjetoAPI.Data
{
    [DataContract]
    public partial class Funcionario
    {
        public static string ContentRootPath { get; internal set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        
        [DataMember]
        public int DepartamentoId { get; set; }
        
        public string Rg { get; set; }
        
        
        
        
    }
}
