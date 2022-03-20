﻿using System.ComponentModel.DataAnnotations;

namespace LoanAppWebAPI.DTO.Businesses
{
    public class BusinessRequestDto
    {
        [Key]
        public int Id { get; set; }
        public string? BusinessCode { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int OwnerId { get; set; }
        public string? UserRequested { get; set; }
    }
}
