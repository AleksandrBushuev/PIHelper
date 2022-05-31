using System;
using System.Threading;

namespace PIHelperSample.Simulators
{
    public class SimulatorSinusoid : ISimulator
    {
        private Thread thread;
        private int SIN_WAVE = 43200; //12 часов  

        public void Start(SimulatorParam param)
        {
            thread = new Thread(new ParameterizedThreadStart(calculate_sinusoid));
            thread.Start(param);
        }

        public bool Stop()
        {
            if (thread != null && thread.IsAlive)
            {
                thread.Abort();
                return true;
            }
            return false;
        }

        private void calculate_sinusoid(object obj)
        {
            SimulatorParam param = (SimulatorParam)obj;

            int intervalCount = SIN_WAVE / param.StepTime;//количество меток времени для записи в архив
            double kof = 2 * Math.PI / intervalCount;   //угловой коэффициент 
            int timeout = param.StepTime * 1000;


            param.Tag.Data.UpdateValue(0, DateTime.Now);
            Thread.Sleep(timeout);
            while (true)
            {
                double angle = kof;
                for (int i = 0; i < intervalCount; i++)
                {
                    double value = Math.Sin(angle) * param.Max;
                    angle += kof;
                    param.Tag.Data.UpdateValue(value, DateTime.Now);
                    Thread.Sleep(timeout);
                }
            }

        }
    }
}
