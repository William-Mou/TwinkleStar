using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [Serializable]
    public class LineCurve
    {
        public int hjd;
        public string camera;
        public double mag;
        public double mag_err;
        public double flux;
        public double flux_err;


        public LineCurve()
        {
        }
    }
}
