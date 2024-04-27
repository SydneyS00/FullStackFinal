using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using SimpleJSON; 

public class Items : MonoBehaviour
{
    public ButtonManager planetManager; 

    Action<string> _createInfoCallback;


    void Start()
    {
        _createInfoCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateItemsRoutine(jsonArrayString)); 
        };

        CreateItems(); 
        
    }
    public void CreateItems()
    {
        string userID = Main.instance.userInfo.userID; 

        StartCoroutine(Main.instance.web.GetItemsIDs(userID, _createInfoCallback)); 
    }

    IEnumerator CreateItemsRoutine(string jsonArrayString)
    {
        //Parsing array as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        Debug.Log("CreateItemRoutine Called");

        for (int i = 0; i < jsonArray.Count; i++)
        {
            //Create local variables 
            bool isDone = false;
            string planetID = jsonArray[i].AsObject["planetID"];

            Debug.Log(planetID);

            JSONObject planetInfoJson = new JSONObject();

            //Create a callback to get info from web class
            Action<string> getPlanetInfoCallback = (planetInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(planetInfo) as JSONArray;
                planetInfoJson = tempArray[0].AsObject;
            };

            StartCoroutine(Main.instance.web.GetItems(planetID, getPlanetInfoCallback));

            //Wait until callback is called from the WEB
            yield return new WaitUntil(() => isDone == true);


            //Testing site - be careful 



            //Instantiate our prefab
            GameObject planetInfo = Instantiate(Resources.Load("Prefabs/InfoScreen") as GameObject);
            planetInfo.name = planetInfoJson["name"] + "InfoScreen";
            planetInfo.transform.SetParent(this.transform);
            planetInfo.transform.localScale = Vector3.one;
            planetInfo.transform.localPosition = Vector3.zero;

            //Fill the information 
            planetInfo.transform.Find("planetName").GetComponent<TextMeshProUGUI>().text = planetInfoJson["name"];
            planetInfo.transform.Find("sunDist").GetComponent<TextMeshProUGUI>().text = planetInfoJson["sundistance"];
            planetInfo.transform.Find("earthDist").GetComponent<TextMeshProUGUI>().text = planetInfoJson["earthdistance"];
            planetInfo.transform.Find("temperature").GetComponent<TextMeshProUGUI>().text = planetInfoJson["temperature"];
            planetInfo.transform.Find("atmosphere").GetComponent<TextMeshProUGUI>().text = planetInfoJson["atmosphere"];
            planetInfo.transform.Find("moons").GetComponent<TextMeshProUGUI>().text = planetInfoJson["moons"];
            planetInfo.transform.Find("solarday").GetComponent<TextMeshProUGUI>().text = planetInfoJson["solarday"];
            planetInfo.transform.Find("solaryear").GetComponent<TextMeshProUGUI>().text = planetInfoJson["solaryear"];
            planetInfo.transform.Find("coolFact").GetComponent<TextMeshProUGUI>().text = planetInfoJson["coolfact"];

            planetInfo.SetActive(false);
            planetManager.CheckNames(planetInfo);
        } 


        yield return null; 
    }
}
