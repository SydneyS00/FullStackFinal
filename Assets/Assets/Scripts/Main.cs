using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public static Main instance; 
    public Web web;
    public UserInfo userInfo;
    public Login login;

    public Items items; 

    public GameObject LoginScreen; 
    public GameObject MainScreen;
    public GameObject InfoScreen; 
    

    void Start()
    {
        instance = this; 
        web = GetComponent<Web>();
        userInfo = GetComponent<UserInfo>();
    }


}
