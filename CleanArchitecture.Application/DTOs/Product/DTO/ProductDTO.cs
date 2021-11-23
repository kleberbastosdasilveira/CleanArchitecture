using CleanArchitecture.Domain.ResourceValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.DTOs
{
    public class ProductDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Categoria")]
        public Guid CategoryID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "NomeInvalido")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ser maior que {2} e no máximo {1} caracteres", MinimumLength = 3)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "DescricaoInvalida")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ser maior que {2} e no máximo {1} caracteres", MinimumLength = 3)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PrecoInvalido")]
        [RegularExpression(@"^[0-9]\d*(\,[0-9]{0,2})?$", ErrorMessage = "{0} inserido está incorreto")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} inserido está incorreto")]
        [Range(1, 9999, ErrorMessage = "{0} inserido está incorreto")]
        [DisplayName("Estoque")]
        public int Stock { get; set; }


        [DisplayName("Imagem do Produto")]
        public IFormFile ImagemUpload { get; set; }
        public string Image { get; set; }
        public CategoryDTO Category { get; set; }
        public IEnumerable<CategoryDTO> Categorys { get; set; }
    }
}
