using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LFController : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    [SerializeField] private float maxHp = 100;

    public UnityEvent<int, int> onLFChange;
    public float Hp {  get => hp; set => hp = Mathf.Clamp(value, 0, maxHp); }
    public float MaxHp { get => maxHp; }

    private void Start()
    {
        onLFChange?.Invoke((int)Hp, (int)MaxHp);
    }

    public void UpdateHp(float amount)
    {
        int currentHp = (int)Hp;
        Hp += amount;
        if(currentHp == (int)Hp) return;

        if ((int)Hp <= 0) OnDead();
        onLFChange?.Invoke((int)Hp, (int)MaxHp);
    }

    private void OnDead()
    {
        Debug.Log("Morte");
        Destroy(gameObject);
    }
}
