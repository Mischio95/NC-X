using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    Enemy enemy;
    public GameObject deathEffect;
    public bool isDameged;
    public SpriteRenderer sprite;
    Blink blink;
    Rigidbody2D rigidBody;

    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        blink = GetComponent<Blink>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon") && !isDameged)
        {
            //enemy.healtPoint -= 2f;
            enemy.healtPoint -= collision.GetComponent<WeaponStats>().damageInput(enemy.defense, this.transform);

            AudioManager.instance.PlayAudio(AudioManager.instance.hit);

            // Se il player colpisce il nemico applica una forza e lo spinge a destra o sinistra in base allo scale 
            if (collision.transform.position.x < transform.position.x)
            {
                rigidBody.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rigidBody.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            
            StartCoroutine(Dameger());
            if (enemy.healtPoint <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Experience.instance.expModifier(GetComponent<Enemy>().experienceToGive);
                AudioManager.instance.PlayAudio(AudioManager.instance.enemyDeath);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Dameger()
    {
        isDameged = true;
        sprite.material = blink.blink;
        yield return new WaitForSeconds(0.3f);
        isDameged = false;
        sprite.material = blink.original;
    }
}
