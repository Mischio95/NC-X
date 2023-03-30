using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject flame;

    public float timeToShoot, countdown;
    public float timeToTP, countdownToTP;

    public float bossHealt, currentHealt;
    public Image healtBossImage;

    private void Start()
    {
        countdown = timeToShoot;
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
        countdownToTP = timeToTP;
    }

    private void Update()
    {

        Countdowns();
        BossDamage();
        BossScale();
    }

    public void Countdowns()
    {
        countdown -= Time.deltaTime;
        countdownToTP -= Time.deltaTime;

        if (countdown <= 0f)
        {
            ShootPlayer();
            countdown = timeToShoot;
            Teleport();
        }

        if (countdownToTP <= 0f)
        {
            countdownToTP = timeToTP;
            Teleport();
        }
    }

    public void ShootPlayer()
    {
        GameObject spell = Instantiate(flame, transform.position, Quaternion.identity);
        AudioManager.instance.PlayAudio(AudioManager.instance.fireBall);
    }

    public void Teleport()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
    }


    public void BossDamage()
    {
        currentHealt = GetComponent<Enemy>().healtPoint;
        healtBossImage.fillAmount = currentHealt / bossHealt;
    }

    private void OnDestroy()
    {
        BossUI.instance.BossDeactivator();
    }

    public void BossScale()
    {
        if(transform.position.x > PlayerController.instance.transform.position.x)
        {
            transform.localScale = new Vector3 (1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
    
}
