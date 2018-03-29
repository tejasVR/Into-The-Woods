using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class VoiceManager : MonoBehaviour {

    [SerializeField]
    private string[] m_Keywords;

    //public SteamVR_TrackedObject trackedObj;
    //public SteamVR_Controller.Device device;

    public string playerResponse;
    //private DictationRecognizer dictationRecognizer;
    private KeywordRecognizer m_Recognizer;

    // Use this for initialization
    void Start()
    {
        m_Keywords = new string[1];
        m_Keywords[0] = "Yes";
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        //dictationRecognizer = new DictationRecognizer();
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();

     //   Debug.Log("initialized");
        //dictationRecognizer.Start();

        //dictationRecognizer.di

        //dictationRecognizer.DictationHypothesis += dictationRecognizer_DictationHypothesis; //tells us what the application is thing, what is has heard
        //dictationRecognizer.DictationResult += dictationRecognizer_DictationResult; //application is confident in what it has heard, and is giving text
        //dictationRecognizer.DictationComplete += dictationRecognizer_DictationComplete; //application recognizes it should sleep dictation function after completion

        //PlayerListen();
    }

    // Update is called once per frame
    void Update()
    {
     

    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        //playerRespose = args.text;

        if (args.text.Contains(m_Keywords[0]))
        {
            print("You said yes");

        }

        /*if (args.text == m_Keywords[0])
        {
            print("You said yes");
        } else
        {
            print("you said something else");
        }*/


    }

    /*private void dictationRecognizer_StartListening()
    {
        dictationRecognizer.Start();
    }
    //Here is the results of the string
    private void dictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        playerRespose = text;
    }

    private void dictationRecognizer_DictationHypothesis(string text)
    {
        //0playerRespose = text;
    }

    //
    private void dictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        dictationRecognizer.Stop();
    }


    */
    public void PlayerListen()
    {
        //dictationRecognizer.Start();
        /*if (args.text == keywords[0])
        {
            print("You Said 'YES'!");

            Instantiate(cube, transform.position, Quaternion.identity);

        }
        else
        {
            print("What was that?");
        }*/
    }

    public void PlayerStop()
    {
        //dictationRecognizer.Stop();
    }
}
