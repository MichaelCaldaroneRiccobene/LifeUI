using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camerae : MonoBehaviour
{
    [SerializeField] private float speedLerp = 0.01f;
    [SerializeField] float distanceX = -0.75f;
    [SerializeField] float distanceY = -2.5f;
    [SerializeField] float distanceZ = 3f;
    [SerializeField] Transform target;

    private PlayerController playerController;

    private void Start()
    {
        if(playerController == null) playerController = FindObjectOfType<PlayerController>();

    }

    private void Update()
    {
        //speedLerp = Mathf.Clamp(playerController.rb.velocity.magnitude / 1.5f, 5, 15);
    }
    private void FixedUpdate()
    {
        Vector3 posPlayer = target.transform.position;
        posPlayer.x -= distanceX;
        posPlayer.y -= distanceY;
        posPlayer.z -= distanceZ;


        transform.position = Vector3.Lerp(transform.position, posPlayer, 5 * Time.fixedDeltaTime);
    }
}
