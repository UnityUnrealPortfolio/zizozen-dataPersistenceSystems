using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserDisplay : MonoBehaviour
{
    public TMP_Text userNameTxt;
    public TMP_Text userScoreTxt;

    public void SetUpUserDisplay(string nameTxt, string scoreTxt)
    {
        userNameTxt.text = nameTxt;
        userScoreTxt.text = scoreTxt;
    }
}
