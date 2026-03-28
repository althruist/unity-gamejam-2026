using UnityEngine;

public class Canon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;
    Vector2 canonOffset = new Vector2(-9f, 0f);


    Quaternion clampRotationLow, clampRotationHigh;

    void Start()
    {
        clampRotationLow = Quaternion.Euler(0, 0, -70f);
        clampRotationHigh = Quaternion.Euler(0, 0, +70f);
        FollowCamera();
        

    }

    void Update()
    {
        
        PointAtMouse();


        if (Input.GetKeyDown(KeyCode.R))
        {
            shoot();

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

    public void shoot()
    {
        SpawnBullet();
        GameData.energy -= 10;
    }

    public void PointAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 direction = mousePos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f;

        // Clamp angle
        angle = Mathf.Clamp(angle, -140f, -49f);

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }

}
