using System.Collections;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    private IEnumerator openMenuScreen()
    {
        CinematicLetterbox.Instance.GetComponent<AudioSource>().volume = 0f;
        CinematicLetterbox.Instance.duration = 0f;
        CinematicLetterbox.Instance.active = true;
        yield return new WaitForSeconds(1f);
        CinematicLetterbox.Instance.GetComponent<AudioSource>().volume =1f;
        CinematicLetterbox.Instance.duration = 1f;
        CinematicLetterbox.Instance.active = false;
    }

    void Start()
    {
        StartCoroutine(openMenuScreen());
    }
}
