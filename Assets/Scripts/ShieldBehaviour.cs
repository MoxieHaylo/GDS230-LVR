using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : ColourBase
{
    public GameObject blueShield;
    public GameObject yellowShield;
    public GameObject redShield;
    public GameObject greenShield;


   
    //void ShieldChange()
    void Update()
    {
        if (Input.GetKeyDown("w"))//blue
        {
            Debug.Log("Blue");
            blueShield.SetActive(true);
            blueShield.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (Input.GetKeyDown("a"))//red
        {
            Debug.Log("Red");
        }
        else if (Input.GetKeyDown("d"))//yellow
        {
            Debug.Log("Yellow");
           }
        else if (Input.GetKeyDown("s"))//green
        {
            Debug.Log("Green");
            
        }
    }

    public void Miss(Type orbColour)
    {
        switch (orbColour)
        {
            case Type.bOrb:
                Debug.Log("I'm a blue boi, who missed");
                break;
            case Type.yOrb:
                Debug.Log("I'm a yellow boi, who missed");
                break;
            case Type.rOrb:
                Debug.Log("I'm a red boi, who missed");
                break;
            case Type.gOrb:
                Debug.Log("I'm a green boi, who missed");
                break;
            default:
                Debug.Log("colour not listed");
                break;
        }
    }

    private void Correct(Type orbColour)
    {
        switch (orbColour)
        {
            case Type.bOrb:
                Debug.Log("I'm a blue boi. I did not hit her I did not");
                break;
            case Type.yOrb:
                Debug.Log("I'm a yellow boi. I did not hit her I did not");
                break;
            case Type.rOrb:
                Debug.Log("I'm a red boi. I did not hit her I did not");
                break;
            case Type.gOrb:
                Debug.Log("I'm a green boi. I did not hit her I did not");
                break;
            default:
                Debug.Log("colour not listed");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OrbBase orbBase = other.gameObject.GetComponent<OrbBase>();
        if (orbBase != null)
        {
            
            if (orbBase.Colour == Colour)
            {
                Correct(orbBase.Colour);
            }
            else
            {
                //Subtract fuction
                Miss(orbBase.Colour);
            }
            Destroy(other.gameObject);
        }
    }
}
