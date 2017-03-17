using ArtificialNeuralNetwork.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork.Neurons
{
    public interface INeuron : INeuronSignal, INeuronReceptor
    {
        void Pulse(INeuralLayer layer);
        void ApplyLearning(INeuralLayer layer, ref double learningRate);
        void InitializeLearning(INeuralLayer layer);

        NeuralFactor Bias { get; set; }

        double Error { get; set; }
        double LastError { get; set; }
    }
}
