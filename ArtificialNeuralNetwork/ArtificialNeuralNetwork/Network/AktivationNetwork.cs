using ArtificialNeuralNetwork.AktivationFunktions;
using ArtificialNeuralNetwork.Layers;
using ArtificialNeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork.Network
{
    public class AktivationNetwork
    {
        public Network network;

        internal float[] TrainNetwork(float[,] inputs)
        {
            return network.ActivateNetwork(inputs);
        }

        public AktivationNetwork(IAktivationFunktion AktivationFunction, int inputs, int layers, int neurons, int neuronsPerLayer, float threshold)
        {
            int neuronsCreated = 0;
            List<Layer> layersList = new List<Layer>();
            for (int i = 0; i < layers; i++)
            {
                List<Neuron> neuronsList = new List<Neuron>();
                for (int c = 0; c < neuronsPerLayer; c++)
                {
                    if (neuronsCreated < neurons)
                    {
                        neuronsList.Add(new Neuron(AktivationFunction, inputs, threshold));
                    }
                }
                if (neuronsList.Count == 0)
                {
                    throw new Exception("To many layers to few neurons!");
                }
                layersList.Add(new Layer(neuronsList));
            }
            network = new Network(layersList);
        }
    }
}
