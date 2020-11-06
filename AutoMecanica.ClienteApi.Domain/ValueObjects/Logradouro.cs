using AutoMecanica.ClienteApi.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMecanica.ClienteApi.Domain.ValueObjects
{
    public class Logradouro : ValueObject
    {

        public string Endereco { get; private set; }

        public string Numero { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public string Pais { get; private set; }
        public string Cep { get; private set; }

        public string Complemento { get; private set; }




    }
}
