using System.ComponentModel.DataAnnotations;

namespace backe.models;

public class Person
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string PasswordSh { get; set; }
    
}