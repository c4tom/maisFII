using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaisFII.Models {
    [Table("Fundo")]
    public class Fundo {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(200)]
        public string RazaoSocial { get; set; }

        [Display(Name = "Sigla")]
        [Required(ErrorMessage = "Campo obrigatório!")]
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

        public ICollection<OperacaoCompraVenda> Operacoes { get; set; } = new List<OperacaoCompraVenda>();

        public Fundo() { }

        public Fundo(int id, string razaoSocial, string sigla, string segmento, string linkBMF)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            Sigla = sigla;
            Segmento = segmento;
            LinkBMF = linkBMF;
        }

        public List<Fundo> Listar () {
            return null;
        }

        public bool Inserir () {
            return false;
        }

        public bool Remover () {
            return false;
        }

        public bool Atualizar () {
            return false;
        }

        public void Importar () {

        }

    }
}