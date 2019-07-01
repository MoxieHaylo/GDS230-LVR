using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour
{
    GameObject target; //player
    [System.Serializable]
    public enum OrbType
    {
        bOrb,   
        gOrb,   
        yOrb,   
        rOrb
    };

    public OrbType orbType;

    

    // fire method
    private void Awake()
    {
        orbType = (OrbType)Random.Range(0, 4);
        //target = gameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 0.005f);
        transform.LookAt(target.transform.position);
    }


    // var this.type
    // mesh + collider
    




}


