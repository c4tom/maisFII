using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaisFII.Models {
    [Table("Fundo")]
    public class Fundo {
        [Key]
        public int FundoId { get; set; }

        [Display(Name = "Raz�o Social")]
        [Required(ErrorMessage = "Campo obrigat�rio!")]
        [MaxLength(200)]
        public string RazaoSocial { get; set; }

        [Display(Name = "Sigla")]
        [Required(ErrorMessage = "Campo obrigat�rio!")]
        [MaxLength(20)]
        [StringLength(20)]
        public string Sigla { get; set; }

        [Display(Name = "Segmento")]
        [MaxLength(70)]
        [StringLength(10)]
        public string Segmento { get; set; }

        [Display(Name = "Link")]
        [StringLength(250)]
        public string LinkBMF { get; set; }

        public Fundo() { }

        public Fundo(int id, string razaoSocial, string sigla, string segmento, string linkBMF)
        {
            FundoId = id;
            RazaoSocial = razaoSocial;
            Sigla = sigla;
            Segmento = segmento;
            LinkBMF = linkBMF;
        }
    }
}