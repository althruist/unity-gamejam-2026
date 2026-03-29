using UnityEngine;

public class Explosion : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void onExplosion()
    {
        Debug.Log("Explosion event fired");
        audioSource.PlayOneShot(audioSource.clip);
    }
}
