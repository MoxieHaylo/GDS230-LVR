using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPool : MonoBehaviour
{
    //List
    public List<GreenOrbBehaviour> greenOrbs;
    public GreenOrbBehaviour greenPrefab;
    public Vector3 spawnPosition;

    public void FireGreen()
    {
        //if (Input.GetKeyDown.(KeyCode.Space))
        //if (greenOrbs.Count>0)
        { 
        Debug.Log("I'm picking an orb and firing it");
        //greenOrbs[0].Reset(spawnPosition);
        //greenOrbs[0].gameObject.SetActive(true);
        //greenOrbs[0].transform.parent = null; //kick that child out
        //}
        //else //ran out - restocking
        //{
        //    Instantiate(greenPrefab, spawnPosition, Quaternion.identity);
        }
    }
    /*
    public void DespawnGreen(GreenOrbBehaviour returnGreenOrb)
    {
        orbTypes.Add(orbToReturn);
        orbToReturn.gameObject.SetActive(false);
        orbToReturn.transform.parent = this.transform;
    }
    */
    void Awake()
    {
        
    }
}
