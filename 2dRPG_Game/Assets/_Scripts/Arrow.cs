using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public float ArrowVelocity;
    [HideInInspector] public float ArrowDamage;
    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public GameObject damageNumber;

    private PlayerStats thePS;
    [SerializeField] Rigidbody2D rb;

    public void Start()
    {
        thePS = FindObjectOfType<PlayerStats>();
        Destroy(gameObject,1.5f);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * ArrowVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + thePS.currentAttack;
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, transform.position, transform.rotation);
            var clone = (GameObject)Instantiate(damageNumber, transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            Destroy(gameObject);
        }
    }

}
