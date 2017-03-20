using System;
using System.Collections.Generic;

namespace MinimalRequirements
{
    public class Neuron : INeuronReceptor, INeuronSignal
    {
        public double bias;
        public double output;
        private Dictionary<INeuronSignal, NeuralFactor> input = new Dictionary<INeuronSignal, NeuralFactor>();
        public Dictionary<INeuronSignal, NeuralFactor> Input
        {
            get
            {
                return input;
            }
        }

        public double Output
        {
            get
            {
                return output;
            }

            set
            {
                output = value;
            }
        }

        public Neuron(double bias)
        {
            this.bias = bias;
        }

        internal void Pulse(NeuralLayer neuralLayer)
        {
            output = 0;

            foreach (var item in Input)
            {
                output += item.Key.Output * item.Value.weight;
            }

            output += bias;

            output = ActivateFunction(output);
        }
        public double ActivateFunction(double value)
        {
            return (1 / (1 + Math.Exp(-(value))));
        }

    }
}