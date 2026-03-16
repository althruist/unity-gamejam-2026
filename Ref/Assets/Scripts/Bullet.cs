using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 10;
    

    protected Rigidbody2D rb;


    void Update()
    {
        CheckBounds();
    }

    protected virtual void CheckBounds()
    {
        if (transform.position.x < GameData.XMin ||
            transform.position.x > GameData.XMax ||
            transform.position.y < GameData.YMin ||
            transform.position.y > GameData.YMax)
        {
            //Debug.Log(transform.position.x + " " + GameData.XMin);
            //Debug.Log(transform.position.x + " " + GameData.XMax);
            //Debug.Log(transform.position.y + " " + GameData.YMin);
            //Debug.Log(transform.position.y + " " + GameData.YMax);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void Fire()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * velocity, ForceMode2D.Impulse);
    }
}
