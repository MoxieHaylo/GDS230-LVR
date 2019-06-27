using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    //prefabs
    // orb beha blue
    // ''       red
    // ''       yellow
    // ''       green

    // dictionary OrbBehaviour is key - has list of orb behaviours, pools from here
    Dictionary<OrbBehavior,List<OrbBehavior>>OrbPool;

    private void Awake()
    {
        // for each prefab we need new behaviour + to dictionary
    
    }

    // get.Orb
    // return.Orb

}