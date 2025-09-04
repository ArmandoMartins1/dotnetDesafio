using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange  (Todas as variaveis que vamos criar para validar)
        var veiculo = new Veiculo();

        //Act (ação de validação)
        veiculo.Id = 1;
        veiculo.Nome = "testeVeiculo";
        veiculo.Marca = "testeMarca";
        veiculo.Ano = 2025;
        //Assert (validação dos dados)
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("testeVeiculo", veiculo.Nome);
        Assert.AreEqual("testeMarca", veiculo.Marca);
        Assert.AreEqual(2025, veiculo.Ano);
    }
}