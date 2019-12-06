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

        [Display(Name = "Usuário")]
        [Required]
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public Carteira() { }

        public Carteira(int carteiraId, string nome, string descricao, int usuarioId, Usuario usuario)
        {
            CarteiraId = carteiraId;
            Nome = nome;
            Descricao = descricao;
            UsuarioId = usuarioId;
            Usuario = usuario;
        }
    }

}