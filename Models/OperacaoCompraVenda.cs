using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaisFII.Models.Enums;

namespace MaisFII.Models {
    [Table("OperacaoCompraVenda")]
    public class OperacaoCompraVenda {
        [Key]
        public int Id { get; set; }
        public DateTime DataOperacao { get; set; }

        public int QuantidadeCota { get; set; }

        public float ValorDaCota { get; set; }

        public float ValorTaxaDaOperadora { get; set; }

        public OperacaoTipo OperacaoTipo { get; set; }

        public Carteira Carteira { get; set; }

        public Fundo Fundo { get; set; }

        public OperacaoCompraVenda() { }

        public OperacaoCompraVenda(int id, DateTime dataOperacao, int quantidadeCota, float valorDaCota, float valorTaxaDaOperadora, Carteira carteira, Fundo fundo)
        {
            Id = id;
            DataOperacao = dataOperacao;
            QuantidadeCota = quantidadeCota;
            ValorDaCota = valorDaCota;
            ValorTaxaDaOperadora = valorTaxaDaOperadora;
            Carteira = carteira;
            Fundo = fundo;
        }
    }
}