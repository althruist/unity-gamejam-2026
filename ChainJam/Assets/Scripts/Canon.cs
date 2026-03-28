using UnityEngine;

public class Canon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;
    Vector2 canonOffset = new Vector2(-10f, -5f);

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
        }
    }
    void FollowCamera()
    {
        Camera.main.orthographicSize = 5 * ((float)GameData.gridLenght / 10.0f);
        Vector3 camPos = Camera.main.transform.position;

        // Keep cannon at a fixed offset from the camera
        transform.position = camPos + new Vector3(canonOffset.x, canonOffset.y, z: 10f);
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
