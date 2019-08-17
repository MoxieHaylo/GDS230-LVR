using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretLogic : MonoBehaviour
{
    public GameObject[] waypoints;   
    int myCurrentWaypoint;
    private int nextWaypoint;
    public GameObject myProjectile;
    public int fireChance;
    public bool isMoving;
    public float WaitTime = 1.0f;
    public bool run = false;
    private ParticleSystem chargeUpParticle;
    float speed;
    public Transform myTarget;
    private Animator animator;
    public int turretNumber;
    public TurretManager turretManager;
    BossLogic myStats;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        myCurrentWaypoint = 0;
        myStats = GetComponentInParent<BossLogic>();
        speed = 0.3f;
        chargeUpParticle = GetComponentInChildren<ParticleSystem>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = myTarget.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            animator.SetBool("isMoving", true);
            run = false;
            MoveToWaypoint();
        }      
        if(isMoving == false)
        {
            
            if (!run)
            {

            }
                //Shoot();
            //shootProjectile();
        }
    }

    void MoveToWaypoint()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, waypoints[myCurrentWaypoint].transform.position, speed);

        if (transform.position == waypoints[myCurrentWaypoint].transform.position)
        {
            isMoving = false;
            nextWaypoint = Random.Range(1, waypoints.Length);
            /*if (nextWaypoint == myCurrentWaypoint)
            {
                nextWaypoint = Random.Range(0, waypoints.Length);
            }*/
            myCurrentWaypoint = nextWaypoint;
            GameObject t = waypoints[myCurrentWaypoint];
            waypoints[myCurrentWaypoint] = waypoints[0];
            waypoints[0] = t;
        }
    }

    public IEnumerator Fire()
    {
        if(turretNumber == turretManager.nextTurretToFire)
        {
            //animator.SetBool("isMoving", false);
            run = true;
            animator.SetBool("isMoving", false);
            chargeUpParticle.Emit(1);
            yield return new WaitForSeconds(1);
            fireChance = 0;
            //fireChance = Random.Range(0, 1);
            if (fireChance == 0)
                shootProjectile();
            AudioManager.Playsound("GeneratingShield_02");
            //int delayTime = Random.Range(2, 4);
            yield return new WaitForSeconds(0.5f);
            isMoving = true;
            //MoveToWaypoint();
        }
    }

    void shootProjectile()
    {
        //fireChance = Random.Range(0, 4);
        if (fireChance == 0)
        {
            GameObject newProjectile = Instantiate(myProjectile, this.transform.position, this.transform.rotation);
        }
       
    }
}
