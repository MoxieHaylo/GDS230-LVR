using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeviceLogic : MonoBehaviour
{

    public GameObject[] Shields;
    
    

    // Start is called before the first frame update
    void Start()
    {
           
    }

    void Update()
    {
        if (Input.GetKeyDown("w")) //Red Shield Activation
        {
            Shields[0].SetActive(true);
            Shields[1].SetActive(false);
            Shields[2].SetActive(false);
            Shields[3].SetActive(false);
        }

        if (Input.GetKeyDown("a")) //Green Shield Activation
        {
            Shields[0].SetActive(false);
            Shields[1].SetActive(true);
            Shields[2].SetActive(false);
            Shields[3].SetActive(false);
        }

        if (Input.GetKeyDown("s")) //Yellow Shield Activation
        {
            Shields[0].SetActive(false);
            Shields[1].SetActive(false);
            Shields[2].SetActive(true);
            Shields[3].SetActive(false);
        }

        if (Input.GetKeyDown("d")) //Blue Shield Activation
        {
            Shields[0].SetActive(false);
            Shields[1].SetActive(false);
            Shields[2].SetActive(false);
            Shields[3].SetActive(true);
        }
    }

    

}
