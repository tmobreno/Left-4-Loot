using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapBar : MonoBehaviour
{
    private Image Scrap;
    public float CurrentScrap;
    private float MaxScrap = 100f;
    PlayerControls player;

    private void Start()
    {
        //Find
        Scrap = GetComponent<Image>();
        player = FindObjectOfType<PlayerControls>();
    }

    private void Update()
    {
        CurrentScrap = player.playerScrap;
        Scrap.fillAmount = CurrentScrap / MaxScrap;
    }
}
