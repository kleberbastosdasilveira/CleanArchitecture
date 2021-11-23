﻿using CleanArchitecture.Domain.ResourceValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs.Category.DTO
{
    public class CategoryDeteilDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "NomeInvalido")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ser maior que {2} e no máximo {1} caracteres", MinimumLength = 3)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }
    }
}
