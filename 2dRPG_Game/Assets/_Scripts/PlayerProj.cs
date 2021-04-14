using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProj : MonoBehaviour
{
    [SerializeField] GameObject ArrowPrefab;
    [SerializeField] SpriteRenderer ArrowGFX;
    [SerializeField] Slider BowPowerSlider;
    [SerializeField] Transform bow;

    [Range(0, 10)]
    [SerializeField] float bowPower;

    [Range(0, 3)]
    [SerializeField] float MaxBowCharge;

    float BowCharge;
    bool canFire = true;

    private void Start()
    {
        BowPowerSlider.value = 0f;
        BowPowerSlider.maxValue = MaxBowCharge;

    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            ChargeBow();
        }
        else if (Input.GetMouseButtonUp(0) && canFire)
        {
            FireBow();
        } else{
            if(BowCharge > 0f)
            {
                BowCharge -= 1f*Time.deltaTime;
            } else {
                BowCharge = 0f;
                canFire = true;
            }

            BowPowerSlider.value = BowCharge;
        }
    }
     void ChargeBow()
    {
        ArrowGFX.enabled = true;
        BowCharge += Time.deltaTime;
        BowPowerSlider.value = BowCharge;

        if (BowCharge > MaxBowCharge)
        {
            BowPowerSlider.value = MaxBowCharge;
        }
    }
    void FireBow()
    {
        if (BowCharge > MaxBowCharge) BowCharge = MaxBowCharge;

        float ArrowSpeed = BowCharge + bowPower;
        float angle = Utility.AngleTowardsMouse(bow.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        Arrow Arrow = Instantiate(ArrowPrefab, bow.position, rot).GetComponent<Arrow>();
        Arrow.ArrowVelocity = ArrowSpeed;

        canFire = false;
        ArrowGFX.enabled = false;
 

    }
}
