using System.ComponentModel.DataAnnotations;
using backe.models.Repositori;

namespace bake.models;

public class Person:Rperson
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }

    

    [Required]
    public string Password { get; set; }
    
}