using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponStats : MonoBehaviour
{
    float attack;
    float totalAttack;
    public float weaponAttack;

    public GameObject weaponDamageText;

    private void Start()
    {
    }

    public float damageInput(float enemyDefense, Transform hit)
    {
        totalAttack = attack + weaponAttack + (100 / (100 + enemyDefense));
        float finalAttackPower = Mathf.Round(Random.Range(totalAttack - 10, totalAttack + 5));

        GameObject textGO = Instantiate(weaponDamageText, hit.transform.position, Quaternion.identity);
        textGO.GetComponent<TextMeshPro>().SetText(finalAttackPower.ToString());

        if (finalAttackPower > totalAttack + 4 )
        {
            finalAttackPower *= 2;
            textGO.GetComponent<TextMeshPro>().SetText("CRITICAL! \n" + finalAttackPower.ToString() + "!");
            print("critical");
        }

        if(finalAttackPower < 0)
        {
            finalAttackPower = 0;
            textGO.GetComponent<TextMeshPro>().SetText("MISSED!");
            print("Attack blocked");
        }

        

        StartCoroutine(MoveText(textGO));

        print(finalAttackPower);
        return finalAttackPower;

    }

    IEnumerator MoveText(GameObject go)
    {
        Vector2 initial = new Vector2(go.transform.position.x, go.transform.position.y);
        Vector2 final = new Vector2(go.transform.position.x, go.transform.position.y + 10);
        int upTimes = 0;
        while(upTimes < 6)
        {
            upTimes++;
            go.transform.position = Vector2.MoveTowards(initial, final, 15f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
