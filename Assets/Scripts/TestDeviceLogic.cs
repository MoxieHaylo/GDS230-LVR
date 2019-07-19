using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestDeviceLogic : MonoBehaviour
{

    public GameObject[] Shields;
    public int charge;
    public GameObject myShot;
    public Text chargeText;

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
    }

    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDMounted -= PlayerLost;
    }

    // HACK
    public TextMesh textTest;


    void Update()
    {
        /*if (!inputActive)
        {
            textTest.text = "FAILED";
            return;
        }*/

        hasController = CheckForController(hasController);


        //if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp) ||            
        //    Input.GetKeyDown("w")) //Red Shield Activation
        //{
        //    if (onTriggerDown != null)
        //        onTriggerDown();

        //    Shields[0].SetActive(true);
        //    Shields[1].SetActive(false);
        //    Shields[2].SetActive(false);
        //    Shields[3].SetActive(false);
        //}
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown) || 
        //    Input.GetKeyDown("a")) //Green Shield Activation
        //{
        //    Shields[0].SetActive(false);
        //    Shields[1].SetActive(true);
        //    Shields[2].SetActive(false);
        //    Shields[3].SetActive(false);
        //}
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft) || 
        //    Input.GetKeyDown("s")) //Yellow Shield Activation
        //{
        //    Shields[0].SetActive(false);
        //    Shields[1].SetActive(false);
        //    Shields[2].SetActive(true);
        //    Shields[3].SetActive(false);
        //}
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight) || 
        //    Input.GetKeyDown("d")) //Blue Shield Activation
        //{
        //    Shields[0].SetActive(false);
        //    Shields[1].SetActive(false);
        //    Shields[2].SetActive(false);
        //    Shields[3].SetActive(true);
        //}

        Debug.Log("update is working");

        Vector2 primaryTouchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        if (primaryTouchpad.y > 0.2f)
        {
            Debug.Log("Top");
            textTest.text = "TOP";
            Shields[0].SetActive(true);
            Shields[1].SetActive(false);
            Shields[2].SetActive(false);
            Shields[3].SetActive(false);

        }
        else if (primaryTouchpad.y < -0.2f)
        {
            Debug.Log("Bottom");
            textTest.text = "BOTTOM";
            Shields[0].SetActive(false);
            Shields[1].SetActive(true);
            Shields[2].SetActive(false);
            Shields[3].SetActive(false);
        }
        else
        {
            if (primaryTouchpad.x > 0.2f)
            {
                Debug.Log("Right");
                textTest.text = "RIGHT";
                Shields[0].SetActive(false);
                Shields[1].SetActive(false);
                Shields[2].SetActive(true);
                Shields[3].SetActive(false);
            }
            else if (primaryTouchpad.x < -0.2f)
            {
                Debug.Log("Left");
                textTest.text = "LEFT";
                Shields[0].SetActive(false);
                Shields[1].SetActive(false);
                Shields[2].SetActive(false);
                Shields[3].SetActive(true);
            }
            else
            {
                textTest.text = OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.Active).ToString();
            }
        }

        Debug.Log(primaryTouchpad);

        //textTest.text = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).ToString();
        

        /*if (OVRInput.Get(OVRInput.Button.Any) || OVRInput.GetDown(OVRInput.Touch.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown) || OVRInput.GetDown(OVRInput.Touch.SecondaryThumbstick) || OVRInput.GetDown(OVRInput.Touch.SecondaryTouchpad))
        {
            Debug.Log("is working");
            Shields[0].SetActive(false);
            Shields[1].SetActive(false);
            Shields[2].SetActive(false);
            Shields[3].SetActive(false);
        }*/

        if (Input.GetKeyDown("x"))
        {
            if (charge == 100)
            {
                playerShoot();
                charge = 0;
            }
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

    private void PlayerFound()
    {
        inputActive = true;
    }

    private void PlayerLost()
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
    }

    public void LoseCharge(int amount)
    {
        charge = charge + amount;

        if (charge <= 0)
        {
            charge = 0;
        }
    }

    public void playerShoot()
    {
        GameObject newShot = Instantiate(myShot, this.transform.position, this.transform.rotation);
    }

}
