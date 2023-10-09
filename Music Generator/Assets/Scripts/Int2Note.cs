using System.Collections.Generic;
using UnityEngine;

public class Int2Note : MonoBehaviour
{
    private Dictionary<string, string[]> keys =
        new();

    // Start is called before the first frame update
    private void Start()
    {
        keys.Add("A/F#m", new string[]
        {
            "A",
            "B",
            "C#",
            "D",
            "E",
            "F#",
            "G#"
        });
        keys.Add("A#/Gm", new string[]
        {
            "A#",
            "C",
            "D",
            "D#",
            "F",
            "G",
            "A"
        });
        keys.Add("B/G#m", new string[]
        {
            "B",
            "C#",
            "D#",
            "E",
            "F#",
            "G#",
            "A#"
        });
        keys.Add("C/Am", new string[]
        {
            "C",
            "D",
            "E",
            "F",
            "G",
            "A",
            "B"
        });
        keys.Add("C#/A#m", new string[]
        {
            "C#",
            "D#",
            "F",
            "F#",
            "G#",
            "A#",
            "C"
        });
        keys.Add("D/Bm", new string[]
        {
            "D",
            "E",
            "F#",
            "G",
            "A",
            "B",
            "C#"
        });
        keys.Add("D#/Cm", new string[]
        {
            "D#",
            "F",
            "G",
            "G#",
            "A#",
            "C",
            "D"
        });
        keys.Add("E/C#m", new string[]
        {
            "E",
            "F#",
            "G#",
            "A",
            "B",
            "C#",
            "D#"
        });
        keys.Add("F/Dm", new string[]
        {
            "F",
            "G",
            "A",
            "A#",
            "C",
            "D",
            "E"
        });
        keys.Add("F#/D#m", new string[]
        {
            "F#",
            "G#",
            "A#",
            "B",
            "C#",
            "D#",
            "F"
        });
        keys.Add("G/Em", new string[]
        {
            "G",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F#"
        });
        keys.Add("G#/Fm", new string[]
        {
            "G#",
            "A#",
            "C",
            "C#",
            "D#",
            "F",
            "G"
        });

    }

    // Update is called once per frame
    private void Update()
    {

    }
}
