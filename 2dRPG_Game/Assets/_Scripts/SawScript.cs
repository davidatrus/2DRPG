using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    public Vector2 dir = new Vector2(0, 0);

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

 
    void FixedUpdate()
    {
        rb.velocity = dir;
        Destroy(gameObject, 1.25f);
    }

}
