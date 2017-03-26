using System;

namespace MinimalRequirements
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNet net = new NeuralNet();

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

            /*Console.WriteLine("Inputlayer");
            foreach (var item in net.inputLayer.neurons)
            {
                foreach (var item2 in item.Input)
                {
                    Console.WriteLine("Weight: " + item2.Weight + " Value: " + item2.Input.GetOutput());
                }
            }
            Console.WriteLine("Hiddenlayer");
            foreach (var item in net.hiddenLayer.neurons)
            {
                foreach (var item2 in item.Input)
                {
                    Console.WriteLine("Weight: " + item2.Weight + " Value: " + item2.Input.GetOutput());
                }
            }
            Console.WriteLine("Outputlayer");
            foreach (var item in net.outputLayer.neurons)
            {
                foreach (var item2 in item.Input)
                {
                    Console.WriteLine("Weight: " + item2.Weight + " Value: " + item2.Input.GetOutput());
                }
            }*/

            bool result;

            net.Train(input, output, 0.3, 300);

            double input1 = 0.99;
            double input2 = 0.01;
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
