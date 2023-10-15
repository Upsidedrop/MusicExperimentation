using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public Int2Note Int2Note;
    public int range;
    public int offset;
    private float distance = 0.2f;
    public float seed;
    public List<string> melody = new List<string>();
    private float position = 1234.5678f;
    private int currentBeat = 0;
    public int beatPerMeasure;
    public string[] chordProgression;
    private int GetCurve(float x)
    {
        float baseValue;
        float scaledValue;
        baseValue = Mathf.PerlinNoise1D(x);
        scaledValue = baseValue * range + offset;
        return Mathf.RoundToInt(scaledValue);
    }
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            string currentChord;
            currentChord = chordProgression[currentBeat
                % (chordProgression.Length * beatPerMeasure)
                / beatPerMeasure];
            int curve;
            //just a bunch of random operators
            curve = GetCurve(position + (seed * seed / 4.5f + seed % seed * seed - seed));
            print("mouseDown");
            melody.Add(Int2Note.Convert(curve, currentChord));
            position += distance;
            currentBeat++;
        }
    }
    private void Awake()
    {
        if (seed == 0)
        {
            seed = UnityEngine.Random.value * 100 * UnityEngine.Random.value * 42;
        }
    }

}
