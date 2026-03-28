using UnityEngine;

public class Laser : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * 10f;
    }
    // void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Tile"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
