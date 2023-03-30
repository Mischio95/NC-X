using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    public GameObject bossPanel;
    public GameObject muro; // Da dare entrambi i muri

    public static BossUI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        bossPanel.SetActive(false);
        muro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossActivator()
    {
        bossPanel.SetActive(true);
        muro.SetActive(true);
    }

    public void BossDeactivator()
    {
        bossPanel.SetActive(false);
        muro.SetActive(false);
        AudioManager.instance.StopAudio(AudioManager.instance.backgroundMusicBoss);
        AudioManager.instance.PlayAudio(AudioManager.instance.backgroundMusic);
        StartCoroutine(BossDefeated());
    }

    IEnumerator BossDefeated()
    {
        var velocity = PlayerController.instance.GetComponent<Rigidbody2D>().velocity;
        Vector2 originalSpeed = velocity;
        velocity = new Vector2(0,velocity.y);
        PlayerController.instance.enabled = false;
        yield return new WaitForSeconds(5);
        PlayerController.instance.enabled = true;
        velocity = originalSpeed;
    }
}
