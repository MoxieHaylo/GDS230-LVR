using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStats : MonoBehaviour
{
    public int health;
    public Text BossHealthText;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        BossHealthText.text = health.ToString();
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
