using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestShieldLogic : MonoBehaviour
{
    public int charge;
    public GameObject targetOrb;
    public GameObject[] wrongOrbs;
    public GameObject myShot;
    public Text chargeText;

    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            if(charge == 100)
            {
                playerShoot();
            }
        }

        chargeText.text = charge.ToString();
    }

    public void GainCharge(int amount)
    {
        charge = charge + amount;
    }

    public void LoseCharge(int amount)
    {
        charge = charge + amount;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == targetOrb)
        {

            GainCharge(20);
            Destroy(coll.gameObject);
        }
        if (coll.gameObject == wrongOrbs[0])
        {
            LoseCharge(-20);
            Destroy(coll.gameObject);
        }
        if (coll.gameObject == wrongOrbs[1])
        {
            LoseCharge(-20);
            Destroy(coll.gameObject);
        }
        if (coll.gameObject == wrongOrbs[2])
        {
            LoseCharge(-20);
            Destroy(coll.gameObject);
        }

        
    }

    public void playerShoot()
    {
        GameObject newShot = Instantiate(myShot, this.transform.position, this.transform.rotation);
    }

    


}
