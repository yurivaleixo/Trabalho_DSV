using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaAPI.Models
{
    public class Peca
    {
        [Key]
        public int? PecaId { get; set; }
        public string? Descricao { get; set; }
        public string? Fornecedor { get; set; }
        public float? Valor { get; set; }
    }
}
