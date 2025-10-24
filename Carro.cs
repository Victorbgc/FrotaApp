using System;

namespace FrotaApp
{
    public class Carro : Veiculo
    {
        public double ConsumoCombustivel { get; private set; } // km por litro
        private const double INTERVALO_MANUTENCAO = 10000.0; // km

        public Carro(string placa, double consumo, double odometro = 0, double ultimaManutencao = 0) : base(placa, odometro, ultimaManutencao)
        {
            if (consumo <= 0)
                throw new ArgumentException("Consumo de combustível deve ser positivo.");
            ConsumoCombustivel = consumo;
        }

        public override string EstimativaManutencao() // polimorfismo
        {
            double kmDesdeManutencao = Odometro - UltimaManutencao;
            double restante = INTERVALO_MANUTENCAO - kmDesdeManutencao;
            if (restante <= 0) return "Manutenção necessária agora (Carro)";
            return $"Faltam {Math.Round(restante, 1)} km para manutenção (Carro)";
        }
    }
}