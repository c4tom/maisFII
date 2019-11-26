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
        public int Id { get; set; }

        [Display (Name = "Rua:")]
        public string Logradouro { get; set; }

        [Display (Name = "CEP:")]
        public string Cep { get; set; }

        [Display (Name = "Bairro:")]
        public string Bairro { get; set; }

        [Display (Name = "Cidade:")]
        public string Localidade { get; set; }

        [Display (Name = "Estado:")]
        public string Uf { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}