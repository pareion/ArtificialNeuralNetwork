using ArtificialNeuralNetwork.AktivationFunktions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork.Neurons
{
    public class Neuron
    {
        public List<Weight> weights = new List<Weight>();
        private float threshold;
        private float bias = -0.4f;
        static Random random = new Random();
        public IAktivationFunktion aktivationFunktion;
        public Neuron(IAktivationFunktion aktivationFunktion, int weights, float threshold)
        {
            for (int i = 0; i < weights; i++)
            {
                this.weights.Add(new Weight() { weight = (float)random.Next(0, 101) / (float)100 });
            }
            this.aktivationFunktion = aktivationFunktion;
            this.threshold = threshold;
        }
        public float AktivateNeuron(float[,] input)
        {
            float result = 0;
            for (int x = 0; x < input.Rank; x++)
            {
                for (int i = 0; i < input.GetLength(0); i++)
                {
                    result += (weights[x].weight * input[x, i]) + bias;
                }
            }
            return aktivationFunktion.AktivateFunktion(result);
        }
    }
}
