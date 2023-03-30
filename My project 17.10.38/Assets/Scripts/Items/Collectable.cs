using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int boneToGive;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SubItems.instance.SubItemCount(boneToGive);
            AudioManager.instance.PlayAudio(AudioManager.instance.boneRing);
            Destroy(gameObject);
        }
    }
}
