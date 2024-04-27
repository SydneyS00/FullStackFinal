using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{

    public string userID { get; private set; }
    string userName;
    string userPass; 
 

    public void SetInfo(string name, string password)
    {
        userName = name;
        userPass = password; 
    }

    public void SetID(string id)
    {
        userID = id; 
    }
}
