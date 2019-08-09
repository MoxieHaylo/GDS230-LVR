using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventTrigger : MonoBehaviour
{
    public delegate void ShootEvent();
    public static event ShootEvent OnHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        OnHit();
    }
}
