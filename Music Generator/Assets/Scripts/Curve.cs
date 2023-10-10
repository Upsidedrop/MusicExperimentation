using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public Int2Note Int2Note;
    public int range;
    public int offset;
    private float distance = 90f;
    public float seed;
    public List<string> melody = new List<string>();

    private int GetCurve(float x)
    {
        float baseValue;
        float scaledValue;
        baseValue = Mathf.PerlinNoise1D(x * distance);
        scaledValue = baseValue * range + offset;
        return Mathf.RoundToInt(scaledValue);
    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            int curve;
            //just a bunch of random operators
            curve = GetCurve(Time.time + (seed * seed / seed % seed * seed - seed));
            print("mouseDown");
            melody.Add(Int2Note.Convert(curve, "G#/Fm"));
        }
    }

}
