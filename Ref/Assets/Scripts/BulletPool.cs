using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletObject;
    public int poolNumber = 30;
    List<GameObject> pooledBullets;

    void Start()
    {
        pooledBullets = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < poolNumber; i++)
        {
            tmp = Instantiate(bulletObject);
            //tmp.GetComponent<Bullet>().Velocity = bulletScriptableObject.velocity;
            //tmp.GetComponent<Bullet>().FireRate = bulletScriptableObject.firingRate;
            tmp.SetActive(false);
            tmp.transform.SetParent(this.transform);
            pooledBullets.Add(tmp);
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < poolNumber; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        return null;
    }
}
