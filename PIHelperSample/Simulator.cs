using PISDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PIHelperSample
{
    interface ISimulator
    {
        void Start(SimulatorParam param);

        bool Stop();
    }
    public struct SimulatorParam
    {
        public PIPoint tag;
        public double min;
        public double max;
        public int stepTime;
    }
    class SimulatorSinusoid: ISimulator
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
            if(thread!=null && thread.IsAlive)
            {
                thread.Abort();
                return true;
            }
            return false;
        }

        private void calculate_sinusoid(object obj)
        {
            SimulatorParam param = (SimulatorParam)obj;

            int intervalCount = SIN_WAVE / param.stepTime;//количество меток времени для записи в архив
            double kof = 2 * Math.PI / intervalCount;   //угловой коэффициент 
            int timeout = param.stepTime * 1000;

            
            param.tag.Data.UpdateValue(0,  DateTime.Now);
            Thread.Sleep(timeout);
            while (true)
            {
                double angle = kof;
                for (int i = 0; i < intervalCount; i++)
                {
                    double value = Math.Sin(angle) * param.max;
                    angle += kof;
                    param.tag.Data.UpdateValue(value, DateTime.Now);
                    Thread.Sleep(timeout);
                }
            }



        }
       
    }

    class SimulatorRandom : ISimulator
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

            int timeout = param.stepTime * 1000; 

            while (true)
            {
                int value = random.Next((int)param.min, (int)param.max);
                param.tag.Data.UpdateValue(value, DateTime.Now);
                Thread.Sleep(timeout);               
            }
        }
    }
}
