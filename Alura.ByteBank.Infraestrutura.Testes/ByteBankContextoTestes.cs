using Alura.ByteBank.Dados.Contexto;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTestes
    {
        [Fact]
        public void TestaConexaoContextoComBD()
        {
            //Arrange
            var contexto = new ByteBankContexto();
            bool conectado;

            //Act
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception e)
            {
                throw new Exception($"Não foi possível conectar a base de dados.[{e.Message}]");
            }

            //Assert
            Assert.True(conectado);
        }
    }
}
