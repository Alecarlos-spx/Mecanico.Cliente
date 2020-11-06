using AutoMecanica.ClienteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMecanica.ClienteApi.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente> GetClientes();
        Cliente Get(int id);
        int Add(Cliente cliente);
        int Edit(Cliente cliente);
        int Delete(int id);

    }
}
