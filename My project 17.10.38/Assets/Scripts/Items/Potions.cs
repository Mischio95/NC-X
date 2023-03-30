using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{

    public float healtToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
       {
            collision.GetComponent<PlayerHealt>().healt += healtToGive;
            Destroy(gameObject);
        }
    }
}
