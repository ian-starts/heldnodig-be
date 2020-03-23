using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HeldNodig.Enums;

namespace HeldNodig.Dtos
{
    public class HelpRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DefaultValue("Available")]
        public Status Status { get; set; }
    }
}