namespace ProjetoModeloDDD.Core.Domain.Entities
{
    public class Cliente
    {
        private string? _nome;
        private string? _sobrenome;
        private string? _email;


        public int ClienteId { get; set; }
        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value.Trim();
            }
        }
        public string Sobrenome
        {
            get
            {
                return _sobrenome;
            }

            set
            {
                _sobrenome = value.Trim();
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value.Trim();
            }
        }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set; }

        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.Ativo && (DateTime.Now.Year - cliente.DataCadastro.Year >= 5);
        }
    }
}
