using UnityEngine;

public class Canon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;
    Vector2 canonOffset = new Vector2(-9f, 0f);

    void Start()
    {
        FollowCamera();
        

    }

    void Update()
    {
        
        PointAtMouse();
        

        if (Input.GetMouseButtonDown(0))
        {
            SpawnBullet();
            Debug.Log("Fire");
            GameData.energy -= 10;
        }
    }
    void FollowCamera()
    {
        Vector3 camPos = Camera.main.transform.position;

        float scaleFactor = (float)GameData.gridLenght / 10.0f;

        // Position (your existing logic, fixed syntax)
        transform.position = camPos + new Vector3(canonOffset.x, canonOffset.y, 10f) * scaleFactor;

        
        transform.localScale = Vector3.one * scaleFactor /2;
    }

    public void SpawnBullet()
    {
        Instantiate(laserPrefab, firePoint.position, transform.rotation);

    }


    public void PointAtMouse()
    {

        Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f); ;


        mousePos.z = transform.position.z;


        transform.up = mousePos - transform.position;
    }

}
