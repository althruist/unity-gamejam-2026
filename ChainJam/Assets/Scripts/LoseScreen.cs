using System.Collections;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
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
        StartCoroutine(openLoseScreen());
    }
}
