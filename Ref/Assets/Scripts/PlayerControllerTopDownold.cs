using UnityEngine;

public class PlayerControllerTopDownold : MonoBehaviour
{
    private Animator playerAnimator;
    private bool playerMoving;
    //private float moveTime = 0.25f;
    //private float moveTimer = 0;
    private Vector2 originalPos;
    private Vector2 nextPos;
    private int speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {

        //if (!playerMoving)
        //{
        //    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //    {
        //        MoveCheck(Dir.Up);
        //    }
        //    else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //    {
        //        MoveCheck(Dir.Down);
        //    }
        //    else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //    {
        //        MoveCheck(Dir.Left);
        //    }
        //    else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //    {
        //        MoveCheck(Dir.Right);
        //    }
        //}
        //else
        //{
        //    moveTimer += Time.deltaTime;
        //    transform.position = Vector2.Lerp(originalPos,nextPos,Mathf.Clamp01(moveTimer/moveTime));

        //    if (moveTimer > moveTime)
        //    {
        //        EndMove();
        //    }
        //}



        //transform.position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        MoveTest2();



        //playerAnimator.SetBool("PlayerMoving", playerMoving);

        //playerAnimator.SetFloat("PlayerDirX", Input.GetAxis("Horizontal"));
        //playerAnimator.SetFloat("PlayerDirY", Input.GetAxis("Vertical"));
    }

    void MoveTest1()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
            playerAnimator.SetBool("PlayerMoving", true);
            if (Input.GetAxis("Horizontal") > 0)
            {
                playerAnimator.SetFloat("PlayerDirX", 1);
                playerAnimator.SetFloat("PlayerDirY", 0);
            }
            else
            {
                playerAnimator.SetFloat("PlayerDirX", -1);
                playerAnimator.SetFloat("PlayerDirY", 0);
            }
        }
        else
        {
            playerAnimator.SetFloat("PlayerDirX", 0);
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);
            playerAnimator.SetBool("PlayerMoving", true);
            if (Input.GetAxis("Vertical") > 0)
            {
                playerAnimator.SetFloat("PlayerDirX", 0);
                playerAnimator.SetFloat("PlayerDirY", 1);
            }
            else
            {
                playerAnimator.SetFloat("PlayerDirX", 0);
                playerAnimator.SetFloat("PlayerDirY", -1);
            }
        }
        else
        {
            playerAnimator.SetFloat("PlayerDirY", 0);
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            playerAnimator.SetBool("PlayerMoving", false);
            playerAnimator.SetFloat("PlayerDirX", 0);
            playerAnimator.SetFloat("PlayerDirY", 0);
        }
    }

    void MoveTest2()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
            playerAnimator.SetBool("PlayerMoving", true);
            playerAnimator.SetFloat("PlayerDirX", 1);
            playerAnimator.SetFloat("PlayerDirY", 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
            playerAnimator.SetBool("PlayerMoving", true);
            playerAnimator.SetFloat("PlayerDirX", -1);
            playerAnimator.SetFloat("PlayerDirY", 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);
            playerAnimator.SetBool("PlayerMoving", true);
            playerAnimator.SetFloat("PlayerDirX", 0);
            playerAnimator.SetFloat("PlayerDirY", 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);
            playerAnimator.SetBool("PlayerMoving", true);
            playerAnimator.SetFloat("PlayerDirX", 0);
            playerAnimator.SetFloat("PlayerDirY", -1);
        }
        else
        {
            playerAnimator.SetBool("PlayerMoving", false);
            playerAnimator.SetFloat("PlayerDirX", 0);
            playerAnimator.SetFloat("PlayerDirY", 0);
        }
    }



    void MoveCheck(Dir dir)
    {
        Vector3 dirVector = GameData.GetVector3FromDir(dir);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirVector, 1f);
        if (!hit || hit.collider.tag == "StepInteractable")
        {
            MoveCharacter(dirVector);
        }
        //else if (hit.collider.tag == "Block")
        //{
        //    if (hit.collider.GetComponent<IPush>().Push(dir))
        //    {
        //        MoveCharacter(dirVector);
        //    }
        //}
    }

    void MoveCharacter(Vector3 dirVector)
    {
        originalPos = transform.position;
        nextPos = transform.position + (dirVector * GameData.MoveUnit);
        playerMoving = true;
        playerAnimator.SetBool("PlayerMoving", playerMoving);
        playerAnimator.SetFloat("PlayerDirX", dirVector.x);
        playerAnimator.SetFloat("PlayerDirY", dirVector.y);
        //moveTimer = 0;
    }

    void EndMove()
    {
        playerMoving = false;
        CheckFloor();
    }

    void CheckFloor()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        ////Debug.Log((bool) hit);
        //if (hit && hit.collider.tag == "StepInteractable")
        //{
        //    hit.collider.GetComponent<IStepEffect>().StepEffect();
        //}
    }
}
