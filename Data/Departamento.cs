using System.Runtime.Serialization;

namespace ProjetoAPI.Data
{
    [DataContract]
    public partial class Departamento
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set;}
        [DataMember]
        public string Sigla { get; set;}
        

    }
}
