using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image Health;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    PlayerControls player;

    private void Start()
    {
        //Find
        Health = GetComponent<Image>();
        player = FindObjectOfType<PlayerControls>();
    }

    private void Update()
    {
        CurrentHealth = player.playerHealth;
        Health.fillAmount = CurrentHealth / MaxHealth;
    }
}
