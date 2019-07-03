using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : ColourBase
{
    
    void ShieldChange()
    {
        if(Input.GetButtonDown("Button.DpadUp"))//blue
            {
            Debug.Log("Blue");
            }
        else if(Input.GetButtonDown("Button.DpadDown"))//red
           {
            Debug.Log("Red");
           }
        else if(Input.GetButtonDown("Button.DpadLeft"))//yellow
           {
            Debug.Log("Yellow");
           }
        else if(Input.GetButtonDown("Button.DpadRight"))//green
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
