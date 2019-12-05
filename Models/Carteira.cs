using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaisFII.Models {
    [Table("Carteira")]
    public class Carteira {
        [Key]
        public int CarteiraId { get; set; }

        [Display(Name = "Carteira")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(70)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public virtual IEnumerable<Usuario> UsuarioLista { get; set; }

        public Carteira() { }

        public Carteira(int id, string nome, string descricao, Usuario usuario)
        {
            CarteiraId = id;
            Nome = nome;
            Descricao = descricao;
            Usuario = usuario;
        }

    }

}