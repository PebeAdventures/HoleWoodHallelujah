﻿using System.ComponentModel.DataAnnotations;

namespace TvSeriesApi.DTO.Genre
{
    public class GenreUpdateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}