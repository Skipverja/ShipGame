using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;

    public EntityStats entityStats;

    public void Update()
    {
        bar.fillAmount = entityStats.health / entityStats.maxHealth;
    }
}