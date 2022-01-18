using System.ComponentModel.DataAnnotations;

namespace CRUD_RestAPI.Modeld
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage ="The name must be less than 100 character.")]
        public string Name { get; set; }
    }
}
