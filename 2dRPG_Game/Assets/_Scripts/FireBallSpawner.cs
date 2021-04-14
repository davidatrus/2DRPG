using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawner : MonoBehaviour
{
    public FireBallScript BallFirePrefab;
    public float fireBallSpeed;
    private float time = 0;
    public float fireBallDelay;
    public bool shoot;
    private Vector2 fireDir2;

    void Start()
    {
        fireDir2 = new Vector2(0, fireBallSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot == true)
        {
            if (time < Time.time)
            {
                FireBallScript BallFire = Instantiate(BallFirePrefab, transform.position, transform.rotation) as FireBallScript;
                BallFire.fireDir = fireDir2;

                time = Time.time + fireBallDelay;
            }
        }
    }
}
