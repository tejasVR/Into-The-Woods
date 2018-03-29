using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class TalkieManager : MonoBehaviour {

    public VoiceManager voiceManager;

    public AudioSource audio;

    //[SerializeField]

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    //public GameObject cube;

    //private string[] response;

    //private KeywordRecognizer recognizer;

	// Use this for initialization
	void Start () {
        //keywords = new string[1];
        //keywords[0] = "Yes";
        //recognizer = new KeywordRecognizer(keywords);
        //recognizer.OnPhraseRecognized += OnPhraseRecognized;
        //recognizer.Start();

	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        //if (device.GetPress(SteamVR_Controller.ButtonMask.Grip)) {
           // voiceManager.OnPhraseRecognized(response);
        //}

	}

    /*private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        //if (args.text == keywords[0])
        {
            print("You Said 'YES'!");

        //    Instantiate(cube, transform.position, Quaternion.identity);

        }
    }*/

    public void PlayClip(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
}
