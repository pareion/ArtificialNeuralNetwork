using System;

namespace MinimalRequirements
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNet net = new NeuralNet();

            net.Init(2, 2, 1);
            double input1 = 1;
            double input2 = 0;
            net.inputLayer[0].output = input1;
            net.inputLayer[1].output = input2;

            net.Pulse();
            
            bool result = net.outputLayer[0].output > .5;
            
            Console.WriteLine("Input 1 / 2: " + input1 + " " + input2);
            Console.WriteLine("The actual result: " + result.ToString());
        }
    }
}
