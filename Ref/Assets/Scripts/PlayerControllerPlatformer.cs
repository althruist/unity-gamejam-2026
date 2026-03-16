using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerControllerPlatformer : MonoBehaviour
{
    private Animator playerAnimator;
    private int speed = 5;
    private bool playerMoving;
    private int jumpforce = 5;
    private bool jumping = false;

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


        if (!jumping && Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);
            jumping = true;
        }


        playerAnimator.SetFloat("PlayerDirX", Input.GetAxisRaw("Horizontal"));
        playerAnimator.SetBool("PlayerMoving", playerMoving);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Floor")
        {
            jumping = false;
        }
    }
}
