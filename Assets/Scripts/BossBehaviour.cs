using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : ColourBase
{
    public int health;
    public TurretPool[] turret;
    [SerializeField] private GameObject player;
    int i = 0;

    public void FixedUpdate()
    {
        if (i >= 50)
        {
            Command();
            i = 0;
        }
        i++;
    }

    //tells random colour to fire
    //call from times section eg coroutine
    private void Command()
    {
        int temp = Random.Range(0, turret.Length);
        turret[temp].Fire(player);
    }
    // boss health
    // now dead event
    // attack 
    // access object pool
    // delay between firing (increase over time)
    // start rate
    // end rate
    // every three minutes increase (public so we can fine tune in editor)
    // coroutine for firing
    // + collider to receive collision

}
