using UnityEngine;
using UnityEngine.EventSystems;

public class BombButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip hoverSound;
    public AudioSource audioSource;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData data)
    {
        //Debug.Log("Hovering over bomb button");
        audioSource.PlayOneShot(hoverSound);
        anim.SetBool("IsHovering", true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        //Debug.Log("Stopped hovering over bomb button");
        anim.SetBool("IsHovering", false);
    }
}
