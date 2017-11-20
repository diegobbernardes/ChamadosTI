using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChamadosTI.Models
{
    [Table("Chamado")]
    public class Chamado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdChamado { get; set; }
        public string Descricao { get; set; }
        public int Pa { get; set; }

        public int IdTipoChamado { get; set; }
        [ForeignKey("IdTipoChamado")]
        public virtual TipoChamado TipoChamado { get; set; } 

        public int IdRequisitante { get; set; }
        [ForeignKey("IdRequisitante")]
        public virtual Usuario Requisitante{ get; set; }

        public int? IdResponsavel { get; set; }
        [ForeignKey("IdResponsavel")]
        public virtual Usuario Responsavel{ get; set; }

        public int? IdStatus { get; set; } = 1;
        [ForeignKey("IdStatus")]
        public virtual TipoStatus Status { get; set; } 
    }
}