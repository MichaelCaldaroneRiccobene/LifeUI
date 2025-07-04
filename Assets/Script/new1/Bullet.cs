using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float lifeTime = 8;
    [SerializeField] private float damage = 8;

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Invoke("DisableTime", lifeTime);
    }

    public void ShootForce(Vector3 dir)
    {
        rb.AddForce(dir * speed,ForceMode.VelocityChange);
    }

    private void DisableTime()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        LFController life = collision.collider.GetComponent<LFController>();
        life?.UpdateHp(-damage);
    }

}
