using UnityEngine;

public class PlayerControllerTopDown : MonoBehaviour
{
    private Animator playerAnimator;
    private int speed = 5;
    private bool playerMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector2((Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed), 0f));
            playerMoving = true;
            //Get current x
            //lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector2(0f, (Input.GetAxisRaw("Vertical") * Time.deltaTime * speed)));
            playerMoving = true;
            //Get current y
            //lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        playerAnimator.SetFloat("PlayerDirX", Input.GetAxisRaw("Horizontal"));
        playerAnimator.SetFloat("PlayerDirY", Input.GetAxisRaw("Vertical"));
        playerAnimator.SetBool("PlayerMoving", playerMoving);
    }
}
