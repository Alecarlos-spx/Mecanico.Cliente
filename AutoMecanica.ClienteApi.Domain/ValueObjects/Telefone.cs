using AutoMecanica.ClienteApi.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMecanica.ClienteApi.Domain.ValueObjects
{
    public class Telefone : ValueObject
    {
        public Telefone(string telefones)
        {
            Telefones = telefones;




        }

        public string Telefones { get; private set; }

        
    }
}
