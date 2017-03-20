using ArtificialNeuralNetwork.ActivationFunctions;
using ArtificialNeuralNetwork.Network;
using ArtificialNeuralNetwork.Neurons;
using System.Collections.Generic;
using System.Text;

namespace ArtificialNeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {

            NeuralNet net = new NeuralNet();

            net.Initialize(1, 2, 2, 1, new SigmoidFunction());
            double high, mid, low;
            high = 1;
            low = 0;
            mid = .5;
            bool result;
            StringBuilder bld;

            double ll, lh, hl, hh;
            int count, iterations;
            double[][] input, output;
            double input1 = high;
            double input2 = low;

            bld = new StringBuilder();

            input = new double[4][];
            input[0] = new double[] { high, high };
            input[1] = new double[] { low, high };
            input[2] = new double[] { high, low };
            input[3] = new double[] { low, low };

            output = new double[4][];
            output[0] = new double[] { low };
            output[1] = new double[] { high };
            output[2] = new double[] { high };
            output[3] = new double[] { low };

            count = 0;
            iterations = 5;

            //Trains the network x iterations
            #region training
            do
            {
                count++;

                net.LearningRate = 3;
                net.Train(input, output, TrainingType.TrainingType.BackPropogation, iterations);

                net.PerceptionLayer[0].Output = low;
                net.PerceptionLayer[1].Output = low;

                net.Pulse();

                ll = net.OutputLayer[0].Output;

                net.PerceptionLayer[0].Output = high;
                net.PerceptionLayer[1].Output = low;

                net.Pulse();

                hl = net.OutputLayer[0].Output;

                net.PerceptionLayer[0].Output = low;
                net.PerceptionLayer[1].Output = high;

                net.Pulse();

                lh = net.OutputLayer[0].Output;

                net.PerceptionLayer[0].Output = high;
                net.PerceptionLayer[1].Output = high;

                net.Pulse();

                hh = net.OutputLayer[0].Output;

            }
            while (hh > (mid + low) / 2
                || lh < (mid + high) / 2
                || hl < (mid + low) / 2
                || ll > (mid + high) / 2);
            #endregion

            net.PerceptionLayer[0].Output = input1;
            net.PerceptionLayer[1].Output = input2;
            net.Pulse();
            result = net.OutputLayer[0].Output > .5;

            bld.Remove(0, bld.Length);
            System.Console.WriteLine("Writes all the Neurons in the network ");
            bld.Append("PERCEPTION LAYER <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
            foreach (Neuron pn in net.PerceptionLayer)
                AppendNeuronInfo(bld, pn);

            bld.Append("\nHIDDEN LAYER <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
            foreach (Neuron hn in net.HiddenLayer)
                AppendNeuronInfo(bld, hn);

            bld.Append("\nOUTPUT LAYER <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
            foreach (Neuron on in net.OutputLayer)
                AppendNeuronInfo(bld, on);

            bld.Append("\n");

            System.Console.WriteLine(bld.ToString());
            System.Console.WriteLine("Input 1 / 2: " + input1 + " " + input2);
            System.Console.WriteLine("The actual result: "+ result.ToString());

        }
        private static void AppendNeuronInfo(StringBuilder bld, INeuron neuron)
        {
            #region Declarations

            int i;
            double value;

            #endregion

            #region Initialization

            i = 1;
            value = 0;

            #endregion

            #region Execution

            bld.Append("========== NEURON ========== \n");
            bld.Append(" output\t: ").Append(neuron.Output.ToString()).Append("\n");
            bld.Append(" error\t: ").Append(neuron.Error.ToString());
            bld.Append("\t last error:\t").Append(neuron.LastError.ToString()).Append("\n");
            //bld.Append(" bias value \t: ").Append(neuron.BiasValue.ToString()).Append("\n");
            bld.Append(" bias\t: ").Append(neuron.Bias.Weight.ToString()).Append("\n\n");



            foreach (KeyValuePair<INeuronSignal, NeuralFactor> f in neuron.Input)
            {
                bld.Append("input ").Append(i++.ToString()).Append(" value= ").Append(f.Key.Output.ToString()); //.Append("\n");
                bld.Append("  \tweight = ").Append(f.Value.Weight).Append("\n");


                value += f.Value.Weight * f.Key.Output;
                //bld.Append("\tSig(").Append((f.Key.Output * f.Value.Weight).ToString()).Append(")=").Append(Neuron.Sigmoid(f.Value.Weight + )).Append("\n");
            }

            bld.Append("parent.bias = ").Append(neuron.Bias.Weight).Append("\n");
            bld.Append("sigmoid=").Append(Neuron.Sigmoid(value + neuron.Bias.Weight)).Append("\n");
            bld.Append("============================ \n\n");

            #endregion


        }
    }
}

