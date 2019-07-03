using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ShieldBehaviour shield;


    private void OnTriggerEnter(Collider other)
    {
        OrbBase orbBase = other.gameObject.GetComponent<OrbBase>();
        if (orbBase != null)
        {
            Destroy(other.gameObject);
            shield.Miss(orbBase.Colour);
        }
    }
}
