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
            double ll, lh, hl, hh;
            double high, mid, low;
            high = 0.99;
            low = 0.01;
            mid = .5;

            net.Init(2, 2, 1);
            double[][] input = new double[4][];
            input[0] = new double[] { 0.99, 0.99 };
            input[1] = new double[] { 0.01, 0.99 };
            input[2] = new double[] { 0.99, 0.01 };
            input[3] = new double[] { 0.01, 0.01 };

            double[][] output = new double[4][];
            output[0] = new double[] { 0.01 };
            output[1] = new double[] { 0.99 };
            output[2] = new double[] { 0.99 };
            output[3] = new double[] { 0.01 };
            
            int count = 0;
            int number = 0;
            do
            {
                count++;
                net.Init(2, 2, 1);

                if (count > 50)
                {
                    count = 0;
                    number++;
                }
                else
                    net.Train(input, output, number, 15);

                net.inputLayer.neurons[0].Output = low;
                net.inputLayer.neurons[1].Output = low;

                net.Pulse();

                ll = net.outputLayer.neurons[0].Output;

                net.inputLayer.neurons[0].Output = high;
                net.inputLayer.neurons[1].Output = low;

                net.Pulse();

                hl = net.outputLayer.neurons[0].Output;

                net.inputLayer.neurons[0].Output = low;
                net.inputLayer.neurons[1].Output = high;

                net.Pulse();

                lh = net.outputLayer.neurons[0].Output;

                net.inputLayer.neurons[0].Output = high;
                net.inputLayer.neurons[1].Output = high;

                net.Pulse();

                hh = net.outputLayer.neurons[0].Output;

            } while (hh > (mid + low) / 2
                || lh < (mid + high) / 2
                || hl < (mid + low) / 2
                || ll > (mid + high) / 2);

            PrintOut(0.01, 0.99);

        }
        private void PrintOut(double input1, double input2)
        {
            bool result;

            net.inputLayer.neurons[0].SetOutput(input1);
            net.inputLayer.neurons[1].SetOutput(input2);

            net.Pulse();

            result = net.outputLayer.neurons[0].GetOutput() > .5;

            Console.WriteLine("Input 1 / 2: " + input1 + " " + input2);
            Console.WriteLine("The actual result: " + result.ToString());
            Console.WriteLine(net.outputLayer.neurons[0].GetOutput() + " % ");

            input1 = 0.01;
            input2 = 0.99;
            net.inputLayer.neurons[0].SetOutput(input1);
            net.inputLayer.neurons[1].SetOutput(input2);

            net.Pulse();

            result = net.outputLayer.neurons[0].GetOutput() > .5;

            Console.WriteLine("Input 1 / 2: " + input1 + " " + input2);
            Console.WriteLine("The actual result: " + result.ToString());
            Console.WriteLine(net.outputLayer.neurons[0].GetOutput() + " % ");

            input1 = 0.99;
            input2 = 0.99;
            net.inputLayer.neurons[0].SetOutput(input1);
            net.inputLayer.neurons[1].SetOutput(input2);

            net.Pulse();

            result = net.outputLayer.neurons[0].GetOutput() > .5;

            Console.WriteLine("Input 1 / 2: " + input1 + " " + input2);
            Console.WriteLine("The actual result: " + result.ToString());
            Console.WriteLine(net.outputLayer.neurons[0].GetOutput() + " % ");
            input1 = 0.01;
            input2 = 0.01;
            net.inputLayer.neurons[0].SetOutput(input1);
            net.inputLayer.neurons[1].SetOutput(input2);

            net.Pulse();

            result = net.outputLayer.neurons[0].GetOutput() > .5;

            Console.WriteLine("Input 1 / 2: " + input1 + " " + input2);
            Console.WriteLine("The actual result: " + result.ToString());
            Console.WriteLine(net.outputLayer.neurons[0].GetOutput() + " % ");
        }
    }
}
