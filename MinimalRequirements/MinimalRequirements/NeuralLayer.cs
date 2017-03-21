using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalRequirements
{
    class NeuralLayer
    {
        public List<Neuron> neurons = new List<Neuron>();

        public void Pulse(NeuralNet net)
        {
            foreach (Neuron n in neurons)
                n.Pulse(this);
        }
    }
}
