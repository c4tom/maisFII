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

        public ICollection<HistoricoFundo> HistoricoFundo;

        public Carteira carteira { get; set; }

        public ICollection<OperacaoCompraVenda> OperacaoCompraVenda;

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