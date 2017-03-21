using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalRequirements
{
    public class Link
    {
        public Neuron Input;
        public double Weight;
        public Link(Neuron Input, double Weight)
        {
            this.Input = Input;
            this.Weight = Weight;
        }
    }
}
