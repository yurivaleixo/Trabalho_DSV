using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaAPI.Models
{
    public class NotaFiscalPeca
    {
        [Key]
        public int? NotaFiscaPecalId { get; set; }
        public string? Descricao { get; set; }
        public string? NumNota { get; set; }
        public float? Valor { get; set; }
    }
}
