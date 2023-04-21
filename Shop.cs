using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public static bool canShop = false;
    public static bool isPaused = false;
    public GameObject shop;
    PlayerControls player;

    private void Start()
    {
        shop.SetActive(false);
        player = FindObjectOfType<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShop)
        {
            if (Input.GetKeyDown(KeyCode.F) && !isPaused)
            {
                Pause();
            } else if (Input.GetKeyDown(KeyCode.F) && isPaused)
            {
                Resume();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canShop = false;
    }

    private void Resume() {
        shop.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause()
    { 
        shop.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    // Upgrades

    public void SpeedCola()
    {
        Debug.Log("button pressed");
        if (player.playerScrap >= 50 && player.moveSpeed < 8)
        {
            player.playerScrap -= 50;
            player.moveSpeed += 2;
            FindObjectOfType<AudioManager>().Play("Purchase");
        }
    }
    
    public void DoubleTap()
    {
        Debug.Log("button pressed");
        if (player.playerScrap >= 70 && player.upgradeDamage < 8)
        {
            player.playerScrap -= 70;
            player.upgradeDamage += 2f;
            FindObjectOfType<AudioManager>().Play("Purchase");
        }
    }
}
