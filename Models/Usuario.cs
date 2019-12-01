using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaisFII.Models;

namespace maisFII.Models {
    [Table ("Usuario")]
    public class Usuario {
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

        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public Endereco Endereco { get; set; } = new Endereco();

        public Usuario()
        {
        }

        public Usuario(int id, string nome, string email, string senha, string confirmacaoSenha, string cpf, DateTime dataNascimento, DateTime criadoEm, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            CriadoEm = criadoEm;
            Endereco = endereco;
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

        public List<Usuario> Listar () {
            return null;
        }
    }
}