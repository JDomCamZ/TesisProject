using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEditor;
using UnityEngine.Events;

public class SlideShow : MonoBehaviour
{
    public Sprite[] imageArray;

    private int currentImage;

    float deltaTime = 0.0f;

    private InputData _inputData;

    public float timer1 = 45.0f;
    public float timer1Remaining = 45.0f;
    public bool timer1IsRunning = true;
    public string timer1Text;

    //UnityEvent OnActive;

    private bool firstFrame = true;
    private bool firstFrame2 = true;
    // Start is called before the first frame update


    void Start()
    {
        _inputData = GetComponent<InputData>();
        currentImage = 0;
        timer1Remaining = timer1;
    }

    // Update is called once per frame
    void Update()
    {

        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool TButton))
        {
            Debug.Log("triggerValue: " + TButton.ToString());

            if (TButton && firstFrame)
            {
                //OnActive.Invoke();
                firstFrame = false;

                currentImage--;
                if (currentImage < 0)
                    currentImage = imageArray.Length-1;

                this.gameObject.GetComponent<SpriteRenderer>().sprite = imageArray[currentImage];

                timer1Remaining = timer1;
            }


            else if (!TButton)
            {
                firstFrame = true;
            }
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool TButton2))
        {
            Debug.Log("triggerValue: " + TButton.ToString());

            if (TButton2 && firstFrame2)
            {
                //OnActive.Invoke();
                firstFrame2 = false;

                currentImage++;
                if (currentImage >= imageArray.Length)
                    currentImage = 0;

                this.gameObject.GetComponent<SpriteRenderer>().sprite = imageArray[currentImage];

                timer1Remaining = timer1;
            }


            else if (!TButton2)
            {
                firstFrame2 = true;
            }
        }


        if (timer1Remaining > 0)
        {
            timer1Remaining -= Time.deltaTime;

        }

        else
        {
            Debug.Log("Time has run out!");


            currentImage++;

            if (currentImage >= imageArray.Length)
                currentImage = 0;

            this.gameObject.GetComponent<SpriteRenderer>().sprite = imageArray[currentImage];

            timer1Remaining = timer1;
        }

    }
}