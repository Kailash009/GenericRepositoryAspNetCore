using System.ComponentModel.DataAnnotations;

namespace GenericRepoNeetu.Models
{
    public class Teacher
    {
        [Key]
        public int tid { get; set; }
        public string? tName { get; set; }
        public int tAge { get; set; }
        public string? tCity { get; set; }
    }
}
