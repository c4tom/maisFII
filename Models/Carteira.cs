using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using maisFII.Models;

namespace MaisFII.Models {
    [Table("Carteira")]
    public class Carteira {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Fundo> Fundo { get; set; }

        public List<Carteira> Listar () {
            return null;
        }

        public bool Remover () {
            return false;
        }

        public bool Inserir () {
            return false;
        }

        public bool Atualizar () {
            return false;
        }

    }

}