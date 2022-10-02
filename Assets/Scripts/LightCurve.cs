using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



[Serializable]
public class LightCurve
{
    public int hjd;
    public string camera;
    public double mag;
    public double mag_err;
    public double flux;
    public double flux_err;
    public LightCurve()
    {
    }
}

