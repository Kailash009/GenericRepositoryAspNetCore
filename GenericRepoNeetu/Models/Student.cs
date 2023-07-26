using System.ComponentModel.DataAnnotations;

namespace GenericRepoNeetu.Models
{
    public class Student
    {
        [Key]
        public int sid { get; set; }
        public string ?sName { get; set; }
        public int sAge { get; set; }
        public string ?City { get; set; }
    }
}
