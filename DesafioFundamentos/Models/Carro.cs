using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Carro
    {
        public string Placa { get; set; }

        public DateTime HoraEntrada { get; set; }

        public Carro()
        {
        }

        public Carro(string placa, DateTime horaEntrada)
        {
            this.Placa = placa;
            this.HoraEntrada = horaEntrada;
        }
    }
}