using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOrHeal : MonoBehaviour
{
    [SerializeField] float ammountForSecons;

    private void OnTriggerStay(Collider other)
    {
        LFController life = other.GetComponent<LFController>();
        if (life != null) life.UpdateHp(ammountForSecons * Time.deltaTime);
    }
}
