using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject spacebar;
    [SerializeField] private GameObject mouse;
    [SerializeField] private Animator animator;

    void Update()
    {
        bool isPressed = Input.GetKey(KeyCode.Space);
        bool isMousePressed = Input.GetMouseButton(0);

        animator.SetBool("spacebarPressed", isPressed);
        animator.SetBool("mousePressed", isMousePressed);
    }
}
