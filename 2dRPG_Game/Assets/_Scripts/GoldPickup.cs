﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value;
    public MoneyManager theMM;
    // Start is called before the first frame update
    void Start()
    {
        theMM = FindObjectOfType<MoneyManager>();
        value = Random.Range(1, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name== "Player")
        {
            theMM.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
