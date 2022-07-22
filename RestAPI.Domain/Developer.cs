using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Domain
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DeveloperName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string GithubURL { get; set; }
        [Required]
        public string Department { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.Now;
    }
}
