using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaisFII.Models;

namespace maisFII.Models {
    [Table ("Usuario")]
    public class Usuario {
        public Usuario () {
            CriadoEm = DateTime.Now;
            Endereco = new Endereco ();
        }
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [Display(Name = "E-mail:")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Senha:")]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da senha:")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        public string ConfirmacaoSenha { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime CriadoEm { get; set; }

        public ICollection<Carteira> Carteira { get; set; }

        public Endereco Endereco { get; set; }

        public bool Inserir () {
            return false;
        }

        public bool Remover () {
            return false;
        }

        public bool Atualizar () {
            return false;
        }

        public List<Usuario> Listar () {
            return null;
        }
    }
}