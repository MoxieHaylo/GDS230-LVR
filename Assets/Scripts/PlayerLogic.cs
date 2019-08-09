using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    TestDeviceLogic charge;
    GameObject myTarget;

    // Start is called before the first frame update
    void Start()
    {
        charge = GetComponentInChildren<TestDeviceLogic>();
        myTarget = GameObject.FindGameObjectWithTag("Orb");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Orb")
        {
            charge.LoseCharge(-20);
            Destroy(coll.gameObject);
        }
    }
}
