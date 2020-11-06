using AutoMecanica.ClienteApi.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoMecanica.ClienteApi.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string enderecoEmail, IList<string> notificacoes)
        {
            EnderecoEmail = enderecoEmail;

            if (!Validar())
            {
                notificacoes.Add("Email inválido");
            }
        }

        public string EnderecoEmail { get; private set; }


        public bool Validar()
        {
            return Regex.IsMatch(EnderecoEmail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }


    }
}
