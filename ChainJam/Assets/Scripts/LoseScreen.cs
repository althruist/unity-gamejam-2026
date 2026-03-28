using System.Collections;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    private IEnumerator openLoseScreen()
    {
        CinematicLetterbox.Instance.duration = 0f;
        CinematicLetterbox.Instance.active = true;
        yield return new WaitForSeconds(2f);
        CinematicLetterbox.Instance.duration = 2f;
        CinematicLetterbox.Instance.active = false;
    }

    void Start()
    {
        StartCoroutine(openLoseScreen());
    }
}
