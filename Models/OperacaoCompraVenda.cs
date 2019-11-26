using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaisFII.Models {
    [Table("Operacao")]
    public class OperacaoCompraVenda {
        [Key]
        public int Id { get; set; }
        public DateTime DataOperacao { get; set; }

        public int QuantidadeCota { get; set; }

        public float ValorDaCota { get; set; }

        public float ValorTaxaDaOperadora { get; set; }

        // https://docs.microsoft.com/pt-br/ef/ef6/modeling/code-first/data-types/enums
        public OperacaoTipo Operacao { get; set; }

        public Carteira Carteira { get; set; }

        public Fundo Fundo { get; set; }
    }
}