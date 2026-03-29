using System.Collections;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public AudioClip ambience;
    private IEnumerator openLoseScreen()
    {
        CinematicLetterbox.Instance.GetComponent<AudioSource>().volume = 0f;
        CinematicLetterbox.Instance.duration = 0f;
        CinematicLetterbox.Instance.active = true;
        yield return new WaitForSeconds(2f);
        CinematicLetterbox.Instance.GetComponent<AudioSource>().volume = 1f;
        CinematicLetterbox.Instance.duration = 2f;
        CinematicLetterbox.Instance.active = false;
    }

    void Start()
    {
        gameObject.GetComponent<AudioSource>().clip = ambience;
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(openLoseScreen());
    }
}
