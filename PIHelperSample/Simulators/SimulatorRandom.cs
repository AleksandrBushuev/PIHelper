using System;
using System.Threading;


namespace PIHelperSample.Simulators
{
    public class SimulatorRandom : ISimulator
    {
        private Thread thread;
        public void Start(SimulatorParam param)
        {
            thread = new Thread(new ParameterizedThreadStart(calculate_random));
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

        private void calculate_random(object obj)
        {
            SimulatorParam param = (SimulatorParam)obj;
            Random random = new Random();

            int timeout = param.StepTime * 1000;

            while (true)
            {
                int value = random.Next((int)param.Min, (int)param.Max);
                param.Tag.Data.UpdateValue(value, DateTime.Now);
                Thread.Sleep(timeout);
            }
        }
    }
}
