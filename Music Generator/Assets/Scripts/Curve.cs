using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public Int2Note Int2Note;
    public int range;
    public int offset;
    private readonly float distance = 0.2f;
    public float seed;
    public List<string> melody = new();
    private float position = 1234.5678f;
    private int currentBeat = 0;
    public int beatsPerMeasure;
    public string[] chordProgression;
    public int measures;
    public TMP_InputField seedInput;
    public TMP_InputField progressionInput;
    public TMP_Text keyInput;
    private int GetCurve(float x)
    {
        float baseValue;
        float scaledValue;
        baseValue = Mathf.PerlinNoise1D(x);
        scaledValue = baseValue * range + offset;
        return Mathf.RoundToInt(scaledValue);
    }
    public void Generate()
    {
        if (seedInput.text.NullIfEmpty() == null)
        {
            seed = UnityEngine.Random.value * 100 * UnityEngine.Random.value * 42;
        }
        else
        {
            seed = float.Parse(seedInput.text);
        }
        for (int i = 0; i < progressionInput.text.Length; i++)
        {

        }
        for (int i = 0; i < measures * beatsPerMeasure; i++)
        {
            string currentChord;
            currentChord = chordProgression[currentBeat
                % (chordProgression.Length * beatsPerMeasure)
                / beatsPerMeasure];
            int curve;
            //just a bunch of random operators
            curve = GetCurve(position + (seed * seed / 4.5f + seed % seed * seed - seed));
            print("mouseDown");
            melody.Add(Int2Note.Convert(curve, currentChord));
            position += distance;
            currentBeat++;
        }
    }
}