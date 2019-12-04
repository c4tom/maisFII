using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaisFII.Models {
    [Table ("Endereco")]
    public class Endereco {
        public Endereco () {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int EnderecoId { get; set; }

        [Display (Name = "Rua:")]
        [StringLength(90)]
        public string Logradouro { get; set; }

        [Display (Name = "CEP:")]
        [StringLength(9)]
        public string Cep { get; set; }

        [Display (Name = "Bairro:")]
        [StringLength(70)]
        public string Bairro { get; set; }

        [Display (Name = "Cidade:")]
        [StringLength(70)]
        public string Localidade { get; set; }

        [Display (Name = "Estado:")]
        [StringLength(2)]
        public string Uf { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}