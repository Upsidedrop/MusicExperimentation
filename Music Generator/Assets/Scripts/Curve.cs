using UnityEngine;

public class Curve : MonoBehaviour
{

    public int range;
    public int offset;
    float distance = 4.25f;
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
        print(GetCurve(Time.time) + (" "+ Time.time));
    }
}
