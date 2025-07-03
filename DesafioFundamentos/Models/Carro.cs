using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    /// <summary>
    /// Representa um carro com placa e hora de entrada
    /// </summary>
    public class Carro
    {
        public string Placa { get; set; }

        public DateTime HoraEntrada { get; set; }

        public Carro()
        {
        }
        /// <summary>
        /// Contrutor da classe carro
        /// </summary>
        /// <param name="placa">Placa do carro</param>
        /// <param name="horaEntrada">Hora de entrada do carro</param>
        public Carro(string placa, DateTime horaEntrada)
        {
            this.Placa = placa;
            this.HoraEntrada = horaEntrada;
        }
    }
}