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



        [HttpGet("api/Divisores/{NumeroEntrada}")]
        public async Task<ActionResult<RespostaPadrao>> GetDivisoresAsync(int NumeroEntrada)
        {
            IOperacoesMatematicas operacoesMatematicas = new OperacoesMatematicasRepository();

            RespostaPadrao resultado = new RespostaPadrao();

            try
            {
                return await operacoesMatematicas.RetornaNumerosDivisores(NumeroEntrada);
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

        [HttpGet("api/DivisoresPrimos/{NumeroEntrada}")]
        public async Task<ActionResult<RespostaPadrao>> GetDivisoresPrimos(int NumeroEntrada)
        {
            IOperacoesMatematicas operacoesMatematicas = new OperacoesMatematicasRepository();

            RespostaPadrao resposta = new RespostaPadrao();

            try
            {
                resposta = await operacoesMatematicas.RetornaNumerosDivisores(NumeroEntrada);
                if (resposta.DeuErro == false)
                {
                    if (resposta.Resultados.Count > 0)
                    {
                        resposta = await operacoesMatematicas.RetornaNumerosDivisoresPrimos(NumeroEntrada, resposta);
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