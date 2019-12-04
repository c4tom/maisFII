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

        // [RegularExpression(@"^[A-Z]+[a-zA-Z'\s\p{L}]*$", ErrorMessage = "Somente Caracteres e espa�o, e a primeira letra em mai�scula")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigat�rio!")]
        [MaxLength(70)]
        [StringLength(70)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio!")]
        [Display(Name = "E-mail:")]
        [EmailAddress]
        [StringLength(70)]
        public string Email { get; set; }

        [Display(Name = "Senha:")]
        [StringLength(32)]
        public string Senha { get; set; }

        [Display(Name = "Confirma��o da senha:")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "Os campos n�o coincidem!")]
        public string ConfirmacaoSenha { get; set; }

        [Display(Name = "CPF")]
        [StringLength(16)]
        [Required(ErrorMessage = "Campo obrigat�rio!")]
        public string Cpf { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo obrigat�rio!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public Endereco Endereco { get; set; } = new Endereco();

        public Usuario()
        {
        }

        public Usuario(int id, string nome, string email, string senha, string cpf, DateTime dataNascimento, DateTime criadoEm, Endereco endereco)
        {
            UsuarioId = id;
            Nome = nome;
            Email = email;
            Senha = senha;
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