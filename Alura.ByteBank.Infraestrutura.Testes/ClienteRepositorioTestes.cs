using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _repositorio;
        public ClienteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosClientes()
        {
            //Arrange
            //Act
            List<Cliente> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
            Assert.True(lista.Count > 0);
        }

        [Fact]
        public void TestaClientePorId()
        {
            //Arrange
            //Act
            var cliente = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaClientePorVariosId(int id)
        {
            //Arrange
            //Act
            var cliente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);

        }

        [Fact]
        public void TesteInsereUmNovoClienteNaBaseDeDados()
        {
            //Arrange            
            string nome = "Alberto Roberto";
            string cpf = "088.157.930-03";
            Guid identificador = Guid.NewGuid();
            string profissao = "Administrador de Empresas";

            var cliente = new Cliente()
            {
                Nome = nome,
                CPF = cpf,
                Identificador = identificador,
                Profissao = profissao
            };

            //Act
            var retorno = _repositorio.Adicionar(cliente);

            //Assert
            Assert.True(retorno);


        }

        [Fact]
        public void TestaAtualizacaoInformacaoDeterminadoCliente()
        {
            //Arrange        
            var cliente = _repositorio.ObterPorId(2);
            var nomeNovo = "João Pedro";
            cliente.Nome = nomeNovo;

            //Act
            var atualizado = _repositorio.Atualizar(2, cliente);

            //Assert
            Assert.True(atualizado);
        }

    }
}
