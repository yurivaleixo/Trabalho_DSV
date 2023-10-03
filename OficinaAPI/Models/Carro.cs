using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaAPI.Models;
public class Carro
{
    [Key]
    public int? CarroId { get; set; }
    public string? Modelo { get; set; }
    public string? Cor { get; set; }
    
    [ForeignKey("ClientId")]
    public int? ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }
}