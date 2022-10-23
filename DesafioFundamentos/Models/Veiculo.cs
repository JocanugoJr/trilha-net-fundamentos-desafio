using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    /// <summary>
    /// Representa um veículo que entra em um estacionamento.
    /// </summary>
    public class Veiculo 
    {
        /*Horário de Entrada é um private, pois não vi a necessidade de outras partes do código 
        modificarem esse valor depois de ter sido definido na criação do objeto.*/ 
        private DateTime _horarioDeEntrada = DateTime.Parse("00:00"); 
        public string placa = "";
        public DateTime horarioDeSaida = DateTime.Parse("00:00");


        public Veiculo(string id, DateTime horario)
        {
            this.placa = id;
            this._horarioDeEntrada = horario;
        }

        /// <summary>
        /// Resumo:
        /// A função Somatorio de Valor foi feita para calcular o valor do Objeto veículo 
        /// dentro do Estacionamento. Utiliza a quantidade de ticks para realizar as comparações devidas.
        /// </summary>
        /// <param name="precoInicial"></param>
        /// <param name="precoPorHora"></param>
        /// <returns></returns>
        public decimal SomatorioDeValor(decimal precoInicial, decimal precoPorHora)
        {
            //diferenca recebe um valor negativo, pois caso não seja uma data de saída válida, funciona como uma flag.
            decimal diferenca = -1;
            
            TimeSpan t = horarioDeSaida.Subtract(_horarioDeEntrada);
            if(t.Ticks > 0)
            {
                diferenca = Convert.ToDecimal(t.TotalHours.ToString());
                return precoInicial + diferenca*precoPorHora;
            }

            return diferenca;
        }

        //Um override do ToString para fazer o print de maneira mais fácil
        public override string ToString()
        {
            if(horarioDeSaida.Ticks > DateTime.Parse("00:00").Ticks)
            {
                return "Placa: "+placa + '\n'
                    + "Horário de Entrada: "+_horarioDeEntrada + '\n'
                    + "Horário de Saída: "+horarioDeSaida + '\n';
            }
                
            return "Placa: "+placa + '\n'
                    + "Horário de Entrada: "+_horarioDeEntrada + '\n'
                    + "O veículo se encontra no estacionamento.\n";
        }
    }
}