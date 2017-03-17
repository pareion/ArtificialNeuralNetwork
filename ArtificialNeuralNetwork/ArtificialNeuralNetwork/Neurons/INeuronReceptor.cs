using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork.Neurons
{
    public interface INeuronReceptor
    {
        Dictionary<INeuronSignal, NeuralFactor> Input { get; }
    }
}
