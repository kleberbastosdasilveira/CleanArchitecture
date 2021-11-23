using CleanArchitecture.Domain.ResourceValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "NomeInvalido")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ser maior que {2} e no máximo {1} caracteres", MinimumLength =3)]
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}
