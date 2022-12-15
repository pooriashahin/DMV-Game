using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_StatusBar : MonoBehaviour
{
    private Image statusImage;

    private float currentPercentage;
    private float maximumPercentage;

    public float statusBarChangeSpeed;

    private void Start() {
        statusImage = GetComponent<Image>();
        maximumPercentage = 1;
        currentPercentage = 1;
        if (statusImage == null) {
            print("IMAGE NOT CONNECTED");
        } else print("IMAGE CONNECTED!!!");
    }

    public void ChangeValue(float percentage) {
        maximumPercentage = percentage;
    }

    public void Update() {
        CalculateCurrentPercentage();
        SetImageValue();
    }

    private void CalculateCurrentPercentage() {
        currentPercentage += Mathf.Max((maximumPercentage - currentPercentage), 0.01f)* Time.deltaTime * statusBarChangeSpeed;
        if (Mathf.Abs(currentPercentage - maximumPercentage) < .01f)
            currentPercentage = maximumPercentage;
    }

    private void SetImageValue() {
        statusImage.fillAmount = currentPercentage;
    }
}
