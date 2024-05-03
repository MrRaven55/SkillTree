using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillTree;

public class Skill : MonoBehaviour
{
    public int id;

    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public int[] connectedSkills;

    public void updateUI()
    {
        titleText.text = $"{skillTree.skillLevels[id]}/{skillTree.skillCaps[id]}\n{skillTree.skillNames[id]}";
        descriptionText.text = $"{skillTree.skillDescriptions[id]}\ncost: {skillTree.skillPoint}/1";

        GetComponent<Image>().color = skillTree.skillLevels[id] >= skillTree.skillCaps[id] ? Color.yellow
            : skillTree.skillPoint >= 1 ? Color.green : Color.white;

        foreach( var connectedSkill in connectedSkills)
        {
            skillTree.SkillList[connectedSkill].gameObject.SetActive(skillTree.skillLevels[id] > 0);
            skillTree.ConnectorList[connectedSkill].SetActive(skillTree.skillLevels[id] > 0);

        }
    }

    public void buy()
    {
        if (skillTree.skillPoint < 1 || skillTree.skillLevels[id] >= skillTree.skillCaps[id]) return;
        skillTree.skillPoint -= 1;
        skillTree.skillLevels[id]++;
        skillTree.updateAllSkillUI();
    }

   
}
