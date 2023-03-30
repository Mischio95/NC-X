using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapon : MonoBehaviour
{

    public int BoneHeartCost;

    public GameObject boneRing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseSubWeapon();
    }

    public void UseSubWeapon()
    {
        if(Input.GetButtonDown("Fire2") && BoneHeartCost <= SubItems.instance.bonesRingAmount)
        { 
            SubItems.instance.SubItemCount(-BoneHeartCost);
            AudioManager.instance.PlayAudio(AudioManager.instance.boneRing);
            GameObject subItem = Instantiate(boneRing, transform.position, Quaternion.Euler(0,0,-32));

            if(transform.localScale.x < 0)
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-700f, 0f), ForceMode2D.Force);
            }
            else
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(700f, 0f), ForceMode2D.Force);
            }
        }
    }
}
