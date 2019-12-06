using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaisFII.Models;

namespace MaisFII.Models {
    [Table ("Usuario")]
    public class Usuario {
        [Key]
        public int UsuarioId { get; set; }

        // [RegularExpression(@"^[A-Z]+[a-zA-Z'\s\p{L}]*$", ErrorMessage = "Somente Caracteres e espaço, e a primeira letra em maiúscula")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(70)]
        [StringLength(70)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "E-mail:")]
        [EmailAddress]
        [StringLength(70)]
        public string Email { get; set; }

        [Display(Name = "Senha:")]
        [StringLength(32)]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da senha:")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        public string ConfirmacaoSenha { get; set; }

        [Display(Name = "CPF")]
        [StringLength(16)]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cpf { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public Endereco Endereco { get; set; } = new Endereco();

        public Usuario()
        {
        }

        public Usuario(int usuarioId, string nome, string email, string senha, string confirmacaoSenha, string cpf, DateTime dataNascimento, DateTime criadoEm, Endereco endereco)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            CriadoEm = criadoEm;
            Endereco = endereco;
        }
    }
}