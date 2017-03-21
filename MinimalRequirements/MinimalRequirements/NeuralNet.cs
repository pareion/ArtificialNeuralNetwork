﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalRequirements
{
    class NeuralNet
    {
        public NeuralLayer inputLayer;
        public NeuralLayer hiddenLayer;
        public NeuralLayer outputLayer;

        public Random rand = new Random();
        public void Pulse()
        {
            hiddenLayer.Pulse(this);
            outputLayer.Pulse(this);
        }

        public void Init(int inputNeurons, int hiddenNeurons, int outputNeurons)
        {
            inputLayer = new NeuralLayer();
            hiddenLayer = new NeuralLayer();
            outputLayer = new NeuralLayer();

            int i, j;

            for (i = 0; i < inputNeurons; i++)
                inputLayer.neurons.Add(new Neuron(0));

            for (i = 0; i < hiddenNeurons; i++)
                hiddenLayer.neurons.Add(new Neuron(rand.NextDouble()));

            for (i = 0; i < outputNeurons; i++)
                outputLayer.neurons.Add(new Neuron(rand.NextDouble()));

            //Wire input together with the hidden layer
            for (i = 0; i < hiddenLayer.neurons.Count; i++)
            {
                for (j = 0; j < inputLayer.neurons.Count; j++)
                {
                    //Set specific weights instead of random for testing
                    if (i == 0)
                    {
                        Console.WriteLine(inputLayer.neurons[j].GetOutput());
                        hiddenLayer.neurons[i].Input.Add(new Link(inputLayer.neurons[j], 8.4));
                    }
                    else
                    {
                        hiddenLayer.neurons[i].Input.Add(new Link(inputLayer.neurons[j], 1.6));
                    }
                }
            }


            //Wire output together with hidden layer
            for (i = 0; i < outputLayer.neurons.Count; i++)
            {
                for (j = 0; j < hiddenLayer.neurons.Count; j++)
                {
                    //Set specific weights instead of random for testing
                    if (j == 0)
                    {
                        outputLayer.neurons[i].Input.Add(new Link(hiddenLayer.neurons[j], 25));
                    }
                    else
                        outputLayer.neurons[i].Input.Add(new Link(hiddenLayer.neurons[j], -28));
                }
            }
        }
    }
}
