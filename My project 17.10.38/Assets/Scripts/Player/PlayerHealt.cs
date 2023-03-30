using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealt : MonoBehaviour
{
    public float healt;
    public float maxHealt;
    bool isInmune;
    public float inmunityTime;
    SpriteRenderer sprite;
    Blink material;
    public float knockbackForceX;
    public float knockbackForceY;
    Rigidbody2D rigidBody;
    public Image healtImage;


    public GameObject gameOverImage;
    public static PlayerHealt instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        gameOverImage.SetActive(false);
        material = GetComponent<Blink>();
        sprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        healt = maxHealt;
    }

    // Update is called once per frame
    void Update()
    {
        healtImage.fillAmount = healt / maxHealt; // PERCHE LA SALUTE MASSIMA E' 100 e il fill � 1 
        if(healt > maxHealt)
        {
            healt = maxHealt;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !isInmune)
        {
            healt -= collision.GetComponent<Enemy>().damageToGive;
            AudioManager.instance.PlayAudio(AudioManager.instance.enemyDeath);

            StartCoroutine(Inmunity());

            if(collision.transform.position.x > transform.position.x)
            {
                rigidBody.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rigidBody.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }

            if (healt < 0)
            {
                Time.timeScale = 0;
                AudioManager.instance.StopAudio(AudioManager.instance.backgroundMusic);
                gameOverImage.SetActive(true);
            }
        }
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        isInmune = false;
    }
}
