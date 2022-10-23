namespace DesafioFundamentos.Models
{
    /// <summary>
    /// Armazena uma lista de veículos.
    /// </summary>
    public class Estacionamento
    {
        public decimal precoInicial = 0;
        public decimal precoPorHora = 0;
        List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        /// <summary>
        /// Resumo:
        /// Adiciona um veículo em uma lista de veículos da Classe Veiculo.
        /// </summary>
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = "";

            //Verifica se há repetição de placa no momento da inserção.
            do
            {
                placa = Console.ReadLine();

            } while (veiculos.Any(x => x.placa.ToUpper() == placa.ToUpper()));
            
            DateTime horario = DateTime.Parse("00:00");
            Console.WriteLine("Informe o horário de chegada do veículo: (dd/mm/yyyy HH:MM)");

            //Evita que a hora seja negativa na inserção
            bool verifica = false;
            do{
                verifica = DateTime.TryParse(Console.ReadLine(), out horario);
            }while (!verifica || horario <= DateTime.Parse("00:00"));

            Veiculo v = new Veiculo(placa, horario);

            veiculos.Add(v);

        }

        /// <summary>
        /// Resumo:
        /// Remove um veículo da lista, verificando se a data de saída é anterior à data de entrada.
        /// Além disso, chama o método de cálculo de horas.
        /// </summary>
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa =  Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.placa.ToUpper() == placa.ToUpper()))
            {
                decimal valorTotal = 0;
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: (dd/mm/yyyy HH:MM)");

                foreach(Veiculo obj in veiculos)
                {
                    if(obj.placa.ToUpper() == placa.ToUpper())
                    {
                        //Verifica se a data de saída não veio antes da data de entrada
                        do
                        {
                            obj.horarioDeSaida = DateTime.Parse(Console.ReadLine());

                            valorTotal = obj.SomatorioDeValor(this.precoInicial, this.precoPorHora);

                            if(valorTotal < 0)
                            {
                                Console.WriteLine("Data inválida!!!!\n"+"Favor inserir uma data válida.");
                            }
                        } while (valorTotal < 0);

                        Console.WriteLine("Data validada! \n"+"Prosseguindo com o processo de retirada do veículo...");
                        
                        veiculos.Remove(obj);
                        break;
                    }
                        
                }    
                    

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        /// <summary>
        /// Resumo:
        /// Utiliza um foreach para encontrar cada objeto na lista e printá-lo.
        /// </summary>
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach(Veiculo veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
