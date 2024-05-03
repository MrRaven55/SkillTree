using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    float currentXP = 0;
    float xpForLevelUp = 1000;
   public int currentLevel = 0;
    public int skillPoints = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentXP += 300f;
            Debug.Log(currentXP);
        }

        if(currentXP >= xpForLevelUp)
        {
            currentLevel++;
            skillPoints++;
            currentXP = 0f;
            xpForLevelUp = xpForLevelUp * Mathf.Pow(1.12f, currentLevel);

            Debug.Log("You Leveled up to Level " + currentLevel);  
            Debug.Log("Toatal Skill Points: " + skillPoints);

        }

    }


}
