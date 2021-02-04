using System;
using System.Collections.Generic;

namespace APIProcessadoraDeNumeros.Models
{
    public class RespostaPadrao
    {
        public bool DeuErro { get; set; }
        public string MensagemErro { get; set; }
        public string MensagemSucesso { get; set; }
        public DateTime DataHoraResposta { get; set; }
        public List<int> Resultados { get; set; }
    }
}