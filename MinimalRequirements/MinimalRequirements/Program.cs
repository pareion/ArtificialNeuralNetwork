using System;
using System.Threading;

namespace MinimalRequirements
{
    class Program
    {
        NeuralNet net = new NeuralNet();
        static void Main(string[] args)
        {

            Program p = new Program();
            p.Run();
        }
        private void Run()
        {
            Random random = new Random();
            int seed = 0;

            double[][] input = new double[4][];
            input[0] = new double[] { 1, 1 };
            input[1] = new double[] { 0, 1 };
            input[2] = new double[] { 1, 0 };
            input[3] = new double[] { 0, 0 };

            double[][] output = new double[4][];
            output[0] = new double[] { 0 };
            output[1] = new double[] { 1 };
            output[2] = new double[] { 1 };
            output[3] = new double[] { 0 };

            net.Init(3, 2, 4, 1);
            net.Train(input, output, 7, 8);

            PrintOut(0, 1);
            PrintOut(1, 0);
            PrintOut(0, 0);
            PrintOut(1, 1);
            
            Console.Read();
        }
        private bool PrintOut(double input1, double input2)
        {
            bool result;

            net.inputLayer.neurons[0].SetOutput(input1);
            net.inputLayer.neurons[1].SetOutput(input2);

            net.Pulse();

            result = net.outputLayer.neurons[0].GetOutput() > .5;

            Console.WriteLine("Input 1 / 2: " + input1 + " " + input2);
            Console.WriteLine("The actual result: " + result.ToString());
            Console.WriteLine(net.outputLayer.neurons[0].GetOutput() + " % ");
            return result;
        }
    }
}
