using CleanArchitecture.Application.DTOs.Address;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs.User.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public AddressDTO Endereco { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Confirme o Senha")]
        [Compare("Password",ErrorMessage ="O password não são identicos")]
        [DisplayName("Confirme Senha")]
        public string ConfirmPassword { get; set; }
    }
}
