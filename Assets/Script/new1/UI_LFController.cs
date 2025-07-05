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
    [SerializeField] private Gradient gradient;
    [SerializeField] private bool isGradient;

    public void UpdateUILifebar(int hp, int maxHp)
    {
        imageHp.fillAmount = (float)hp / maxHp;
        if (textHp != null) textHp.text = "Hp" + hp + "/" + maxHp;
        if(isGradient) imageHp.color = gradient.Evaluate(imageHp.fillAmount);
    }

    private void LateUpdate()
    {
        if(target != null) transform.position = target.position;
    }
}