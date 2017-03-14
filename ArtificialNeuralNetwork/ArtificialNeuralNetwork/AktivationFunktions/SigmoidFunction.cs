using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork.AktivationFunktions
{
    class SigmoidFunction : IAktivationFunktion
    {
        public float AktivateFunktion(float value)
        {
            float RES = (1 / (1 + (float)Math.Exp(-(value))));
            return RES;
        }
    }
}
