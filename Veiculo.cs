using System;

namespace FrotaApp
{
    // Classe base abstrata: não pode ser instanciada diretamente.
    public abstract class Veiculo
    {
        // Campos privados: protegem o estado interno.
        private string placa;
        private double odometro;
        private double ultimaManutencao;

        // Propriedades públicas: controlam acesso aos campos.
        public string Placa
        {
            get => placa;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Placa inválida.");
                placa = value.ToUpper();
            }
        }

        public double Odometro
        {
            get => odometro;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Odômetro não pode ser negativo.");
                odometro = value;
            }
        }

        public double UltimaManutencao
        {
            get => ultimaManutencao;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Última manutenção inválida.");
                ultimaManutencao = value;
            }
        }

        // Construtor: garante que objeto comece em estado válido.
        protected Veiculo(string placa, double odometro = 0, double ultimaManutencao = 0)
        {
            Placa = placa;
            Odometro = odometro;
            UltimaManutencao = ultimaManutencao;
        }

        // Método que atualiza odômetro — protegido por validação.
        public virtual void Rodar(double km)
        {
            if (km < 0)
                throw new ArgumentException("Km deve ser não-negativo.");
            Odometro += km;
        }

        // Método abstrato: cada subclasse fornece sua estimativa.
        public abstract string EstimativaManutencao(); //poderia usar virtual ao invés de abstract caso quisesse uma implementação padrão

        public override string ToString()
        {
            return $"{GetType().Name} - Placa: {Placa}, Km: {Odometro}, Ult. manut.: {UltimaManutencao}";
        }

    }
}