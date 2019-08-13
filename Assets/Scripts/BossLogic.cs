using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLogic : MonoBehaviour
{
    public int health;
    public GameObject[] Turrets;
    public GameObject DoorWinOpen;//using this to lerp the door open when the bosses health reaches 0
    public Transform Open;// waypoint for open door position.
    public Transform Closed;//waypoint for closed door position.
    public float OpeningSpeed = 1f;//speed at which the door opens.
    private float speed = 0;
    public TurretManager turretManager;
    private Animator bossAnimator;



    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        bossAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            speed += Time.deltaTime * OpeningSpeed;
            DoorWinOpen.transform.position = Vector3.Lerp(DoorWinOpen.transform.position, Open.position, speed);
        }

    }

    public void ChangeHealth(int amount)
    {
        health = health + amount;
        if (health == 80)
        {
            Turrets[0].SetActive(true);
            turretManager.activeTurrets.Add(Turrets[0]);
            StartCoroutine(Halt());
        }

        if (health == 60)
        {
            StartCoroutine(Halt());
        }

        if (health == 40)
        {
            Turrets[1].SetActive(true);
            turretManager.activeTurrets.Add(Turrets[1]);
            StartCoroutine(Halt());
        }

        if (health == 20)
        {
            StartCoroutine(Halt());
        }

        if (health == 0)
        {
            bossAnimator.SetBool("isDead", true);
        }


    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerShot")
        {
            ChangeHealth(-20);
        }

    }

    //stop current firing procedures
    IEnumerator Halt()
    {
        foreach(GameObject g in turretManager.activeTurrets)
        {
            g.GetComponent<TurretLogic>().StopAllCoroutines();
        }
        yield return new WaitForSeconds(1.0f);
        turretManager.Shoot();
        yield return null;
    }
}

