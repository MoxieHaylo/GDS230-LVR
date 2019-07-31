using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestDeviceLogic : MonoBehaviour
{

    public GameObject[] Shields;
    public int shieldIndex;
    public int charge;
    public GameObject myShot;
    
    public Transform chargeUI;
    public float uiScale = 0f;

    public static UnityAction<bool> onHasController = null;

    public static UnityAction onTriggerUp = null;
    public static UnityAction onTriggerDown = null;
    public static UnityAction onTouchpadUp = null;
    public static UnityAction onTouchpadDown = null;

    private bool hasController = false;
    private bool inputActive = true;

    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDMounted += PlayerLost;
    }

    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
        shieldIndex = 0;

        chargeUI.transform.localScale = new Vector3(charge * uiScale, charge * uiScale, charge * uiScale);
    }

    
    void Update()
    {
        chargeUI = this.gameObject.transform.GetChild(0);

        hasController = CheckForController(hasController);

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            shieldIndex++;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            shieldIndex++;
            SwapShield();

            
        }

       

        Vector2 primaryTouchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        

        
        

        

        if (charge == 100)
        {
            
            playerShoot();
            charge = 0;

            chargeUI.transform.localScale = new Vector3(charge * uiScale, charge * uiScale, charge * uiScale);
        }

        
        
       
    }

    private bool CheckForController(bool currentValue)
    {
        bool controllerCheck = OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) ||
                          OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote);

        if (currentValue == controllerCheck)
            return currentValue;

        if (onHasController != null)
            onHasController(controllerCheck);

        return false;
    }

    public void SwapShield()
    {
        if (shieldIndex >= 4)
        {
            shieldIndex = 0;
        }

        Shields[0].SetActive(false);
        Shields[1].SetActive(false);
        Shields[2].SetActive(false);
        Shields[3].SetActive(false);
        Shields[shieldIndex].SetActive(true);

       

    }

    public void PlayerFound()
    {
        inputActive = true;
    }

    public void PlayerLost()
    {
        inputActive = false;
    }

    public void GainCharge(int amount)
    {
        charge = charge + amount;

        if (charge >= 100)
        {
            charge = 100;
        }

        chargeUI.transform.localScale = new Vector3(charge * uiScale, charge * uiScale, charge * uiScale);
    }

    public void LoseCharge(int amount)
    {
        charge = charge + amount;

        if (charge <= 0)
        {
            charge = 0;
        }

        chargeUI.transform.localScale = new Vector3(charge * uiScale, charge * uiScale, charge * uiScale);
    }

    

    public void playerShoot()
    {
        GameObject newShot = Instantiate(myShot, this.transform.position, this.transform.rotation);
    }

}
