using APIProcessadoraDeNumeros.Models;
using System.Threading.Tasks;

namespace NetCoreSwaggerAPI.Models.Interface
{
    public interface IOperacoesMatematicas
    {
        Task<RespostaPadrao> Soma(double num1, double num2);
        Task<RespostaPadrao> Subtracao(double num1, double num2);
        Task<RespostaPadrao> Divisao(double num1, double num2);
        Task<RespostaPadrao> Multiplicacao(double num1, double num2);
        Task<RespostaPadrao> RetornaNumerosDivisores(int num1);
        Task<RespostaPadrao> RetornaNumerosDivisoresPrimos(int num1, RespostaPadrao resposta);
        Task<RespostaPadrao> RetornaSeNumeroEhPrimo(int num1);

    }
}
