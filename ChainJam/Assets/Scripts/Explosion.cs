using System.Collections;
using TMPro;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private AudioSource audioSource;
    private TextMeshPro text;
    public bool hasComboEnabled = false;

    public void onExplosion()
    {
        Debug.Log("Explosion event fired");
        text = Instantiate(GameManager.Instance.tileExplosionText);
        Animator animator = text.GetComponent<Animator>();
        animator.Play("text_explodeFloat", 0, 0f);
        Debug.Log("hit");
        if (hasComboEnabled)
        {
            text.SetText($"x{GameManager.Instance.GetChain(GameManager.Instance.currentChain).ToString()}");
        }
        else
        {
            text.SetText("");
        }
        text.transform.position = transform.position;
        audioSource = text.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void onExplosionEnd()
    {
        Destroy(gameObject);
    }
}
