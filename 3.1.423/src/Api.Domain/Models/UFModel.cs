namespace Api.Domain.Models
{
    public class UFModel : BaseModel
    {
        private string _sigla;
        public string Sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }
        

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        
    }
}
