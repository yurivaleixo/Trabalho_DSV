using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaAPI.Models
{
    public class CheckListPeca
    {
        [Key]
        public int? CheckListPecaId { get; set; }
        
        [ForeignKey("CheckListId")]
        public int? CheckListId { get; set; }
        public virtual CheckList CheckList  { get; set; }
        
        [ForeignKey("PecaId")]
        public int? PecaId { get; set; }
        public virtual Peca Peca  { get; set; }
    

        [ForeignKey("NotaFiscalPecaId")]
        public int? NotaFiscalPecaId { get; set; }
        public virtual NotaFiscalPeca NotaFiscalPeca  { get; set; }
    }
}