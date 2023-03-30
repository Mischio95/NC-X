using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubItems : MonoBehaviour
{
    public Text bonesRingText;
    public int bonesRingAmount;
    public int maxBonesRing;

    public static SubItems instance;


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
        bonesRingText.text = "x " + bonesRingAmount.ToString();
        
    }

    public void SubItemCount(int subItemAmount)
    {
        bonesRingAmount += subItemAmount;

        if (bonesRingAmount >= maxBonesRing)
        {
            bonesRingAmount = maxBonesRing;
        }

        bonesRingText.text = "x " + bonesRingAmount.ToString();
    }
}
