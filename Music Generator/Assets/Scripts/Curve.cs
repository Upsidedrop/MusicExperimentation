using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
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
    private string trueKey;
    public TMP_Text mode;
    List<string> orderedKey = new();
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
        RandoSeed();
        MajorOrMinor();
        OrderKey();
        if (progressionInput.text == string.Empty)
        {
            progressionInput.text = 1451.ToString();
        }
        CreateChordProgression();
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
    void MajorOrMinor()
    {
        trueKey = string.Empty;
        if (mode.text == "Major")
        {
            foreach (char letter in keyInput.text)
            {
                if (letter == '/')
                {
                    break;
                }
                trueKey += letter;
            }
        }
        else
        {
            bool passedSlash = false;
            foreach (char letter in keyInput.text)
            {
                if (letter == '/')
                {
                    passedSlash = true;
                    continue;
                }
                if (!passedSlash)
                {
                    continue;
                }
                if(letter == 'm')
                {
                    break;
                }
                trueKey += letter;
            }
        }
        print(trueKey);
        
    }
    void RandoSeed()
    {
        if (seedInput.text.NullIfEmpty() == null)
        {
            seed = UnityEngine.Random.value * 100 * UnityEngine.Random.value * 42;
        }
        else
        {
            seed = float.Parse(seedInput.text);
        }
    }
    void OrderKey()
    {
        orderedKey.Clear();
        bool passedNote = false;
        foreach(string note in Int2Note.keys[keyInput.text])
        {
            if (note == trueKey)
            {
                passedNote = true;
            }
            if (!passedNote)
            {
                continue;
            }
            orderedKey.Add(note);
            print(note);
        }
        foreach (string note in Int2Note.keys[keyInput.text])
        {
            if (note == trueKey)
            {
                break;
            }
            orderedKey.Add(note);
            print(note);
        }
    }
    void CreateChordProgression()
    {
        chordProgression = new string[progressionInput.text.Length];
        for (int i = 0; i < progressionInput.text.Length; i++)
        {
            chordProgression[i] = orderedKey[int.Parse(progressionInput.text[i].ToString()) -1];
            foreach (string key in Int2Note.keys.Keys)
            {
                if (key.Remove(chordProgression[i].Length) == chordProgression[i])
                {
                    chordProgression[i] = key;
                    break;
                }
            }
        }
    }
}