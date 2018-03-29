using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditText : MonoBehaviour {

    private TextMeshPro creditText;
    public string productionText;
    public string presentsText;

    public float startTimer;
    public float duration;
    public float fadeSpeed;
    public bool isFading;
   
    private bool productionTextDone;
    private bool presentsTextDone;

    public VisionManager visionManger;

    public float alpha;

	// Use this for initialization
	void Start () {
        creditText = GetComponent<TextMeshPro>();
        alpha = -1;
        duration = 5;

        creditText.text = productionText;
	}
	
	// Update is called once per frame
	void Update () {

        if (!productionTextDone)
        {
            if (startTimer <= 0)
            {
                if (!isFading)
                {
                    alpha += Time.deltaTime * fadeSpeed;
                    if (alpha >= 1.5)
                    {
                        isFading = true;
                    }
                }
                else
                {
                    alpha -= Time.deltaTime * fadeSpeed;
                    if (alpha <= -.5f)
                    {
                        creditText.text = presentsText;
                        

                        //Time until next text
                        duration -= Time.deltaTime;
                        if (duration <= -.5f)
                        {
                            isFading = false;
                            alpha = -1;
                            productionTextDone = true;
                        }
                    }
                }
            }
            
          
        }

        if (!presentsTextDone && productionTextDone)
        {
            if (!isFading)
            {
                alpha += Time.deltaTime * fadeSpeed;
                if (alpha >= 1.5)
                {
                    isFading = true;
                }
            }
            else
            {
                alpha -= Time.deltaTime * fadeSpeed;
                if (alpha <= -.5f)
                {
                    alpha = -.5f;
                }
            }
        }

        creditText.alpha = alpha;

        startTimer -= Time.deltaTime;
       
    }
        
}
