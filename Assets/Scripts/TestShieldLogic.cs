using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestShieldLogic : MonoBehaviour
{   
    public OrbType targetType;
    TestDeviceLogic charge;
    private ParticleSystem onHitEmit;

    // Start is called before the first frame update
    void Start()
    {
        charge = GetComponentInParent<TestDeviceLogic>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.GetComponent<ProjectileActions>())
        {
            if(coll.GetComponent<ProjectileActions>().type == targetType)
            {
                onHitEmit = GetComponentInChildren<ParticleSystem>();
                onHitEmit.Emit(10);
                AudioManager.Playsound("ShieldBlock_09");
                charge.GainCharge(20);
                Destroy(coll.gameObject);
            }
            else
            {
                AudioManager.Playsound("PlayerCollision_01");
                charge.LoseCharge(-20);
                Destroy(coll.gameObject);
            }
        }   
    }
}
