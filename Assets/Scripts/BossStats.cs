using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStats : MonoBehaviour
{
    public int health;
    public GameObject[] Turrets;
    public TurretManager logic;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        logic = GetComponent<TurretManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 80)
        {
            Turrets[0].SetActive(true);
            
            logic.activeTurrets.Add(Turrets[0]);
        }

        if (health == 40)
        {
            Turrets[1].SetActive(true);            
            logic.activeTurrets.Add(Turrets[1]);
        }

     
    }

    public void ChangeHealth(int amount)
    {
        health = health + amount;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerShot")
        {
            ChangeHealth(-20);
        }

    }
}


