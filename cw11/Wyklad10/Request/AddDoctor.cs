using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace Wyklad10.Request
{
    public class AddDoctor
    {
        [Required]
        public int IdDoctor { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Email]
        public string Email { get; set; }
    }
}
