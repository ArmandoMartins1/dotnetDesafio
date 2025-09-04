using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;    
namespace minimal_api.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
        Adminstrador? Login(LoginDTO loginDTO);
        Adminstrador Incluir(Adminstrador adminstrador);
        Adminstrador? BuscaPorId(int id);
        List<Adminstrador> Todos(int? pagina);


    }
}