using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Documento { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}
