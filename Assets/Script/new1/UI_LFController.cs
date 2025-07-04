using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LFController : MonoBehaviour
{
    [SerializeField] private Image imageHp;
    [SerializeField] private TextMeshProUGUI textHp;
    [SerializeField] private Transform target;

    public void UpdateUILifebar(int hp, int maxHp)
    {
        imageHp.fillAmount = (float)hp / maxHp;
        if (textHp != null) textHp.text = "Hp" + hp + "/" + maxHp;
    }

    private void LateUpdate()
    {
        if(target != null) transform.position = target.position;
    }
}