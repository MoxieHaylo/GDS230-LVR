using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
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
        else (Input.GetButtonDown("Button.DpadRight"))//green
           {
            Debug.Log("Green");
           }
    }



}
