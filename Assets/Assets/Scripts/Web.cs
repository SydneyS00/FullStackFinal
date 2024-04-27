using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON; 

public class Web : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine(GetUsers());
        //StartCoroutine(Login("testUser", "123456"));  
    }


    //public void ShowUserItems()
    //{
        //StartCoroutine(GetItemsIDs(Main.instance.userInfo.userID)); 
    //}


    public IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/SpaceExplorer/GetUsers.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show the results in text
                Debug.Log(www.downloadHandler.text);

                //Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password); 

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/SpaceExplorer/Login.php", form))
        {
            yield return www.SendWebRequest(); 

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error); 
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                Main.instance.userInfo.SetInfo(username, password);
                Main.instance.userInfo.SetID(www.downloadHandler.text);


                if(www.downloadHandler.text.Contains("Wrong credentials, try again...") || www.downloadHandler.text.Contains("Credentials do not exist..."))
                {
                    Debug.Log("Try again..."); 
                }
                else
                {
                    //logged in correctly
                    Main.instance.MainScreen.SetActive(true);
                    Main.instance.LoginScreen.SetActive(false);
                    //Main.instance.InfoScreen.SetActive(true); 
                }
               
            }
        }
    }

    public IEnumerator GetItemsIDs(string userID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID); 

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/SpaceExplorer/GetItemsIDs.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show the results in text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                //call callback function to pass results
                callback(jsonArray); 
            }
        }
    }

    public IEnumerator GetItems(string planetID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("planetID", planetID);

        //Testing some stuff praying to our lord and savior Brackeys and all other programming gods as I write this 


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/SpaceExplorer/GetItems.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show the results in text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                //Testing something help guide me to the light Jason Weiman 
                JSONNode jsonNode = JSON.Parse(jsonArray);
                string planetName = jsonNode[0]["name"]; 


                //call callback function to pass results
                callback(jsonArray);
            }
        }
    }
}
