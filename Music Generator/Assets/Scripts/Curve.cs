using UnityEngine;

public class Curve : MonoBehaviour
{
    public Int2Note Int2Note;
    public int range;
    public int offset;
    private float distance = 10f;
    public float seed;
    private int GetCurve(float x)
    {
        float baseValue;
        float scaledValue;
        baseValue = Mathf.PerlinNoise1D(x * distance);
        scaledValue = baseValue * range + offset;
        return Mathf.RoundToInt(scaledValue);
    }
    private void FixedUpdate()
    {
        int curve;
        //just a bunch of random operators
        curve = GetCurve(Time.time + (seed *seed /seed %seed *seed -seed));
        print(curve + (" " + Time.time));
        print(Int2Note.Convert(curve, "A#/Gm") + (" " + Time.time));
    }
}
