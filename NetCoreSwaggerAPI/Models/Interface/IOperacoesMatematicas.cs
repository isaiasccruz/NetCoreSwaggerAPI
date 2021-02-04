using APIProcessadoraDeNumeros.Models;
using System.Threading.Tasks;

namespace NetCoreSwaggerAPI.Models.Interface
{
    public interface IOperacoesMatematicas
    {
        Task<RespostaPadrao> RetornaNumerosDivisores(int NumeroEntrada);
        Task<RespostaPadrao> RetornaNumerosDivisoresPrimos(int NumeroEntrada, RespostaPadrao resposta);
        Task<RespostaPadrao> RetornaSeNumeroEhPrimo(int NumeroEntrada);

    }
}
