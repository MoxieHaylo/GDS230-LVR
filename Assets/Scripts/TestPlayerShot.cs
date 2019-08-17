using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerShot : MonoBehaviour
{
    GameObject myTarget;
    
    

    // Start is called before the first frame update
    void Start()
    {
        myTarget = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, myTarget.transform.position, 0.1f);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Boss")
        {
            AudioManager.Playsound("BossHit_02");
            Destroy(this.gameObject);
        }

    }

    
}
