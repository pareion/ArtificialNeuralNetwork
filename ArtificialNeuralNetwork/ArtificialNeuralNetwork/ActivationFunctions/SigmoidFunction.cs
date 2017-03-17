using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork.ActivationFunctions
{
    class SigmoidFunction : IActivationFunction
    {
        public double ActivateFunction(double value)
        {
            return (1 / (1 + Math.Exp(-(value))));
        }
    }
}
