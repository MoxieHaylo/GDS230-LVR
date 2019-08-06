using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestShieldLogic : MonoBehaviour
{
    
    public OrbType targetType;
    TestDeviceLogic charge;
    //public GameObject targetOrb;
    //public GameObject[] wrongOrbs;
    

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
                
                charge.GainCharge(20);
                Destroy(coll.gameObject);
            }
            else
            {
                charge.LoseCharge(-20);
                Destroy(coll.gameObject);
            }
        }
        

        
    }

    

    


}
