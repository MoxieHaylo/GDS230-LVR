using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileActions : MonoBehaviour
{

    GameObject myTarget;
    public OrbType type;
    

    // Start is called before the first frame update
    void Start()
    {
        myTarget = GameObject.FindGameObjectWithTag("Player");
        
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
        if(coll.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        
    }

    
    
        
    
}

public enum OrbType { Green, Red, Blue, Yellow}