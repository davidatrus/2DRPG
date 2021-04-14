using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public Vector2 fireDir = new Vector2(0, 0);
    
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = fireDir;
        Destroy(gameObject, 1f);
    }

  
}
