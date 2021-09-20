using Api_Usuario.Entidades;
using Api_Usuario.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Usuario.Repositorio
{
    public class RepositorioFuncao : RepositorioGeneric<Funcao>, IFuncao
    {
        public Task<List<Funcao>> ListagemCustomizada()
        {
            throw new System.NotImplementedException();
        }
    }
}