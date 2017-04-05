using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalRequirements.Genetics
{
    class GA
    {
        public List<NeuralNet> SpawnGeneration(int amount, int inputNeurons, int hiddenNeurons, int outputNeurons)
        {
            List<NeuralNet> generation = new List<NeuralNet>();
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                NeuralNet net = new NeuralNet();
                net.Init(random.Next(), inputNeurons, hiddenNeurons, outputNeurons);
                generation.Add(net);
            }
            return generation;
        }
        public List<NeuralNet> DetermineFitness(List<NeuralNet> net, double[][] input, double[][] output)
        {
            foreach (NeuralNet nnet in net)
            {
                double fitness = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        nnet.inputLayer.neurons[j].SetOutput(input[i][j]);
                    }
                    nnet.Pulse();
                    for (int k = 0; k < nnet.outputLayer.neurons.Count; k++)
                    {
                        fitness += nnet.outputLayer.neurons[k].Output - output[i][k];
                    }
                    nnet.fitness = fitness;
                }
            }
            return net;
        }
        public List<NeuralNet> SelectParents(List<NeuralNet> net)
        {
            List<NeuralNet> result = new List<NeuralNet>();
            for (int i = 0; i < 2; i++)
            {
                NeuralNet current = net[0];
                for (int j = 1; j < net.Count; j++)
                {
                    if (current.fitness > net[j].fitness)
                    {
                        current = net[j];
                    }
                }
                result.Add(current);
                net.Remove(current);
            }
            return result;
        }
        public NeuralNet CrossOver(NeuralNet parent1, NeuralNet parent2)
        {
            NeuralNet kid1 = new NeuralNet();
            NeuralNet kid2 = new NeuralNet();
            Random random = new Random();
            for (int i = 0; i < parent1.hiddenLayer.neurons.Count; i++)
            {
                for (int j = 0; j < parent2.hiddenLayer.neurons.Count; j++)
                {
                    if (j % 2 == 0)
                    {

                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
