using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDialogueTriggers : MonoBehaviour {

    public SteamVR_TrackedObject leftObj;
    public SteamVR_TrackedObject rightObj;

    public SteamVR_Controller.Device leftController;
    public SteamVR_Controller.Device rightController;

    //public CampDialogue campDialogue;

    public bool leftGrip;
    public bool rightTouchpad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        leftController = SteamVR_Controller.Input((int)leftObj.index);
        rightController = SteamVR_Controller.Input((int)rightObj.index);

        if (leftController.GetPress(SteamVR_Controller.ButtonMask.Grip)) {
            leftGrip = true;
        }
        if (leftController.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
            leftGrip = false;
        }

        if (rightController.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            rightTouchpad = true;
        }
        if (rightController.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            rightTouchpad = false;
        }
    }
}
