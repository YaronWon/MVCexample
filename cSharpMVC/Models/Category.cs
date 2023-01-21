using System.ComponentModel.DataAnnotations;

namespace cSharpMVC.Models;

public class Category
{
    [Key]
    public int ID { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Range(1,100,ErrorMessage ="בין 1 ל100 ")]
    public int DisplayOrder { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now; 
}
