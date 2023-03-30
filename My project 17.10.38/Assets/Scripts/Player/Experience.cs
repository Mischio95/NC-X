using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Experience : MonoBehaviour
{

    public Image expImage;
    public Text currentLevelText;
    public float currentExperience, expTNL;
    public int currentLevel;
    public static Experience instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentLevelText.text = currentLevel.ToString();
        currentLevel = 1;
        expImage.fillAmount = currentExperience / expTNL;
        
    }

    public void expModifier(float experience)
    {

        currentExperience += experience;

        if(currentExperience >= expTNL)
        {
            expTNL = expTNL * 2;
            currentExperience = 0;
            PlayerHealt.instance.maxHealt += 10f;
            SubItems.instance.maxBonesRing += 10;
            currentLevel++;
            currentLevelText.text = currentLevel.ToString();
        }
        expImage.fillAmount = currentExperience / expTNL;
    }
}
