using GrupinisProjektas.Models;
using Nancy;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceStack;
using System;
using System.Data;
using System.Text;
using GrupinisProjektas;

namespace GrupinisProjektas
{
    public class Worker
    {
        public async Task RunAsync(GenericInputModel generic)
        {
            Console.WriteLine("Egis gejus");
            string json = System.Text.Json.JsonSerializer.Serialize(generic);
            Console.WriteLine(json);
        }
        public async Task<double[]> RunArray(Masyvas generic)
        {

            string json = System.Text.Json.JsonSerializer.Serialize(generic.data);
            JArray jArray = JArray.Parse(json);

            float[] myArray = new float[jArray.Count];

            for (int i = 0; i < jArray.Count; i++)
            {
                myArray[i] = (float)jArray[i];
            }


            double[] hanning = new double[myArray.Length];

            double[] hannDoubles = MathNet.Numerics.Window.Hamming(myArray.Length);
            for (int i = 0; i < myArray.Length; i++)
            {
                hanning[i] = hannDoubles[i] * myArray[i];
            }

            return hanning;

        }

        public async Task<double[]> RunReverse(Reverse generic)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(generic.data);
            int json2 = int.Parse(System.Text.Json.JsonSerializer.Serialize(generic.frequency));
            
            JArray jArray = JArray.Parse(json);

            double[] myArray = new double[jArray.Count];

            for (int i = 0; i < jArray.Count; i++)
            {
                myArray[i] = (double)jArray[i];
            }

            //var list = new List<double>();

            double[] left_signal = myArray.Where((x, i) => i % 2 == 0).ToArray();
            double[] right_signal = myArray.Where((x, i) => i % 2 == 1).ToArray();


            double[] left_array = Functions.applyPanningEffectHigher(left_signal, json2);
            double[] right_array = Functions.applyPanningEffectLower(right_signal, json2);

            double[] combined = left_signal.Concat(right_signal).ToArray();

            return combined;
        }

        public Amongus SplitChannels(Masyvas generic)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(generic.data);

            JArray jArray = JArray.Parse(json);

            double[] myArray = new double[jArray.Count];

            for (int i = 0; i < jArray.Count; i++)
            {
                myArray[i] = (double)jArray[i];
            }

            double[] left_signal = myArray.Where((x, i) => i % 2 == 0).ToArray();
            double[] right_signal = myArray.Where((x, i) => i % 2 == 1).ToArray();
            var amogus = new Amongus();
            amogus.M1 = left_signal;
            amogus.M2 = right_signal;


            return amogus;
        }
    }

}
