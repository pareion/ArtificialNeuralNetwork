using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalRequirements
{
    class NeuralLayer : IList<Neuron>
    {
        public List<Neuron> neurons = new List<Neuron>();

        public int IndexOf(Neuron item)
        {
            return neurons.IndexOf(item);
        }

        public void Insert(int index, Neuron item)
        {
            neurons.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            neurons.RemoveAt(index);
        }

        public Neuron this[int index]
        {
            get { return neurons[index]; }
            set { neurons[index] = value; }
        }
       

        public void Add(Neuron item)
        {
            neurons.Add(item);
        }

        public void Clear()
        {
            neurons.Clear();
        }

        public bool Contains(Neuron item)
        {
            return neurons.Contains(item);
        }

        public void CopyTo(Neuron[] array, int arrayIndex)
        {
            neurons.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return neurons.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Neuron item)
        {
            return neurons.Remove(item);
        }
       

        public IEnumerator<Neuron> GetEnumerator()
        {
            return neurons.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Pulse(NeuralNet net)
        {
            foreach (Neuron n in neurons)
                n.Pulse(this);
        }
    }
}
