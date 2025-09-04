using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            //Arrange  (Todas as variaveis que vamos criar para validar)
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Adminstradores");

            var adm = new Adminstrador();
            adm.Id = 1;
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";

            var administradorServico = new AdministradorServico(context);

            //Act (ação de validação)
            administradorServico.Incluir(adm);
            

            //Assert (validação dos dados)
            Assert.AreEqual(1, administradorServico.Todos(1).Count());

        }
        
        [TestMethod]
        public void TestandoBuscaPorId()
        {
            //Arrange  (Todas as variaveis que vamos criar para validar)
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Adminstradores");

            var adm = new Adminstrador();
            adm.Id = 1;
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";

            var administradorServico = new AdministradorServico(context);

            //Act (ação de validação)
            administradorServico.Incluir(adm);
            var admDoBanco= administradorServico.BuscaPorId(adm.Id);

            //Assert (validação dos dados)
            Assert.AreEqual(1, admDoBanco.Id);
            
        }
    }
}
