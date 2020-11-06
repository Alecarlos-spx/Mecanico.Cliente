using AutoMecanica.ClienteApi.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMecanica.ClienteApi.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public Nome(string primeiroNome, string ultimoNome, IList<string> notificacoes)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;


            if (string.IsNullOrEmpty(PrimeiroNome))
            {
                notificacoes.Add("Nome inválido");
            }

            if (string.IsNullOrEmpty(UltimoNome))
            {
                notificacoes.Add("Sobrenome inválido");
            }

        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
    }
}
