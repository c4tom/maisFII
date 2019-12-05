using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaisFII.Models.Enums;

namespace MaisFII.Models {
    [Table("OperacaoCompraVenda")]
    public class OperacaoCompraVenda
    {
        [Key]
        public int OperacaoCompraVendaId { get; set; }

        [Display(Name = "Data da Operação")]
        public DateTime DataOperacao { get; set; }
        [Display(Name = "Quantidade de Cota")]
        public int QuantidadeCota { get; set; }
        [Display(Name = "Valor de cada cota")]
        public float ValorDaCota { get; set; }

        [Display(Name = "Valor da Taxa (corretora)")]
        public float ValorTaxaDaOperadora { get; set; }

        [Display(Name = "Tipo (C/V)")]
        [EnumDataType(typeof(OperacaoTipoEnum))]
        public OperacaoTipoEnum tipo { get; set; }

        public Carteira Carteira { get; set; }

        [Display(Name = "Carteira")]
        public int CarteiraId { get; set; }
        public Fundo Fundo { get; set; } = new Fundo();
        [Display(Name = "Fundo")]
        public int FundoId { get; set; }

        public OperacaoCompraVenda() { }

        public OperacaoCompraVenda(int id, DateTime dataOperacao, int quantidadeCota, float valorDaCota, float valorTaxaDaOperadora, Carteira carteira, Fundo fundo)
        {
            OperacaoCompraVendaId = id;
            DataOperacao = dataOperacao;
            QuantidadeCota = quantidadeCota;
            ValorDaCota = valorDaCota;
            ValorTaxaDaOperadora = valorTaxaDaOperadora;
            Carteira = carteira;
            Fundo = fundo;
        }
    }
}