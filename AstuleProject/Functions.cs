namespace GrupinisProjektas
{
    public class Functions
    {
        public static double[] applyPanningEffectHigher(double[] soundData, int frameRate)
        {
            int dataLength = soundData.Length - 100;
            double panningRate = 1.0f / dataLength;
            int count = 0;
            int realDataLength = soundData.Length;
            for (int i = 0; i < realDataLength; i++)
            {
                count++;
                soundData[i] = (soundData[i] * panningRate * count);
            }
            return soundData;
        }

        public static double[] applyPanningEffectLower(double[] soundData, int frameRate)
        {
            int dataLength = soundData.Length + 100;
            double panningRate = 1.0f / dataLength;
            int count = dataLength;
            int realDataLength = soundData.Length;
            for (int i = 0; i < realDataLength; i++)
            {
                count--;
                soundData[i] = (soundData[i] * panningRate * count);
            }
            return soundData;
        }
    }

    public class Amongus
    {
        public double[] M1 { get; set; }
        public double[] M2 { get; set; }
    }
}
