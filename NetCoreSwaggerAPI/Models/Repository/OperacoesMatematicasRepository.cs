using APIProcessadoraDeNumeros.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreSwaggerAPI.Models.Interface
{
    public class OperacoesMatematicasRepository : IOperacoesMatematicas
    {
        public async Task<RespostaPadrao> Soma(double num1, double num2)
        {
            RespostaPadrao resultado = new RespostaPadrao();
            List<int> list = new List<int>();
            try
            {
                int result;

                result = Convert.ToInt32(num1) + Convert.ToInt32(num2);
                list.Add(result);

                resultado.MensagemSucesso = "o resultado é: " + result;
                resultado.DeuErro = false;
                resultado.MensagemErro = null;
                resultado.Resultados = list;
                resultado.DataHoraResposta = DateTime.Now;

                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<RespostaPadrao> Subtracao(double num1, double num2)
        {
            RespostaPadrao resultado = new RespostaPadrao();
            List<int> list = new List<int>();
            try
            {
                int result;

                result = Convert.ToInt32(num1) - Convert.ToInt32(num2);
                list.Add(result);

                resultado.MensagemSucesso = "o resultado é: " + result;
                resultado.DeuErro = false;
                resultado.MensagemErro = null;
                resultado.Resultados = list;
                resultado.DataHoraResposta = DateTime.Now;

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<RespostaPadrao> Divisao(double num1, double num2)
        {
            RespostaPadrao resultado = new RespostaPadrao();
            List<int> list = new List<int>();
            try
            {
                int result;

                result = Convert.ToInt32(num1) / Convert.ToInt32(num2);
                list.Add(result);

                resultado.MensagemSucesso = "o resultado é: " + result;
                resultado.DeuErro = false;
                resultado.MensagemErro = null;
                resultado.Resultados = list;
                resultado.DataHoraResposta = DateTime.Now;

                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<RespostaPadrao> Multiplicacao(double num1, double num2)
        {
            RespostaPadrao resultado = new RespostaPadrao();
            List<int> list = new List<int>();
            try
            {
                int result;

                result = Convert.ToInt32(num1) * Convert.ToInt32(num2);
                list.Add(result);

                resultado.MensagemSucesso = "o resultado é: " + result;
                resultado.DeuErro = false;
                resultado.MensagemErro = null;
                resultado.Resultados = list;
                resultado.DataHoraResposta = DateTime.Now;

                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<RespostaPadrao> RetornaNumerosDivisores(int num1)
        {
            RespostaPadrao resultado = new RespostaPadrao();
            List<int> list = new List<int>();


            try
            {
                for (int i = num1; i > 0; i--)
                {
                    if (num1 % i == 0)
                    {
                        list.Add(i);
                    }
                }

                if (list.Count > 0)
                {
                    list.Reverse();// Como o calculo de divisões é feito dos maiores valores para os menores, fazemos o reverso na lista para exibir numeros em ordem crescente
                    resultado.MensagemSucesso = "os divisores são: ";

                    foreach (var numero in list)
                    {
                        resultado.MensagemSucesso += numero + "; ";
                    }

                    resultado.DeuErro = false;
                    resultado.MensagemErro = null;
                    resultado.Resultados = list;
                    resultado.DataHoraResposta = DateTime.Now;
                }
                else
                {
                    resultado.DeuErro = true;
                    resultado.MensagemErro = "Número: " + num1 + " não é divisível";
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
        public async Task<RespostaPadrao> RetornaNumerosDivisoresPrimos(int num1, RespostaPadrao resposta)
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
                    resultado.MensagemSucesso = "os divisores do número: " + num1 + " tem os seguintes numeros primos: ";

                    foreach (var numero in list)
                    {
                        resultado.MensagemSucesso += numero + "; ";
                    }

                    resultado.DeuErro = false;
                    resultado.MensagemErro = null;
                    resultado.Resultados = list;
                    resultado.DataHoraResposta = DateTime.Now;
                }
                else
                {
                    resultado.DeuErro = true;
                    resultado.MensagemErro = "Número: " + num1 + " não possui números primos";
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

        public async Task<RespostaPadrao> RetornaSeNumeroEhPrimo(int num1)
        {
            RespostaPadrao resultado = new RespostaPadrao();
            try
            {

                int m = 0;
                bool ehPrimo = true;

                m = num1 / 2;
                for (int i = 2; i <= m; i++)
                {
                    if (num1 % i == 0)
                    {
                        ehPrimo = false;
                        break;
                    }
                }
                if (ehPrimo == true)
                {
                    resultado.DeuErro = false;
                    resultado.MensagemErro = null;
                    resultado.MensagemSucesso = "Número: " + num1 + " é um número primo";
                    resultado.Resultados = null;
                    resultado.DataHoraResposta = DateTime.Now;
                }
                else
                {
                    resultado.DeuErro = true;
                    resultado.MensagemErro = "Número: " + num1 + " não é um número primo";
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