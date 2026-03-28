using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Transform firePoint;
    public GameObject laserPrefab;
    Vector2 canonOffset = new Vector2(-9f, 0f);


    Quaternion clampRotationLow, clampRotationHigh;

    void Start()
    {
        animator = GetComponent<Animator>();

        clampRotationLow = Quaternion.Euler(0, 0, -70f);
        clampRotationHigh = Quaternion.Euler(0, 0, +70f);
        FollowCamera();
    }

    void Update()
    {
        
        PointAtMouse();


        if (Input.GetKeyDown(KeyCode.R))
        {
            Shoot();

        }
    }
    void FollowCamera()
    {
        Vector3 camPos = Camera.main.transform.position;

        

        // Position (your existing logic, fixed syntax)
        transform.position = camPos + new Vector3(canonOffset.x, canonOffset.y, 10f) ;

        
        
    }

    public void SpawnBullet()
    {
        Instantiate(laserPrefab, firePoint.position, transform.rotation);

    }
    public void OnShootAnimationEnd()
    {
        Debug.Log("shoot EVENT FIRED");
        animator.SetBool("isShooting", false);
        SpawnBullet();


    }

    public void Shoot()
    {
        Debug.Log("shots");
        GameData.energy -= 10;

        animator.SetBool("isShooting", true);
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
