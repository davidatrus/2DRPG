using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CoinRewarder : MonoBehaviour
{
    [SerializeField]
    private int minimumCoinReward = 3;
    [SerializeField]
    private int maximumCoinReward = 5;
    public MoneyManager theMMM;



    public void Start()
    {
        theMMM = FindObjectOfType<MoneyManager>();
    }
    public int MinimumCoinReward
    {
        get { return this.minimumCoinReward; }
        set { this.minimumCoinReward = value; }
    }

    public int MaximumCoinReward
    {
        get { return this.maximumCoinReward; }
        set { this.maximumCoinReward = value; }
    }


    public void Reward()
    {
        // Randomly pick a coin reward within the given range.
        int coins = Random.Range(this.MinimumCoinReward, this.MaximumCoinReward);
        // Reward coins using the game manager.
        theMMM.AddMoney(coins);
    }
}