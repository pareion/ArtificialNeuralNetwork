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
            double input2 = 1;
            net.inputLayer.neurons[0].SetOutput(input1);
            net.inputLayer.neurons[1].SetOutput(input2);

            net.Pulse();
            
            bool result = net.outputLayer.neurons[0].GetOutput() > .5;
            
            Console.WriteLine("Input 1 / 2: " + input1 + " " + input2);
            Console.WriteLine("The actual result: " + result.ToString());

            Console.WriteLine("Inputlayer");
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
                    Console.WriteLine("Weight: " + item2.Weight + " Value: "+item2.Input.GetOutput());
                }
            }
        }
    }
}
