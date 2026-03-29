using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    public Transform firePoint;
    public GameObject laserPrefab;
    Vector2 canonOffset = new Vector2(-9f, 0f);
    bool isShooting = false;

    [SerializeField] private float shootCooldown = 0.5f; // seconds between allowed shots
    private float nextShootTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        FollowCamera();
    }

    void Update()
    {
        PointAtMouse();
        if (Input.GetKeyDown(KeyCode.Space) && !isShooting && Time.time >= nextShootTime && GameData.energy >= 10)
        {
            Shoot();
        }
    }
    void FollowCamera()
    {
        Vector3 camPos = Camera.main.transform.position;

        transform.position = camPos + new Vector3(canonOffset.x, canonOffset.y, 10f);
    }

    public void SpawnBullet()
    {
        Quaternion rot = transform.rotation;
        Instantiate(laserPrefab, firePoint.position, rot);
    }
    public void OnShootAnimationEnd()
    {
        //Debug.Log("shoot EVENT FIRED");
        animator.SetBool("isShooting", false);
        isShooting = false;
        audioSource.PlayOneShot(audioSource.clip);
        SpawnBullet();
    }

    public void Shoot()
    {
        isShooting = true;
        //Debug.Log("shots");

        GameData.energy -= 10;

        // set next allowed shoot time to enforce cooldown
        nextShootTime = Time.time + shootCooldown;

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