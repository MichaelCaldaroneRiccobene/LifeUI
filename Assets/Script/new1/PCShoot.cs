using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCShoot : MonoBehaviour
{
    [SerializeField] private Bullet bulletPreFab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private float fireRate = 0.5f;

    private float lastTimeShoot;
    private List<Bullet> poolBullet = new List<Bullet>();

    private void Start()
    {
        //for (int i = 0; i < poolSize; i++) SpawnBullet();
        Bullet bullet = Instantiate(bulletPreFab);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) TryShoot();
    }

    private void TryShoot()
    {
        if(Time.time - lastTimeShoot >= fireRate) Shoot();
    }

    private void Shoot()
    {
        lastTimeShoot = Time.time;
        Vector3 spawnPos = transform.position + transform.forward * 1.2f; spawnPos.y = 1.5f;

        Bullet bullet = GetBullet();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = spawnPos;
        bullet.ShootForce(transform.forward);
    }

    private Bullet GetBullet()
    {
        foreach(Bullet bullet in poolBullet)
        {
            if(!bullet.gameObject.activeInHierarchy) return bullet;
        }
        return SpawnBullet();
    }

    private Bullet SpawnBullet()
    {
        Bullet bullet = Instantiate(bulletPreFab);
        poolBullet.Add(bullet);
        bullet.gameObject.SetActive(false);  
        return bullet;
    }
}
