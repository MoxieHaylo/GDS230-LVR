using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrbBehaviour : MonoBehaviour
{
    public float speed = 3f;
    private Transform target; //where the orb will spawn
    

    private void Awake()
    {
        transform.position= new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
