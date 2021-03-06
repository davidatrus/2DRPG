using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    private PlayerStats thePlayerStats;
    public int expToGive;
    public int health2Give;
    public GameObject Drop;
    public string enemyQuestName;
    private QuestManager theQM;

    void Start()
    {
        CurrentHealth = MaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStats>();
        theQM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            theQM.enemyKilled = enemyQuestName;
            Destroy(gameObject);
            thePlayerStats.AddExperience(expToGive);
            thePlayerStats.AddHealth(health2Give);
            Instantiate(Drop, transform.position, transform.rotation);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }

}
