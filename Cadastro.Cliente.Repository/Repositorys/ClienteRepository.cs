using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Repository.Repositorys.Interfaces;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Repository.Repositorys
{
    [ExcludeFromCodeCoverage]
    public class ClienteRepository : RepositoryBase, IClienteRepository

    {
        public ClienteRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }
        public async Task<Cliente> Incluir(Cliente cliente)
        {
            string query = "INSERT INTO cliente_tb (Nome, CPFCNPJ, Telefone, Celular, Email, CEP, Logradouro, " +
                "Numero, Cidade, UF, Complemento) values (@Nome, @CPFCNPJ, @Telefone, @Celular, @Email, @CEP, @Logradouro, @Numero, @Cidade, " +
                "@UF, @Complemento) returning IdCliente";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"Nome", cliente?.Nome ?? "");
            cmd.Parameters.AddWithValue(@"CPFCNPJ", cliente?.CPFCNPJ ?? "");
            cmd.Parameters.AddWithValue(@"Telefone", cliente?.Telefone ?? "");
            cmd.Parameters.AddWithValue(@"Celular", cliente?.Celular ?? "");
            cmd.Parameters.AddWithValue(@"Email", cliente?.Email ?? "");
            cmd.Parameters.AddWithValue(@"CEP", cliente?.Endereco?.CEP ?? "");
            cmd.Parameters.AddWithValue(@"Logradouro", cliente?.Endereco?.Logradouro ?? "");
            cmd.Parameters.AddWithValue(@"Numero", cliente?.Endereco?.Numero ?? "");
            cmd.Parameters.AddWithValue(@"Cidade", cliente?.Endereco?.Cidade ?? "");
            cmd.Parameters.AddWithValue(@"UF", cliente?.Endereco?.UF ?? "");
            cmd.Parameters.AddWithValue(@"Complemento", cliente?.Endereco?.Complemento ?? "");


            var result = await base.ExecuteScalarAsync(cmd);

            if (result != null)
                cliente.IdCliente = int.Parse(result.ToString());
            else
            {
                throw new Exception($"Não foi possível incluir o cliente.\n\r\n\r" +
                    $"{nameof(IClienteRepository)} - Cliente {cliente.ToString()}");
            }

            return cliente;
        }

        public async Task<bool> Alterar(Cliente cliente)
        {
            string query = "UPDATE cliente_tb SET Nome = @Nome, CPFCNPJ = @CPFCNPJ, Telefone = @Telefone, Celular = @Celular, Email = @Email, CEP = @CEP," +
                " Logradouro = @Logradouro, Numero = @Numero, Cidade = @Cidade, UF = @UF, Complemento = @Complemento WHERE IdCliente = @IdCliente";

            return await base.ExecuteAsync(query, new
            {
                IdCliente = cliente.IdCliente,
                Nome = cliente.Nome,
                CPFCNPJ = cliente.CPFCNPJ,
                Telefone = cliente.Telefone,
                Celular = cliente.Celular,
                Email = cliente.Email,
                CEP = cliente.Endereco.CEP,
                Logradouro = cliente.Endereco.Logradouro,
                Numero = cliente.Endereco.Numero,
                Cidade = cliente.Endereco.Cidade,
                UF = cliente.Endereco.UF,
                Complemento = cliente.Endereco.Complemento
            });
        }

        public async Task<bool> Excluir(int idCliente)
        {
            string query = "DELETE FROM cliente_tb where IdCliente = " + idCliente;

            return await base.ExecuteAsync(query);
        }

        public async Task<IEnumerable<Cliente>> GetAll(int limit = 0)
        {
            string query = "select * from cliente_tb";
            if (limit > 0)
                query += $" LIMIT {limit}";

            return await base.QueryAsync<Cliente>(query);
        }

        public async Task<IEnumerable<Cliente>> GetByCliente(Cliente cliente)
        {
            string query = "select * from cliente_tb WHERE 1=1";

            ///Aplica Filtros
            if (cliente.PossuiCamposPreenchidos())
            {
                if (cliente.IdCliente > 0)
                    query += $" AND IdCliente = {cliente.IdCliente}";

                if (!string.IsNullOrEmpty(cliente.Nome))
                    query += $" AND UPPER(Nome) like '%{cliente.Nome.ToUpper()}%'";

                if (!string.IsNullOrEmpty(cliente.Telefone))
                    query += $" AND Telefone = '{cliente.Telefone}'";

                if (!string.IsNullOrEmpty(cliente.Celular))
                    query += $" AND Celular = '{cliente.Celular}'";

                if (!string.IsNullOrEmpty(cliente.Email))
                    query += $" AND UPPER(Email) = '{cliente.Email.ToUpper()}'";
            }



            return await base.QueryAsync<Cliente>(query);
        }

        public async Task<bool> ExisteCliente(int idCliente)
        {
            string query = "select * from cliente_tb where IdCliente = " + idCliente;

            var result = await base.QueryAsync<Cliente>(query);
            return result?.Any() ?? false;
        }

        public async Task<bool> ExcluirPorEmail(string email)
        {
            string query = $"DELETE FROM cliente_tb where UPPER(Email) = '{email.ToUpper()}'";

            return await base.ExecuteAsync(query);
        }

        public async Task<bool> ExisteCliente(Cliente cliente)
        {
            string query = "select * from cliente_tb where 1=1";

            ///Aplica Filtros
            if (cliente.PossuiCamposPreenchidos())
            {
                if (cliente.IdCliente > 0)
                    query += $" AND IdCliente = {cliente.IdCliente}";

                if (!string.IsNullOrEmpty(cliente.Nome))
                    query += $" AND UPPER(Nome) like '%{cliente.Nome.ToUpper()}%'";

                if (!string.IsNullOrEmpty(cliente.Telefone))
                    query += $" AND Telefone = '{cliente.Telefone}'";

                if (!string.IsNullOrEmpty(cliente.Celular))
                    query += $" AND Celular = '{cliente.Celular}'";

                if (!string.IsNullOrEmpty(cliente.Email))
                    query += $" AND UPPER(Email) = '{cliente.Email.ToUpper()}'";
            }


            var result = await base.QueryAsync<Cliente>(query);
            return result?.Any() ?? false;
        }
    }
}
