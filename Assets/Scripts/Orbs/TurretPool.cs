using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPool : MonoBehaviour
{
    [SerializeField] private GameObject orb;
    

    public void Fire(GameObject player)
    {
        GameObject temp = Instantiate(orb, transform.position, transform.rotation);
        temp.GetComponent<OrbBase>().player = player;
    }
}
