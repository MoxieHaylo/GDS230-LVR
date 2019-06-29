using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject bOrb;

      
   

    //prefabs
    // orb behaviour    blue
    // ''               red
    // ''               yellow
    // ''               green



    // dictionary OrbBehaviour is key - has list of orb behaviours, pools from here
    //Dictionary<OrbBehavior,List<OrbBehavior>>OrbPool;

    private void Awake()
    {
        // for each prefab we need new behaviour + to dictionary
        bOrb = this.GetComponent<Rigidbody>();
    }
    


    // get.Orb
    // return.Orb

}