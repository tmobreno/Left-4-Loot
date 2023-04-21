using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public bool[] isSelected;
    public GameObject[] slots;
    public GameObject[] weapons;
    public GameObject selector;

    private void Start()
    {       
    }

    private void Update()
    {
        var selectorpos = selector.transform.position;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectorpos.x = slots[0].transform.position.x;
            selectorpos.y = slots[0].transform.position.y + 75f;
            selector.transform.position = selectorpos;
            isSelected[0] = true;
            isSelected[1] = false;
            isSelected[2] = false;
            selectSlot0();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectorpos.x = slots[1].transform.position.x;
            selectorpos.y = slots[1].transform.position.y + 75f;
            selector.transform.position = selectorpos;
            isSelected[0] = false;
            isSelected[1] = true;
            isSelected[2] = false;
            selectSlot1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectorpos.x = slots[2].transform.position.x;
            selectorpos.y = slots[2].transform.position.y + 75f;
            selector.transform.position = selectorpos;
            isSelected[0] = false;
            isSelected[1] = false;
            isSelected[2] = true;
            selectSlot2();
        }

    }

    private void selectSlot0()
    {
        if (isSelected[0] == true)
        {
            if(weapons[1] != null)
            {
                weapons[1].SetActive(false);
            }
            if (weapons[2] != null)
            {
                weapons[2].SetActive(false);
            }

            weapons[0].SetActive(true);
        }
    }
    private void selectSlot1()
    {
        if (isSelected[1] == true)
        {
            if (weapons[0] != null)
            {
                weapons[0].SetActive(false);
            }
            if (weapons[2] != null)
            {
                weapons[2].SetActive(false);
            }

            weapons[1].SetActive(true);
        }
    }
    private void selectSlot2()
    {
        if (isSelected[2] == true)
        {
            if (weapons[0] != null)
            {
                weapons[0].SetActive(false);
            }
            if (weapons[1] != null)
            {
                weapons[1].SetActive(false);
            }

            weapons[2].SetActive(true);
        }
    }
}
