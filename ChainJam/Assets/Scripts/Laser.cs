using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Animator animator;
    Rigidbody2D rb;
    public int lifetime = 5;
    public int chainID = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * 10f;

        chainID = GameManager.Instance.StartChain();
    }

    void OnBecameInvisible()
    {
        GameManager.Instance.DeleteChain(chainID, 0);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            //Debug.Log("Tile hit");

            // If it's a bomb, destroy laser immediately
            if (collision.GetComponent<BaseBombTile>() != null)
            {
                Destroy(gameObject);
                return;
            }

            // normal tile logic
            lifetime--;
        }
    }
    void Update()
    {
        if (lifetime <= 0)
        {
            GameManager.Instance.DeleteChain(chainID, 0);
            Destroy(gameObject);
        }
    }


}
