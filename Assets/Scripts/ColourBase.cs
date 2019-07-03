using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourBase : MonoBehaviour
{
    [System.Serializable]
    public enum Type
    {
        bOrb,
        gOrb,
        yOrb,
        rOrb
    };
    public Type Colour;
}
