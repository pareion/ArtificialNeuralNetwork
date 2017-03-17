using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork.ActivationFunctions
{
    class StepFunction : IActivationFunction
    {
        public double ActivateFunction(double value)
        {
            if (value >= 0)
                return 1;
            else
                return 0;
        }
    }
}
