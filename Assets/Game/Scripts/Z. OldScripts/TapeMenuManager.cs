using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TapeMenuManager : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    public List<Tapes> tapes = new List<Tapes>(); //creates a list of menu buttons to access

    private Vector2 touchpad;

    public GameObject menuCanvas;
    public float angleFromCenter; //gets the angle of the finger on the touchpad in relation to the center of the touchpad (0,0)

    //public List<bool> hasTapes = new List<bool>();

    public AudioSource audio;
    public AudioClip[] clips;

    //private Vector2 distanceFromTouchpad = new Vector2(0.5f, 1.0f);
    //private Vector2 centerCircle = new Vector2(0.0f, 0.0f);
    //private Vector2 

    //public int menuItems; //number of menu items
    //public int 
    public int currentMenuItem; //current menu item
    private int oldMenuItem; //old menu item



	// Use this for initialization
	void Start () {
        menuCanvas.SetActive(false);

        //menuItems = buttons.Count; //sets the number of menu items to the number of buttons in the list
        //hasTapes.Count = buttons.Count;

        foreach (Tapes tape in tapes)
        {
            tape.sceneImage.color = tape.unavailableColor;
        }

        for (int i = 0; i <= 7; i++)
        {
            if (tapes[i].hasTape)
            {
                tapes[i].sceneImage.color = tapes[i].normalColor;
            }
            else
            {
                tapes[i].sceneImage.color = tapes[i].unavailableColor;
            }
        }

        currentMenuItem = 0;
        oldMenuItem = 0;
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        
        

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Updates to see what button
            GetCurrentMenuItem();
            //Debug.Log("touching touchpad");
            //touchpad.x = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            //touchpad.y = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y;
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            MenuReset();
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            ButtonAction();
        }


	}

    private void ShowMenu()
    {

    }

    public void GetCurrentMenuItem()
    {
        menuCanvas.SetActive(true);

        //Get touchpad position
        touchpad.x = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
        touchpad.y = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y;

        Vector2 fromVector2 = new Vector2(0,1);
        Vector2 toVector2 = touchpad;

        angleFromCenter = Vector2.Angle(fromVector2, toVector2);
        Vector3 cross = Vector3.Cross(fromVector2, toVector2);
        if (cross.z > 0)
        {
            angleFromCenter = 360 - angleFromCenter;
        }


        //map angle from center to specific buttons;
        if (0 < angleFromCenter && angleFromCenter <= 45)
        {
            currentMenuItem = 0; //Tape 1
        } else if (45 < angleFromCenter && angleFromCenter <= 90)
        {
            currentMenuItem = 1; //Tape 2
        } else if (90 < angleFromCenter && angleFromCenter <= 135)
        {
            currentMenuItem = 2; //Tape 3
        } else if (135 < angleFromCenter && angleFromCenter <=180)
        {
            currentMenuItem = 3; //Tape 4
        } else if (180 < angleFromCenter && angleFromCenter <= 225)
        {
            currentMenuItem = 4; //Tape 5
        } else if (225 < angleFromCenter && angleFromCenter <= 270)
        {
            currentMenuItem = 5; //Tape 6
        } else if (270 < angleFromCenter && angleFromCenter <= 315)
        {
            currentMenuItem = 6; //Tape 7
        } else if (315 < angleFromCenter && angleFromCenter <= 360)
        {
            currentMenuItem = 7; //Tape 8
        } else if (360 < angleFromCenter && angleFromCenter <= 0)
        {
            currentMenuItem = 8; //Tape 9
        }

        //To tell when to light up or not

        //If we have the tape for the selected menu item
        if (tapes[currentMenuItem].hasTape)
        {
            if (currentMenuItem != oldMenuItem)
            {
                tapes[oldMenuItem].sceneImage.color = tapes[oldMenuItem].normalColor;
                oldMenuItem = currentMenuItem;
                tapes[currentMenuItem].sceneImage.color = tapes[currentMenuItem].highlightColor;
            }
        }         
    }

    public void ButtonAction()
    {
        /*buttons[currentMenuItem].sceneImage.color = buttons[currentMenuItem].pressedColor;
        if (currentMenuItem == 0)
        {
            print("You have pressed the first button");
        }*/
        audio.Stop();
        audio.PlayOneShot(tapes[currentMenuItem].recording);
    }

    private void MenuReset()
    {
        menuCanvas.SetActive(false);

        //Reset colors for the buttons
        foreach (Tapes tape in tapes)
        {
            tape.sceneImage.color = tape.normalColor;
        }
        for (int i = 0; i <= 7; i++)
        {
            if (tapes[i].hasTape)
            {
                tapes[i].sceneImage.color = tapes[i].normalColor;
            } else
            {
                tapes[i].sceneImage.color = tapes[i].unavailableColor;
            }
        }

        currentMenuItem = 0;
        oldMenuItem = 0;
    }

}


[System.Serializable]
public class Tapes
{
    public string name;
    public bool hasTape;
    public AudioClip recording;
    public Image sceneImage;
    public Color normalColor = Color.white;
    public Color unavailableColor = Color.black;
    public Color highlightColor = Color.grey;
    public Color pressedColor = Color.yellow;

}