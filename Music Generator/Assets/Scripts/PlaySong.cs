using System.Collections;
using UnityEngine;

public class PlaySong : MonoBehaviour
{
    public int bpm;
    public Curve Curve;
    private AudioManager AudioManager;
    private int beat = 0;
    private void Awake()
    {
        AudioManager = GetComponent<AudioManager>();
    }
    private IEnumerator StartMusic(string[] song)
    {
        AudioManager.Play(song[beat]);
        yield return new WaitForSeconds(60 / bpm);
        if (beat == song.Length)
        {
            beat = 0;
        }
        else
        {
            beat++;
            StartCoroutine(StartMusic(song));
        }
    }
    private void Update()
    {
        if (beat == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(StartMusic(Curve.melody.ToArray()));
            }
        }
    }
}
