using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBase : ColourBase
{
    public float speed = 3f;
    public GameObject player;
    
    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

}
