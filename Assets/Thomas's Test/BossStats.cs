using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStats : MonoBehaviour
{
    public int health;
    public Text BossHealthText;
    public GameObject[] Turrets;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        BossHealthText.text = health.ToString();

        if (health == 80)
        {
            Turrets[0].SetActive(true);
        }

        if (health == 60)
        {
            Turrets[1].SetActive(true);
        }

        if (health == 40)
        {
            Turrets[2].SetActive(true);
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
