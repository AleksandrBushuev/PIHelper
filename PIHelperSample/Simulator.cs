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
        private int SIN_WAVE = 120;//43200; //12 часов  
       
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
                                 
            int halfInterval = SIN_WAVE / param.stepTime / 2; //экстремум синусоиды по x, y=max y=-max
            double value = param.max / halfInterval;

            int timeout = param.stepTime * 1000;

            double curValue = 0;
            param.tag.Data.UpdateValue(curValue,  DateTime.Now);
            Thread.Sleep(timeout);
            while (true)
            {

                for (int i = 0; i < halfInterval; i++)
                {
                    curValue =+ value;
                    param.tag.Data.UpdateValue(curValue, DateTime.Now);
                    Thread.Sleep(timeout);
                }

                for (int i = 0; i < halfInterval; i++)
                {
                    curValue =- value;
                    param.tag.Data.UpdateValue(curValue, DateTime.Now);
                    Thread.Sleep(timeout);
                }

                for (int i = 0; i < halfInterval; i++)
                {
                    curValue =+ value;
                    double temp = curValue * -1;
                    param.tag.Data.UpdateValue(temp, DateTime.Now);
                    Thread.Sleep(timeout);
                }
                for (int i = 0; i < halfInterval; i++)
                {
                    curValue =- value;
                    double temp = curValue * -1;
                    param.tag.Data.UpdateValue(temp, DateTime.Now);
                    Thread.Sleep(timeout);
                }


            }



        }
       
    }

    class SimulatorRandom : ISimulator
    {
        public void Start(SimulatorParam param)
        {
            
        }

        public bool Stop()
        {
            return false;
        }
    }
}
