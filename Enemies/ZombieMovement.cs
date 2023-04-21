using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    // movement
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Transform houseTarget;
    public Transform playerTarget;
    public Animator animator;

    //health
    public float zombieHealth = 100;
    private int noRepeatSound = 2;

    //drops
    public GameObject commonPistolDrop;
    public GameObject rarePistolDrop;
    public GameObject epicPistolDrop;
    public GameObject commonAssaultDrop;
    public GameObject rareAssaultDrop;
    public GameObject epicAssaultDrop;
    public GameObject commonShotgunDrop;
    public GameObject rareShotgunDrop;
    public GameObject epicShotgunDrop;
    
    public int drop; // randomizes drop

    void Start()
    {
        houseTarget = GameObject.FindGameObjectWithTag("House").transform;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        drop = Random.Range(0, 500);
    }

    void FixedUpdate()
    {
        if (animator.GetBool("isDead") == false)
        {
            if (Vector3.Distance(transform.position, playerTarget.position) > .1f && Vector3.Distance(transform.position, playerTarget.position) < 2.5f)
            {
                transform.LookAt(playerTarget.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                transform.Translate(new Vector3(5 * moveSpeed * Time.deltaTime, 0, 0));
                animator.SetBool("isWalking", true);
            }
            else if (Vector3.Distance(transform.position, houseTarget.position) > .1f)
            {
                transform.LookAt(houseTarget.position);
                transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
                animator.SetBool("isWalking", true);
            }
        }


        if (zombieHealth <= 0)
        { 
            if (noRepeatSound == 2)
            {
                FindObjectOfType<AudioManager>().Play("Death");
                noRepeatSound += 1;
            }
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        GetComponent<Collider2D>().enabled = false;
        animator.SetBool("isWalking", false);
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(1.2f);
        Drop();
        Destroy(gameObject);
    }

    public void Drop()
    {
        // Shotguns
        if (drop >= 90 && drop <= 100)
        {
            if (drop > 95)
            {
                Instantiate(commonShotgunDrop, transform.position, transform.rotation);
            }
            else if (drop > 92)
            {
                Instantiate(rareShotgunDrop, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(epicShotgunDrop, transform.position, transform.rotation);
            }

        }

        // Assault Rifles
        else if (drop < 90 && drop >= 50)
        {
            if (drop > 65)
            {
                Instantiate(commonAssaultDrop, transform.position, transform.rotation);
            }
            else if (drop > 55)
            {
                Instantiate(rareAssaultDrop, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(epicAssaultDrop, transform.position, transform.rotation);
            }
        }

        // Pistols
        else if (drop < 50)
        {
            if (drop > 15)
            {
                Instantiate(commonPistolDrop, transform.position, transform.rotation);
            }else if (drop > 5)
            {
                Instantiate(rarePistolDrop, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(epicPistolDrop, transform.position, transform.rotation);
            }
            
        }
    }
}
