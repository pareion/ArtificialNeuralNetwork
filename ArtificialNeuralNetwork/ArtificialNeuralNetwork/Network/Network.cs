using ArtificialNeuralNetwork.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork.Network
{
    public class Network
    {
        public List<Layer> layers = new List<Layer>();
        public Network(List<Layer> layers)
        {
            this.layers = layers;
        }
        public float[] ActivateNetwork(float[,] inputs)
        {
            float[] output = new float[inputs.Length];
            for (int layer = 0; layer < layers.Count; layer++)
            {
                for (int i = 0; i < layers[layer].neurons.Count; i++)
                {
                    output[i] = layers[layer].neurons[i].AktivateNeuron(inputs);
                }
            }
            
            return output;
        }
    }
}
