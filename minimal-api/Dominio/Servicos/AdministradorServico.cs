using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.Infraestrutura.Db;

namespace minimal_api.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;
        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Adminstrador? BuscaPorId(int id)
        {
            return _contexto.Adminstradores.Where(v => v.Id == id).FirstOrDefault();
        }

        public Adminstrador Incluir(Adminstrador adminstrador)
        {
            _contexto.Adminstradores.Add(adminstrador);
            _contexto.SaveChanges();

            return adminstrador;
        }

        public Adminstrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Adminstradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
            
        }

        public List<Adminstrador> Todos(int? pagina)
        {
            var query = _contexto.Adminstradores.AsQueryable();
            
            int itensPorPagina = 10;

            if (pagina != null)
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);                
            
            return query.ToList();
        }
    }
}