using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] buttonPressed;
    public GameObject planetInfoPrefab;


    public void OnEnable()
    {
        Main.instance.InfoScreen.SetActive(true);

    }

    public void OnButtonClicked()
    {
        Debug.Log("We clicked a button!");

        Main.instance.InfoScreen.SetActive(true);

    }

    public void CheckNames(GameObject planetInfo)
    {
        TextMeshProUGUI planetInfoText = planetInfo.transform.Find("planetName").GetComponent<TextMeshProUGUI>();
        string planetPrefabName = planetInfoText.text;

        for (int i = 0; i < buttonPressed.Length; i++)
        {
            if (planetPrefabName == buttonPressed[i].name)
            {
                Debug.Log("PlanetInfo" + planetInfo + " button " + buttonPressed[i].name);


                buttonPressed[i].GetComponent<Button>().onClick.AddListener(() => planetInfo.SetActive(true));
            }
        }
    }

}


