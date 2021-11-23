using CleanArchitecture.Domain.ResourceValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.DTOs.Product.DTO
{
    public class ProductDetailDTO
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Categoria")]
        public Guid CategoryID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        [DisplayName("Estoque")]
        public int Stock { get; set; }

        [DisplayName("Imagem")]
        public string Image { get; set; }
        public CategoryDTO Category { get; set; }
        public IEnumerable<CategoryDTO> Categorys { get; set; }
    }
}
