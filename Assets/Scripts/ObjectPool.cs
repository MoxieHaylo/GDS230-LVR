using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //List
    public List<OrbBehaviour> orbTypes;
    public OrbBehaviour orbPrefab;
    public Vector3 spawnPosition;

    //choose and fire orb
    public void Fire()
    {
        if(orbTypes.Count>0)
        {
            Debug.Log("I'm picking an orb and firing it");
            orbTypes[0].Reset(spawnPosition);
            orbTypes[0].gameObject.SetActive(true);
            orbTypes[0].transform.parent = null; //kick that child out
        }
        else //ran out - restocking
        {
            Instantiate(orbPrefab, spawnPosition, Quaternion.identity);
        }
    }

    //sends all good orbs back home
    public void Despawn(OrbBehaviour orbToReturn)
    {
        orbTypes.Add(orbToReturn);
        orbToReturn.gameObject.SetActive(false);
        orbToReturn.transform.parent = this.transform;
    }

    //prefabs
    // orb behaviour    blue
    // ''               red
    // ''               yellow
    // ''               green
    
    // dictionary OrbBehaviour is key - has list of orb behaviours, pools from here
    //Dictionary<OrbBehavior,List<OrbBehavior>>OrbPool;

    private void Awake()
    {
        // for each prefab we need new behaviour + to dictionary
        //bOrb = this.GetComponent<Rigidbody>();
    }
    


    // get.Orb
    // return.Orb

}