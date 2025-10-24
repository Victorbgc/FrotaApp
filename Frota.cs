using System;
using System.Collections.Generic;

namespace FrotaApp
{
    public class Frota
    {
        private List<Veiculo> veiculos = new List<Veiculo>();

        public void AdicionarVeiculo(Veiculo v)
        {
            if (v == null) throw new ArgumentNullException(nameof(v));
            veiculos.Add(v);
        }

        public IEnumerable<Veiculo> ListarVeiculos() => veiculos;

        public void RodarTodos(double km) // polimorfismo: usa Rodar da classe concreta (se for override na sublcasse) ou o comportamento herdado da base  
        {
            foreach (var v in veiculos)
            {
                v.Rodar(km);
            }
        }

        public void RelatorioManutencao()
        {
            foreach (var v in veiculos)
            {
                Console.WriteLine(v.ToString());
                Console.WriteLine(" => " + v.EstimativaManutencao());
            }
        }
    }
}