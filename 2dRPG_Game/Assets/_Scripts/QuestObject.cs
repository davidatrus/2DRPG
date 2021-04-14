using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{

    public int questNumber;

    public QuestManager theQM;

    public string startText;
    public string endText;

    public bool isEnemyQuest;
    public string targetEnemy;
    public int enemiesToKill;
    private int enemyKillCount;
    private PlayerStats thePlayerStats;
    public int expToGive;

    void Start()
    {
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyQuest)
        {
            if(theQM.enemyKilled == targetEnemy)
            {
                theQM.enemyKilled = null;
                enemyKillCount++;
            }

            if(enemyKillCount>= enemiesToKill)
            {
                EndQuest();
            }
        }
    }

    public void StartQuest()
    {
        theQM.ShowQuestText(startText);
    }
    public void EndQuest()
    {
        theQM.ShowQuestText(endText);
        theQM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
        thePlayerStats.AddExperience(expToGive);
    }
}
