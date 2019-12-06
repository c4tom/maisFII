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
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public DateTime DataOperacao { get; set; }
        [Display(Name = "Quantidade de Cota")]
        public int QuantidadeCota { get; set; }
        [Display(Name = "Valor de cada cota")]
        public double ValorDaCota { get; set; }

        [Display(Name = "Valor da Taxa (corretora)")]
        public double ValorTaxaDaOperadora { get; set; }

        [Display(Name = "Tipo (C/V)")]
        [EnumDataType(typeof(OperacaoTipoEnum))]
        public OperacaoTipoEnum tipo { get; set; } = new OperacaoTipoEnum();

        [Required]
        [Display(Name = "Carteira")]
        public int CarteiraId { get; set; }

        public virtual Carteira Carteira { get; set; }
        
        [Display(Name = "Fundo")]
        [Required]
        public int FundoId { get; set; }

        public virtual Fundo Fundo { get; set; }

        public OperacaoCompraVenda() { }

        public OperacaoCompraVenda(int operacaoCompraVendaId, DateTime dataOperacao, int quantidadeCota, float valorDaCota, float valorTaxaDaOperadora, OperacaoTipoEnum tipo, int carteiraId, int fundoId)
        {
            OperacaoCompraVendaId = operacaoCompraVendaId;
            DataOperacao = dataOperacao;
            QuantidadeCota = quantidadeCota;
            ValorDaCota = valorDaCota;
            ValorTaxaDaOperadora = valorTaxaDaOperadora;
            this.tipo = tipo;
            CarteiraId = carteiraId;
            FundoId = fundoId;
        }
    }
}