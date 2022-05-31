using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIHelperSample.Simulators
{
    public interface ISimulator
    {
        void Start(SimulatorParam param);

        bool Stop();
    }
}
