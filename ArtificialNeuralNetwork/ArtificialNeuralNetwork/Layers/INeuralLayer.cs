using ArtificialNeuralNetwork.Neurons;
using ArtificialNeuralNetwork.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork.Layers
{
    public interface INeuralLayer : IList<INeuron>
    {
        void Pulse(INeuralNet net);
        void ApplyLearning(INeuralNet net);
        void InitializeLearning(INeuralNet net);
    }
}
