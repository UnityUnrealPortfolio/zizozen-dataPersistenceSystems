using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    public string playerName;
    public int playerScoreAtSave;
   
   
    public GameData(string pName, int pScore)
    {
        playerName = pName;
        playerScoreAtSave = pScore;
    }
}
