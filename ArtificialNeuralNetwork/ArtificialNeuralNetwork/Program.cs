using ArtificialNeuralNetwork.AktivationFunktions;
using ArtificialNeuralNetwork.Network;

namespace ArtificialNeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            AktivationNetwork network = new AktivationNetwork(new SigmoidFunction(), 4, 1, 2, 2, 0.5f);
            float[,] inputs = new float[2,4];
            inputs[0, 0] = 1;
            inputs[0, 1] = 1;
            inputs[0, 2] = 1;
            inputs[0, 3] = 1;
            inputs[1, 0] = 1;
            inputs[1, 1] = 1;
            inputs[1, 2] = 1;
            inputs[1, 3] = 1;
            float[] res = network.TrainNetwork(inputs);
        }
    }
}
