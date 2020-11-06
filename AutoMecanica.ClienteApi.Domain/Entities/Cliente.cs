using AutoMecanica.ClienteApi.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace AutoMecanica.ClienteApi.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; private set; }
        public string Nome { get;  set; }
        public string Documento { get;  set; }
        public string TipoDoc { get; set; }
        public string Endereco { get;  set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Contato { get;  set; }
        public string Email { get;  set; }
        public string Observacao { get;  set; }
        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }

        
        public Cliente() { }


        public Cliente(string nome, string documento, string tipoDoc, string endereco, string numero, string cidade, string estado, string cep, string complemento, string contato, string email, string observacao, string telefone1, string telefone2)
        {
            DataCadastro = DateTime.Now; 
            Nome = nome;
            Documento = documento;
            TipoDoc = tipoDoc;
            Endereco = endereco;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Complemento = complemento;
            Contato = contato;
            Email = email;
            Observacao = observacao;
            Telefone1 = telefone1;
            Telefone2 = telefone2;
        }
    }
}
