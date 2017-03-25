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

        
        public void Pulse()
        {
            lock (this)
            {
                hiddenLayer.Pulse(this);
                outputLayer.Pulse(this);
            }
        }

        public void Init(int inputNeurons, int hiddenNeurons, int outputNeurons)
        {
            inputLayer = new NeuralLayer();
            hiddenLayer = new NeuralLayer();
            outputLayer = new NeuralLayer();
            Random rand = new Random();
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
                    hiddenLayer.neurons[i].Input.Add(new Link(inputLayer.neurons[j], rand.NextDouble()));
                }
            }


            //Wire output together with hidden layer
            for (i = 0; i < outputLayer.neurons.Count; i++)
            {
                for (j = 0; j < hiddenLayer.neurons.Count; j++)
                {
                    outputLayer.neurons[i].Input.Add(new Link(hiddenLayer.neurons[j], rand.NextDouble()));
                }
            }
        }
        public void Train(double[][] Input, double[][] ExpectedOutput, double learningrate, int iterations)
        {
            lock (this)
            {
                for (int i = 0; i < iterations; i++)
                {
                    for (int a = 0; a < iterations; a++)
                    {
                        InitiateLearning();
                        for (int b = 0; b < Input.Count(); b++)
                        {
                            BackPropogation_TrainingSession(this, Input[b], ExpectedOutput[b], learningrate);
                        }
                        ApplyLearning(learningrate);
                    }
                }
            }
        }

        private void BackPropogation_TrainingSession(NeuralNet neuralNet, double[] input, double[] expected, double learningrate)
        {
            PreparePerceptionLayerForPulse(neuralNet, input);
            neuralNet.Pulse();
            CalculateErrors(neuralNet, expected);
            AdjuestNet(neuralNet,learningrate);
        }

        private void PreparePerceptionLayerForPulse(NeuralNet neuralNet, double[] input)
        {
            for (int i = 0; i < inputLayer.neurons.Count; i++)
            {
                neuralNet.inputLayer.neurons[i].Output = input[i];
            }
        }

        private void InitiateLearning()
        {
            lock (this)
            {
                hiddenLayer.InitiateLearning();
                outputLayer.InitiateLearning();
            }
        }

        private void ApplyLearning(double learningrate)
        {
            lock (this)
            {
                hiddenLayer.ApplyLearning(learningrate);
                outputLayer.ApplyLearning(learningrate);
            }
        }

        private void AdjuestNet(NeuralNet neuralNet, double learningrate)
        {
            for (int i = 0; i < neuralNet.hiddenLayer.neurons.Count; i++)
            {
                Neuron node = neuralNet.hiddenLayer.neurons[i];

                for (int i2 = 0; i2 < neuralNet.outputLayer.neurons.Count; i2++)
                {
                    Neuron output = neuralNet.outputLayer.neurons[i2];
                    output.Input[i].Weight += learningrate * output.error * node.Output;
                    output.delta += learningrate * output.error * output.weight;
                }
            }

            for (int i = 0; i < neuralNet.inputLayer.neurons.Count; i++)
            {
                Neuron node = neuralNet.inputLayer.neurons[i];

                for (int i2 = 0; i2 < neuralNet.hiddenLayer.neurons.Count; i2++)
                {
                    Neuron output = neuralNet.hiddenLayer.neurons[i2];
                    output.Input[i].Weight += learningrate * output.error * node.Output;
                    output.delta += learningrate * output.error * output.weight;
                }
            }
            /*
            // adjust output layer weight
            for (int i = 0; i < neuralNet.outputLayer.neurons.Count; i++)
            {
                Neuron output = neuralNet.outputLayer.neurons[i];
                Neuron hidden = null;
                for (int j = 0; j < neuralNet.hiddenLayer.neurons.Count; j++)
                {
                    hidden = neuralNet.hiddenLayer.neurons[i];
                    output.delta += output.error * hidden.Output;
                }
                output.delta += output.error * output.weight;
            }

            // adjust hidden layer weight
            for (int i = 0; i < neuralNet.hiddenLayer.neurons.Count; i++)
            {
                Neuron hidden = neuralNet.hiddenLayer.neurons[i];
                Neuron input = null;
                for (int j = 0; j < neuralNet.inputLayer.neurons.Count; j++)
                {
                    input = neuralNet.inputLayer.neurons[i];
                    hidden.delta += hidden.error * input.Output;
                }
                hidden.delta += hidden.error * hidden.weight;
            }*/
        }

        private void CalculateErrors(NeuralNet neuralNet, double[] expectedOutput)
        {
            //Calculate outputlayer errors
            for (int i = 0; i < neuralNet.outputLayer.neurons.Count; i++)
            {
                double temp = neuralNet.outputLayer.neurons[i].Output;
                neuralNet.outputLayer.neurons[i].error = (expectedOutput[i] - temp) * temp * (1.0F - temp);
            }

            //Calculate hiddenlayer errors
            for (int i = 0; i < neuralNet.hiddenLayer.neurons.Count; i++)
            {
                double error = 0;
                Neuron temp = neuralNet.hiddenLayer.neurons[i];
                for (int a = 0; a < neuralNet.outputLayer.neurons.Count; a++)
                {
                    Neuron outputNode = neuralNet.outputLayer.neurons[a];

                    error += outputNode.error * outputNode.Input[i].Weight * temp.Output * (1.0 - temp.Output);
                }
                neuralNet.hiddenLayer.neurons[i].error = error;
            }
        }
    }
}
