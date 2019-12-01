using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaisFII.Models {
    [Table("Fundo")]
    public class Fundo {
        [Key]
        public int Id { get; set; }

        public string RazaoSocial { get; set; }

        public string Sigla { get; set; }

        public string Segmento { get; set; }

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