using UnityEngine;

public class Laser : MonoBehaviour
{
    Rigidbody2D rb;
    public int lifetime = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * 10f;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Normal tile hit");
        if (collision.gameObject.CompareTag("Tile"))
        {
            lifetime--; 


        }

    }
    void Update()
    {
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }












    // void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Tile"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
