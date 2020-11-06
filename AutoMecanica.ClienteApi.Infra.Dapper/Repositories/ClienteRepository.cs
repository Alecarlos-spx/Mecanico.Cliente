using AutoMecanica.ClienteApi.Domain.Entities;
using AutoMecanica.ClienteApi.Domain.Interfaces.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace AutoMecanica.ClienteApi.Infra.Dapper.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly IConfiguration _configuration;
        public readonly string connectionString;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("AutoMecanica-ConnectionString");
        }

        public int Add(Cliente cliente)
        {

            int count = 0;

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "INSERT INTO CLIENTE(NOME, ENDERECO, NUMERO, COMPLEMENTO, CIDADE, ESTADO, CEP, DOCUMENTO, TIPODOC, TELEFONE1, TELEFONE2, EMAIL, CONTATO, DATACADASTRO) VALUES (@NOME, @ENDERECO, @NUMERO, @COMPLEMENTO, @CIDADE, @ESTADO, @CEP, @DOCUMENTO, @TIPODOC, @TELEFONE1, @TELEFONE2, @EMAIL, @CONTATO, GETDATE())";

                    count = conexao.Execute(query, cliente);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }

                return count;
            }
        }



        public int Delete(int id)
        {
            int count = 0;

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "DELETE FROM CLIENTE WHERE ID = " + id;
                    count = conexao.Execute(query);
                }catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
                return count;
            }
        }

  

        public int Edit(Cliente cliente)
        {
            int count = 0;

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "UPDATE CLIENTE SET NOME = @NOME, ENDERECO = @ENDERECO, NUMERO = @NUMERO, COMPLEMENTO = @COMPLEMENTO, CIDADE = @CIDADE, ESTADO = @ESTADO, CEP = @CEP, DOCUMENTO = @DOCUMENTO, TIPODOC = @TIPODOC, TELEFONE1 = @TELEFONE1, TELEFONE2 = @TELEFONE2, EMAIL = @EMAIL, CONTATO = @CONTATO, OBSERVACAO = @OBSERVACAO  WHERE ID = " + cliente.Id;
                    count = conexao.Execute(query, cliente);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
                return count;
            }
        }

 

        public Cliente Get(int id)
        {
            Cliente cliente = new Cliente();

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "SELECT * FROM CLIENTE WHERE ID = " + id;
                    cliente = conexao.Query<Cliente>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }

                return cliente;
            }

        }



        public List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "SELECT * FROM CLIENTE";
                    clientes = conexao.Query<Cliente>(query).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
                return clientes;
            }

        }





    }
}
