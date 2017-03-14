using ArtificialNeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork.Layers
{
    public class Layer
    {
        public List<Neuron> neurons = new List<Neuron>();
        public Layer(List<Neuron> neurons)
        {
            this.neurons = neurons;
        }
    }
}
