using System;
using System.ComponentModel.DataAnnotations;

namespace FADY.WebMVC.Services.ModelDTOs
{
    public record EmployeeDTO
    {
        [Required]
        public string City { get; init; }
        [Required]
        public string Street { get; init; }
      
        [Required]
        public string Country { get; init; }


    }
}

