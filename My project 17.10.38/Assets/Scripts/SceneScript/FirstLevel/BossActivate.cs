using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : MonoBehaviour
{

    public GameObject bossGo;

    private void Start()
    {
        bossGo.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            BossUI.instance.BossActivator();
            AudioManager.instance.StopAudio(AudioManager.instance.backgroundMusic);
            AudioManager.instance.PlayAudio(AudioManager.instance.backgroundMusicBoss);
            StartCoroutine(WaitForBoss());
        }
    }

    IEnumerator WaitForBoss()
    {
        //var currentSpeed = PlayerController.instance.speed;
        //PlayerController.instance.speed = 0f;
        //bossGo.SetActive(true);
        //yield return new WaitForSeconds(2f);
        //PlayerController.instance.speed = currentSpeed;
        //Destroy(gameObject);

        var velocity = PlayerController.instance.GetComponent<Rigidbody2D>().velocity;
        Vector2 originalSpeed = velocity;
        bossGo.SetActive(true);
        velocity = new Vector2(0, velocity.y);
        PlayerController.instance.enabled = false;
        yield return new WaitForSeconds(3f);
        PlayerController.instance.enabled = true;
        velocity = originalSpeed;
        Destroy(gameObject);


    }
}
