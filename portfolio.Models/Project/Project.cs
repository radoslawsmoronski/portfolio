﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace portfolio.Models.Project
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string NameENG { get; set; } = "";
        [Required]
        [MaxLength(25)]
        public string NamePL { get; set; } = "";
        [Required]
        [MaxLength(150)]
        public string DescriptionENG { get; set; } = "";
        [Required]
        [MaxLength(150)]
        public string DescriptionPL { get; set; } = "";
        public string? GitRepositoryUrl { get; set; }
        public string? ProjectWebsiteUrl { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }

    }
}
