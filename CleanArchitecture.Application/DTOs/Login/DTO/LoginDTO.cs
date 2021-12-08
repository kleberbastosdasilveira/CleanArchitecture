using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs.Login.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = " O Email é nescessária")]
        [EmailAddress(ErrorMessage = "Formato de Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é nescessária")]
        //[StringLength(20, ErrorMessage = "O {0} número máximo de caracteres é {2} entre {1} caracteres ", MinimumLength = 10)]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public string Passoword { get; set; }
    }
}
