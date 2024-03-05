using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssemblyCrudDotNet8.Shared.Entities
{
    public class VideoGame
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Título é um campo obrigatório")]
        public string Title { get; set; }
        public string? Publisher { get; set; }
        [Range(1900, 2100, ErrorMessage = "O ano deve ser entre 1900 a 2100")]
        public int? ReleaseYear { get; set; }
    }
}
