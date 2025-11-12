using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniJobBoard.Web.Models
{
    public class Application
    {
        public int Id { get; set; }

        [Required]
        public int JobId { get; set; }

        [ForeignKey("JobId")]
        public Job? Job { get; set; }

        [Required]
        public string ApplicantName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Resume { get; set; }
    }
}
