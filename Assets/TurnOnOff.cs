using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TurnOnOff : MonoBehaviour
{
    private InputData _inputData;

    public GameObject activateGameObject;
    private bool firstFrame = true;
    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.gripButton, out bool GButton))
        {
            Debug.Log("triggerValue: " + GButton.ToString());

            if (GButton && firstFrame)
            {
                //OnActive.Invoke();
                firstFrame = false;

                if (activateGameObject.activeSelf != true)
                {
                    activateGameObject.SetActive(true);
                }
                else
                {
                    activateGameObject.SetActive(false);
                }
            }


            else if (!GButton)
            {
                firstFrame = true;
            }
        }
    }
}
