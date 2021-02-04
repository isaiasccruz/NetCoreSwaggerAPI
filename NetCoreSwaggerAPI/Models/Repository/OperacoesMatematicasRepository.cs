using APIProcessadoraDeNumeros.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NetCoreSwaggerAPI.Models.Interface
{
    public class OperacoesMatematicasRepository : IOperacoesMatematicas
    {
        public async Task<RespostaPadrao> RetornaNumerosDivisores(int NumeroEntrada)
        {
            RespostaPadrao resultado = new RespostaPadrao();
            List<int> list = new List<int>();
            

            try
            {
                for (int i = NumeroEntrada; i > 0; i--)
                {
                    if (NumeroEntrada % i == 0)
                    {
                        list.Add(i);
                    }
                }

                if (list.Count > 0)
                {
                    resultado.MensagemSucesso = "os divisores são: ";

                    foreach (var numero in list)
                    {
                        resultado.MensagemSucesso += numero + "; ";
                    }

                    list.Reverse();// Como o calculo de divisões é feito dos maiores valores para os menores, fazemos o reverso na lista para exibir numeros em ordem crescente

                    resultado.DeuErro = false;
                    resultado.MensagemErro = null;
                    resultado.Resultados = list;
                    resultado.DataHoraResposta = DateTime.Now;
                }
                else
                {
                    resultado.DeuErro = true;
                    resultado.MensagemErro = "Número: " + NumeroEntrada + " não é divisível";
                    resultado.DataHoraResposta = DateTime.Now;
                    resultado.Resultados = null;
                }

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<RespostaPadrao> RetornaNumerosDivisoresPrimos(int NumeroEntrada,RespostaPadrao resposta)
        {
            RespostaPadrao resultado = new RespostaPadrao();
            List<int> list = new List<int>();
            try
            {
                foreach (var numero in resposta.Resultados)
                {
                    resultado = await RetornaSeNumeroEhPrimo(numero);
                    if (resultado.DeuErro == false)
                    {
                        list.Add(numero);
                    }
                }

                if (list.Count > 0)
                {
                    resultado.MensagemSucesso = "os divisores do número: " + NumeroEntrada +" tem os seguintes numeros primos: ";                    
                    foreach (var numero in list)
                    {
                        resultado.MensagemSucesso += numero + "; ";
                    }

                    list.Reverse();// Como o calculo de divisões é feito dos maiores valores para os menores, fazemos o reverso na lista para exibir numeros em ordem crescente

                    resultado.DeuErro = false;
                    resultado.MensagemErro = null;
                    resultado.Resultados = list;
                    resultado.DataHoraResposta = DateTime.Now;
                }
                else
                {
                    resultado.DeuErro = true;
                    resultado.MensagemErro = "Número: " + NumeroEntrada + " não possui números primos";
                    resultado.DataHoraResposta = DateTime.Now;
                    resultado.Resultados = null;
                }


                return resultado;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<RespostaPadrao> RetornaSeNumeroEhPrimo(int NumeroEntrada)
        {
            RespostaPadrao resultado = new RespostaPadrao();
            try
            {

                int m = 0;
                bool ehPrimo = true;

                m = NumeroEntrada / 2;
                for (int i = 2; i <= m; i++)
                {
                    if (NumeroEntrada % i == 0)
                    {
                        ehPrimo = false;
                        break;
                    }
                }
                if (ehPrimo == true)
                {
                    resultado.DeuErro = false;
                    resultado.MensagemErro = null;
                    resultado.MensagemSucesso = "Número: " + NumeroEntrada + " é um número primo";
                    resultado.Resultados = null;
                    resultado.DataHoraResposta = DateTime.Now;
                }
                else
                {
                    resultado.DeuErro = true;
                    resultado.MensagemErro = "Número: " + NumeroEntrada + " não é um número primo";
                    resultado.MensagemSucesso = null;
                    resultado.Resultados = null;
                    resultado.DataHoraResposta = DateTime.Now;
                }

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}