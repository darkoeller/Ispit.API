using System.ComponentModel.DataAnnotations;

namespace Ispit.Data.Models
{
   public class TodoList
   {
      [Key]
      public int Id { get; set; }
      [Required]
      [StringLength(50)]
      public string Title { get; set; } = string.Empty;
      public string Description { get; set; } = string.Empty;
      public bool IsCompleted { get; set; }
   }
}
