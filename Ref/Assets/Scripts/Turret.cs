using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float turnSpeed = 3f;
    public float fireTimer = 0;
    public float fireRate = 0.3f;

    public bool firing = true;
    public BulletPool bulletPool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //clampRotationLow = Quaternion.Euler(0, 0, -70f);
        //clampRotationHigh = Quaternion.Euler(0, 0, +70f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = transform.position - target.position;
        Quaternion newRotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        newRotation.x = 0;
        newRotation.y = 0;
        //newRotation.z = Mathf.Clamp(newRotation.z, clampRotationLow.z, clampRotationHigh.z);
        //newRotation.w = Mathf.Clamp(newRotation.w, clampRotationLow.w, clampRotationHigh.w);
        transform.rotation = Quaternion.Slerp(this.transform.rotation, newRotation, Time.deltaTime * turnSpeed);


        fireTimer += Time.deltaTime;

        if (firing && fireTimer >= fireRate)
        {
            fireTimer = 0;
            GameObject poolBullet = bulletPool.GetBullet();

            if (poolBullet != null)
            {
                poolBullet.transform.position = transform.position;
                poolBullet.transform.rotation = transform.localRotation;
                poolBullet.SetActive(true);
                poolBullet.GetComponent<Bullet>().Fire();
            }
        }
    }
}
