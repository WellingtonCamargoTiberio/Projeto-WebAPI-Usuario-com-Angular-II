using Api_Usuario.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Usuario.Interfaces
{
    public interface IFuncao : IGeneric<Funcao>
    {
        Task<List<Funcao>> ListagemCustomizada();
    }
}
