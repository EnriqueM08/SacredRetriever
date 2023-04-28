using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Character player;

    void Update() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }
    public void UpdateHealthBar() {
        healthBarImage.fillAmount = Mathf.Clamp(player.currentHealth / player.maxHealth, 0, 1f);
    }
}
