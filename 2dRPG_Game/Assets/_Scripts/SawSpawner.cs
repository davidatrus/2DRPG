using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawner : MonoBehaviour
{

    public SawScript sawPrefab;
    public float sawSpeed;
    private float time = 0;
    public float sawDelay;

    public bool fromRight = false;
    public bool shoot;

    private Vector2 dir2;

    void Start()
    {
        dir2 = new Vector2(sawSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(shoot == true)
        {
            if (time < Time.time)
            {
                SawScript saw = Instantiate(sawPrefab, transform.position, transform.rotation) as SawScript;
                saw.dir = dir2;
                if (fromRight == true)
                {
                    saw.transform.rotation = Quaternion.Euler(0, 0, 180);
                } else
                {
                    saw.transform.rotation = Quaternion.Euler(0, 0, 0);
                } 

                time = Time.time + sawDelay;
            }
        }
        
    }
}
