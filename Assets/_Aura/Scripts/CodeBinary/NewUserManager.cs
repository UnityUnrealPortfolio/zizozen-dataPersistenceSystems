using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Text;
using TMPro;

public class NewUserManager : MonoBehaviour
{
    public GameObject userDisplayPrefab;
    public Transform userDisplayParent;
    public TMP_InputField userNameInput;
   
    

    private void Awake()
    {
        DataManager.InitData();
    }
    public void HandleSetUpNewUser()
    {
        GameData newPlayer1 = new(userNameInput.text, 0);
     

        DataManager.CreateNewPlayer(newPlayer1);
   

    }
    public void HandleLoadAllUsers()
    {
        RefreshList();

        var allPlayers = DataManager.GetAllPlayers();

        //sort the list
        
        foreach (var player in allPlayers)
        {
            //instantiate a user display prefab
            var userDisplay = Instantiate(userDisplayPrefab);
            userDisplay.transform.SetParent(userDisplayParent, false);
            //fill it's data fields
            userDisplay.GetComponent<UserDisplay>().SetUpUserDisplay(player.playerName, player.playerScoreAtSave.ToString());
        }
    }
    public void RefreshList()
    {
       int users = userDisplayParent.transform.childCount;
        if(users > 0)
        {
            for(int i = 0; i < users; i++)
            {
                Destroy(userDisplayParent.GetChild(i).gameObject);
            }
        }
    }
    public void HandleExitGame()
    {
        Application.Quit();
    }
}
