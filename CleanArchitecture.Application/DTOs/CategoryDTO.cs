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
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}
