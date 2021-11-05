using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ResourceValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "NomeInvalido")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get;  set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "DescricaoInvalida")]
        [MinLength(5)]
        [MaxLength(100)]
        [DisplayName("Descrição")]
        public string Description { get;  set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PrecoInvalido")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Price { get;  set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "QuantidadeInvalida")]
        [Range(1, 9999)]
        [DisplayName("Estoque")]
        public int Stock { get;  set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get;  set; }

        public Guid CategoryId { get; set; }

        [DisplayName("Categorias")]
        public Category Category { get; set; }
    }
}
