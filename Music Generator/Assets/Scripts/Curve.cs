using UnityEngine;

public class Curve : MonoBehaviour
{
    public int range;
    public int offset;
    private int GetCurve(float x)
    {
        float baseValue;
        float scaledValue;
        baseValue = Mathf.PerlinNoise1D(x);
        scaledValue = baseValue * range + offset;
        return Mathf.RoundToInt(scaledValue);
    }
    private void Start()
    {
        for (int i = 10; i < range; i++)
        {
            print(GetCurve(i + 0.1f));
        }
    }
}
