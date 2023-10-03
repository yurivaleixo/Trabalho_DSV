using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaAPI.Models
{
    public class CheckList
    {
        [Key]
        public int? CheckListId { get; set; }
        public string? Descricao { get; set; }
        public string? OrdemServico { get; set; }
        
        [ForeignKey("CarroId")]
        public int? CarroId { get; set; }
        public virtual Carro Carro { get; set; }

        [ForeignKey("NotaFiscalServicoId")]
        public int? NotaFiscalServicoId { get; set; }
        public virtual NotaFiscalServico NotaFiscalServico  { get; set; }
    }
}
