using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;
    private void Awake()
    {
        skillTree = this;
    }
   
    public int[] skillLevels;
    public int[] skillCaps;
    public string[] skillNames;
    public string[] skillDescriptions;

    public List<Skill> SkillList;
    public GameObject skillHolder;

    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

   

    public int skillPoint = 0;


    float currentXP = 0;
    float xpForLevelUp = 1000;
    public int currentLevel = 0;
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentXP += 300f;
            Debug.Log(currentXP);

            updateAllSkillUI();
        }

        if (currentXP >= xpForLevelUp)
        {
            currentLevel++;
            skillPoint++;
            currentXP = 0f;
            xpForLevelUp = xpForLevelUp * Mathf.Pow(1.05f, currentLevel);

            Debug.Log("You Leveled up to Level " + currentLevel);
            Debug.Log("Toatal Skill Points: " + skillPoint);

        }

    }

    private void Start()
    {
      

        skillLevels = new int[5];
        skillCaps = new[] { 1, 5, 5, 2, 10};

        skillNames = new[] { "upgrade 1", "upgrade 2", "upgrade 3", "Booster 4", "booster 5"};
        skillDescriptions = new[]
        {
            "Does a thing",
            "Does another thing",
            "Does a third thing",
            "Does another thing",
            "Does a cool thing"
        };

        foreach (var skill in skillHolder.GetComponentsInChildren<Skill>()) SkillList.Add(skill);
        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>()) ConnectorList.Add(connector.gameObject);

        for (var i = 0; i < SkillList.Count; i++) SkillList[i].id = i;

        SkillList[0].connectedSkills = new[] { 1, 2 };
        SkillList[2].connectedSkills = new[] { 3, 4 };




        updateAllSkillUI();
    }

    public void updateAllSkillUI()
    {
        foreach (var skill in SkillList) skill.updateUI();

      
    }
}
