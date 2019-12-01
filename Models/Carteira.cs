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

        public ICollection<OperacaoCompraVenda> Operacoes { get; set; } = new List<OperacaoCompraVenda>();

        public Carteira() { }

        public Carteira(int id, string nome, string descricao, Usuario usuario)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Usuario = usuario;
        }

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