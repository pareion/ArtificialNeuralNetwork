using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalRequirements
{
    class Program
    {
        static void Main(string[] args)
        {
            //set learning rate
            NeuralNet net = new NeuralNet();
            StringBuilder bld = new StringBuilder();

            net.Init(2, 2, 1);
            double input1 = 0;
            double input2 = 0;
            net.inputLayer[0].output = input1;
            net.inputLayer[1].output = input2;

            net.Pulse();
            
            bool result = net.outputLayer[0].output > .5;

            System.Console.WriteLine(bld.ToString());
            System.Console.WriteLine("Input 1 / 2: " + input1 + " " + input2);
            System.Console.WriteLine("The actual result: " + result.ToString());
        }
    }
}
