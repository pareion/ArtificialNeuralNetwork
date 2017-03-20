﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalRequirements
{
    public interface INeuronReceptor
    {
        Dictionary<INeuronSignal, NeuralFactor> Input { get; }
    }
}
