using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPool : MonoBehaviour
{
    //List
    public List<GreenOrbBehaviour> blueOrbs;
    public GreenOrbBehaviour bluePrefab;
    public Vector3 spawnPosition;

    public void FireGreen()
    {
        if(blueOrbs.Count>0)
        { 
        Debug.Log("I'm picking an orb and firing it");
        //orbTypes[0].Reset(spawnPosition);
        orbTypes[0].gameObject.SetActive(true);
        orbTypes[0].transform.parent = null; //kick that child out
        }
        else //ran out - restocking
        {
            Instantiate(orbPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void DespawnGreen(GreenOrbBehaviour returnGreenOrb)
    {
        orbTypes.Add(orbToReturn);
        orbToReturn.gameObject.SetActive(false);
        orbToReturn.transform.parent = this.transform;
    }

    private void Awake()
    {
        
    }
}
