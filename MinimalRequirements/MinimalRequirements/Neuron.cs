using System;
using System.Collections.Generic;

namespace MinimalRequirements
{
    public class Neuron 
    {
        public double bias;
        public double Output;
        public List<Link> Input = new List<Link>();

        public Neuron(double bias)
        {
            this.bias = bias;
        }

        internal void Pulse(NeuralLayer neuralLayer)
        {
            Output = 0;

            foreach (var item in Input)
            {
                Output += item.Input.Output * item.Weight;
            }

            Output += bias;

            Output = ActivateFunction(Output);

        }
        public double GetOutput()
        {
            return Output;
        }
        public void SetOutput(double output)
        {
            Output = output;
        }
        public double ActivateFunction(double value)
        {
            return (1 / (1 + Math.Exp(-(value))));
        }

    }
}