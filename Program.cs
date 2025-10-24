using System;

namespace FrotaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var frota = new Frota();
            while (true)
            {
                Console.WriteLine("\n=== Sistema de Frota ===");
                Console.WriteLine("1 - Adicionar Carro");
                Console.WriteLine("2 - Adicionar Caminhão");
                Console.WriteLine("3 - Listar Veículos");
                Console.WriteLine("4 - Rodar todos X km");
                Console.WriteLine("5 - Relatório de manutenção");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");
                var opc = Console.ReadLine();

                try
                {
                    if (opc == "1")
                    {
                        Console.Write("Placa: ");
                        string placa = Console.ReadLine();
                        Console.Write("Consumo (km/l): ");
                        if (!double.TryParse(Console.ReadLine(), out double consumo) || consumo <= 0)
                        {
                            Console.WriteLine("Valor inválido, operação cancelada.");
                            continue;
                        }
                        frota.AdicionarVeiculo(new Carro(placa, consumo));
                        Console.WriteLine("Carro adicionado.");
                    }
                    else if (opc == "2")
                    {
                        Console.Write("Placa: ");
                        string placa = Console.ReadLine();
                        Console.Write("Capacidade (ton): ");
                        double cap = double.Parse(Console.ReadLine());
                        frota.AdicionarVeiculo(new Caminhao(placa, cap));
                        Console.WriteLine("Caminhão adicionado.");
                    }
                    else if (opc == "3")
                    {
                        foreach (var v in frota.ListarVeiculos()) Console.WriteLine(v);
                    }
                    else if (opc == "4")
                    {
                        Console.Write("Km a rodar para cada veículo: ");
                        if (double.TryParse(Console.ReadLine(), out double km) && km >= 0)
                        {
                            frota.RodarTodos(km);
                            Console.WriteLine("Todos os veículos rodaram " + km + " km.");
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida! Digite um número positivo.");
                        }
                    }
                    else if (opc == "5")
                    {
                        frota.RelatorioManutencao();
                    }
                    else if (opc == "0")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }
    }
}