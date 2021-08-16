using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceManager : MonoBehaviour
{
    [SerializeField]
    private GameObject chance1, chance2, chance3;
    public void ManageRemainingChances(int remainingChance)
    {
        if(remainingChance == 3)
        {
            chance1.SetActive(true);
            chance2.SetActive(true);
            chance3.SetActive(true);
        }
        if (remainingChance == 2)
        {
            chance1.SetActive(true);
            chance2.SetActive(true);
            chance3.SetActive(false);
        }
        if (remainingChance == 1)
        {
            chance1.SetActive(true);
            chance2.SetActive(false);
            chance3.SetActive(false);
        }
        if (remainingChance == 0)
        {
            chance1.SetActive(false);
            chance2.SetActive(false);
            chance3.SetActive(false);
        }

    }
    
}
