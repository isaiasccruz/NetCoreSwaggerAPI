using APIProcessadoraDeNumeros.Models;
using Microsoft.AspNetCore.Mvc;
using NetCoreSwaggerAPI.Models.Interface;
using System;
using System.Threading.Tasks;

namespace APIProcessadoraDeNumeros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIProcessadoraDeNumerosController : ControllerBase
    {


        [HttpGet("api/Soma/{num1}/{num2}")]
        public async Task<ActionResult<RespostaPadrao>> GetSomaAsync(double num1, double num2)
        {
            IOperacoesMatematicas operacoesMatematicas = new OperacoesMatematicasRepository();

            try
            {
                return await operacoesMatematicas.Soma(num1, num2);
            }
            catch (Exception ex)
            {
                return NotFound(
                        new
                        {
                            Mensagem = ex.Message
                        });
            }
        }

        [HttpGet("api/Subtracao/{num1}/{num2}")]
        public async Task<ActionResult<RespostaPadrao>> GetSubtracaoAsync(double num1, double num2)
        {
            IOperacoesMatematicas operacoesMatematicas = new OperacoesMatematicasRepository();

            try
            {
                return await operacoesMatematicas.Subtracao(num1, num2);
            }
            catch (Exception ex)
            {
                return NotFound(
                        new
                        {
                            Mensagem = ex.Message
                        });
            }
        }

        [HttpGet("api/Divisao/{num1}/{num2}")]
        public async Task<ActionResult<RespostaPadrao>> GetDivisaoAsync(double num1, double num2)
        {
            IOperacoesMatematicas operacoesMatematicas = new OperacoesMatematicasRepository();

            try
            {
                return await operacoesMatematicas.Divisao(num1, num2);
            }
            catch (Exception ex)
            {
                return NotFound(
                        new
                        {
                            Mensagem = ex.Message
                        });
            }
        }

        [HttpGet("api/Multiplicacao/{num1}/{num2}")]
        public async Task<ActionResult<RespostaPadrao>> GetMultiplicacaoAsync(double num1, double num2)
        {
            IOperacoesMatematicas operacoesMatematicas = new OperacoesMatematicasRepository();

            try
            {
                return await operacoesMatematicas.Multiplicacao(num1, num2);
            }
            catch (Exception ex)
            {
                return NotFound(
                        new
                        {
                            Mensagem = ex.Message
                        });
            }
        }

        [HttpGet("api/Divisores/{num1}")]
        public async Task<ActionResult<RespostaPadrao>> GetDivisoresAsync(int num1)
        {
            IOperacoesMatematicas operacoesMatematicas = new OperacoesMatematicasRepository();

            try
            {
                return await operacoesMatematicas.RetornaNumerosDivisores(num1);
            }
            catch (Exception ex)
            {
                return NotFound(
                        new
                        {
                            Mensagem = ex.Message
                        });
            }
        }

        [HttpGet("api/DivisoresPrimos/{num1}")]
        public async Task<ActionResult<RespostaPadrao>> GetDivisoresPrimos(int num1)
        {
            IOperacoesMatematicas operacoesMatematicas = new OperacoesMatematicasRepository();

            RespostaPadrao resposta = new RespostaPadrao();

            try
            {
                resposta = await operacoesMatematicas.RetornaNumerosDivisores(num1);
                if (resposta.DeuErro == false)
                {
                    if (resposta.Resultados.Count > 0)
                    {
                        resposta = await operacoesMatematicas.RetornaNumerosDivisoresPrimos(num1, resposta);
                    }
                }

                return resposta;
            }
            catch (Exception ex)
            {
                return NotFound(
                        new
                        {
                            Mensagem = ex.Message
                        });
            }
        }

    }
}