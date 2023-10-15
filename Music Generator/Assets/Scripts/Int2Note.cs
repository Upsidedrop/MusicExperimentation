using System.Collections.Generic;
using System.Linq;
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
            "A",
                        "A#",
                        "C",
                        "D",
                        "D#",
                        "F",
                        "G",
        });
        keys.Add("B/G#m", new string[]
        {






            "A#",
                        "B",
                        "C#",
                        "D#",
                        "E",
                        "F#",
                        "G#",
        });
        keys.Add("C/Am", new string[]
        {





            "A",
            "B",
                        "C",
                        "D",
                        "E",
                        "F",
                        "G",
        });
        keys.Add("C#/A#m", new string[]
        {





            "A#",
            "C",
                        "C#",
                        "D#",
                        "F",
                        "F#",
                        "G#",
        });
        keys.Add("D/Bm", new string[]
        {

            "A",
            "B",
            "C#",
                        "D",
            "E",
            "F#",
            "G",
        });
        keys.Add("D#/Cm", new string[]
        {




            "A#",
            "C",
            "D",
               "D#",
               "F",
               "G",
               "G#",
        });
        keys.Add("E/C#m", new string[]
        {

            "A",
            "B",
            "C#",
            "D#",
                        "E",
            "F#",
            "G#",
        });
        keys.Add("F/Dm", new string[]
        {


            "A",
            "A#",
            "C",
            "D",
            "E",
             "F",
             "G",
        });
        keys.Add("F#/D#m", new string[]
        {


            "A#",
            "B",
            "C#",
            "D#",
            "F",
              "F#",
              "G#",
        });
        keys.Add("G/Em", new string[]
        {

            "A",
            "B",
            "C",
            "D",
            "E",
            "F#",
            "G",
        });
        keys.Add("G#/Fm", new string[]
        {

            "A#",
            "C",
            "C#",
            "D#",
            "F",
            "G",
             "G#",
        });

    }

    public string Convert(int input, string key)
    {
        int aLocation;
        string[] notes = keys[key];
        string result;

        if (notes.ToList().Contains("C"))
        {
            aLocation = notes.ToList().IndexOf("C");
        }
        else
        {
            aLocation = notes.ToList().IndexOf("C#");
        }
        result = notes[input % 7];
        result += (int)((input + (7 - aLocation)) / 7);
        return result;
    }

}
