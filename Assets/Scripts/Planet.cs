using UnityEngine;

public class Planet
{
    public string name;
    public int distance;
    public int temperature;
    public int[] lineCurve;

    public Planet(string name, int distance, int temperature, int[] lineCurve)
    {
        this.name = name;
        this.distance = distance;
        this.temperature = temperature;
        this.lineCurve = lineCurve;
    }
}
