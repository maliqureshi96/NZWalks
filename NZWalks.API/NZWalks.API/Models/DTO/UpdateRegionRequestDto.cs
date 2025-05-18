﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a min of 3 char")]
        [MaxLength(3, ErrorMessage = "Code has to be a max of 3 char")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Code has to be a max of 100 char")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
