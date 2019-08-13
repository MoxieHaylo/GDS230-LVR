using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public List<GameObject> activeTurrets = new List<GameObject>();
    public int nextTurretToFire;
    public int turretWhichFired;
    //public GameObject redTurret;
    public GameObject turret;

    // Start is called before the first frame update
    void Awake()
    {
        EventTrigger.OnHit += Shoot;
    }

    private void Start()
    {
        //redTurret = activeTurrets[0];
        //TurretLogic logic = redTurret.GetComponent<TurretLogic>();
        //logic.StartCoroutine(logic.Fire());
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        //Turret range will be 0 to 3
        nextTurretToFire = Random.Range(0, activeTurrets.Count);

        if (nextTurretToFire == turretWhichFired)
        {
            Shoot();
        }
        else if (nextTurretToFire != turretWhichFired)
        {
            turret = activeTurrets[nextTurretToFire];
            TurretLogic logic = turret.GetComponent<TurretLogic>();
            foreach (GameObject g in activeTurrets)
            {
                g.GetComponent<TurretLogic>().StopAllCoroutines();
            }
            logic.StartCoroutine(logic.Fire());
            turretWhichFired = nextTurretToFire;
        }
    }
}
