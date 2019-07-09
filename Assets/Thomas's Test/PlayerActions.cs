using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject redOrb;
    public GameObject greenOrb;
    public GameObject yellowOrb;
    public GameObject blueOrb;
    private int redCharge;
    private int greenCharge;
    private int yellowCharge;
    private int blueCharge;

    // Start is called before the first frame update
    void Start()
    {
        redCharge = 0;
        greenCharge = 0;
        yellowCharge = 0;
        blueCharge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
