using System;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{
    [Serializable]
    public class Planet
    {
        public string name;
        public string intro;
        public float meanVMag;
        public float period;
        public float ra;
        public float dej2000;
        public int distance;
        public float BPRP;
        public string type;
        public string lineCurve;
        public LineCurve[] lineCurveList;

        public Planet()
        {
        }
    }

}