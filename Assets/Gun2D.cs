using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float Timer;
    public GameObject Bullet;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer >= 1.5)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
            Timer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(Bullet);
    }
}
