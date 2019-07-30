using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestDeviceLogic : MonoBehaviour
{

    public GameObject[] Shields;
    public int currentShield;
    public int charge;
    public GameObject myShot;
    public Text chargeText;
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
        currentShield = 1;

        chargeUI.transform.localScale = new Vector3(charge * uiScale, charge * uiScale, charge * uiScale);
    }

    
    void Update()
    {
        chargeUI = this.gameObject.transform.GetChild(0);

        hasController = CheckForController(hasController);

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            currentShield += 1;
        }

        if (Input.GetKeyDown(KeyCode.W)) //Red Shield Activation
        {
            //if (onTriggerDown != null)
            //{    
            //    Shields[0].SetActive(true);
            //    Shields[1].SetActive(false);
            //    Shields[2].SetActive(false);
            //    Shields[3].SetActive(false);
            //}

            //if (Input.GetKeyDown(KeyCode.A))   //Green Shield Activation
            //{
            //    Shields[0].SetActive(false);
            //    Shields[1].SetActive(true);
            //    Shields[2].SetActive(false);
            //    Shields[3].SetActive(false);
            //}

            //if (Input.GetKeyDown(KeyCode.S)) //Yellow Shield Activation
            //{
            //    Shields[0].SetActive(false);
            //    Shields[1].SetActive(false);
            //    Shields[2].SetActive(true);
            //    Shields[3].SetActive(false);
            //}

            //if (Input.GetKeyDown(KeyCode.D)) //Blue Shield Activation
            //{
            //    Shields[0].SetActive(false);
            //    Shields[1].SetActive(false);
            //    Shields[2].SetActive(false);
            //    Shields[3].SetActive(true);
            //}
        }

        //Debug.Log("update is working");

        Vector2 primaryTouchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        

        
        switch (currentShield)
        {
            case 1:
                Debug.Log("Top");
                chargeText.text = "TOP";
                Shields[0].SetActive(true);
                Shields[1].SetActive(false);
                Shields[2].SetActive(false);
                Shields[3].SetActive(false);
                break;
            case 2:
                Debug.Log("Bottom");
                chargeText.text = "BOTTOM";
                Shields[0].SetActive(false);
                Shields[1].SetActive(true);
                Shields[2].SetActive(false);
                Shields[3].SetActive(false);
                break;
            case 3:
                Debug.Log("Right");
                chargeText.text = "RIGHT";
                Shields[0].SetActive(false);
                Shields[1].SetActive(false);
                Shields[2].SetActive(true);
                Shields[3].SetActive(false);
                break;
            case 4:
                Debug.Log("Left");
                chargeText.text = "LEFT";
                Shields[0].SetActive(false);
                Shields[1].SetActive(false);
                Shields[2].SetActive(false);
                Shields[3].SetActive(true);
                break;
            default:
                currentShield = 1;
                break;
        }

        Debug.Log(primaryTouchpad);

        chargeText.text = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).ToString();

        if (charge == 100)
        {
            
            playerShoot();
            charge = 0;

            chargeUI.transform.localScale = new Vector3(charge * uiScale, charge * uiScale, charge * uiScale);
        }

        chargeText.text = charge.ToString();
        
       
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
