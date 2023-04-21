using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemImage;
    public GameObject weapon;

    private bool canPickUp = false;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canPickUp = false;
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        GameObject go = Instantiate(weapon);
                        inventory.weapons[i] = go;
                        go.SetActive(false);
                        Instantiate(itemImage, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canPickUp = false;
    }
}
