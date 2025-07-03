using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHoraAdicional = 0;
        private Dictionary<string, Carro> veiculos = new Dictionary<string, Carro>();

        public Estacionamento(decimal precoInicial, decimal precoPorHoraAdicional)
        {
            this.precoInicial = precoInicial;
            this.precoPorHoraAdicional = precoPorHoraAdicional;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.ToUpperInvariant().Trim();

            /*Verifica se a placa do veiculo segue o
            padrão usado no Brasil, tanto o antigo quando o novo*/
            if (!Regex.IsMatch(placa, @"^[A-Z]{3}-[0-9][A-Z0-9][0-9]{2}$"))
            {
                Console.WriteLine("Placa inválida. Use o formato ABC-1234 ou ABC-1D23.");
                return;
            }

            /*Adiciona um veiculo se não constar que um
            outro veiculo de mesma placa já está estacionado*/
            if (veiculos.TryAdd(placa, new Carro(placa,DateTime.Now)))
            {
                Console.WriteLine($"Veículo com placa {placa} adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Erro: já existe um veículo com a placa: {placa}!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine()?.ToUpperInvariant().Trim();

            // Remove o veículo se ele estiver estacionado
            if (veiculos.TryGetValue(placa, out Carro carroBuscado))
            {
                TimeSpan permancencia = DateTime.Now - carroBuscado.HoraEntrada;

                uint horas = Convert.ToUInt32(Math.Ceiling(permancencia.TotalHours));
                decimal valorTotal = (horas >= 2) ? precoInicial + (precoPorHoraAdicional * horas) : precoInicial;

                veiculos.Remove(carroBuscado.Placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:\n");
                Console.WriteLine("{0,-10} | {1,-20} | {2,-15}", "Placa", "Hora de Entrada", "Tempo (h:min)");

                Console.WriteLine(new string('-', 50));

                foreach (Carro aCarro in veiculos.Values)
                {
                    TimeSpan permanencia = DateTime.Now - aCarro.HoraEntrada;
                    string tempo = $"{(int)permanencia.TotalHours}:{permanencia.Minutes:D2}";
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-15}",
                    aCarro.Placa,
                    aCarro.HoraEntrada.ToString("dd/MM/yyyy HH:mm"),
                    tempo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
