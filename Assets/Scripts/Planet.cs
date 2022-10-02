﻿using System;
using UnityEngine;
[Serializable]
public class Planet
{
    public string name;
    public string intro;
    public float meanVMag;
    public float Period;
    public float ra;
    public float dej2000;
    public int distance;
    public float BPRP;
    public string type;
    public string lightCurve;
    public LightCurve[] lightCurveList;
    public Color originColor;

    public Planet()
    {
    }
}
