using System;

namespace FrotaApp
{
    public class Caminhao : Veiculo
    {
        public double CapacidadeCarga { get; private set; } // em toneladas
        private const double INTERVALO_MANUTENCAO = 5000.0; // km

        public Caminhao(string placa, double capacidadeCarga, double odometro = 0, double ultimaManutencao = 0)
            : base(placa, odometro, ultimaManutencao)
        {
            if (capacidadeCarga <= 0) throw new ArgumentException("Capacidade deve ser positiva.");
            CapacidadeCarga = capacidadeCarga;
        }
        
        public override string EstimativaManutencao() // polimorfismo
        {
            double kmDesdeManutencao = Odometro - UltimaManutencao;
            double restante = INTERVALO_MANUTENCAO - kmDesdeManutencao;
            if (restante <= 0) return "Manutenção necessária agora (Caminhão)";
            return $"Faltam {Math.Round(restante, 1)} km para manutenção (Caminhão)";
        }
    }
}