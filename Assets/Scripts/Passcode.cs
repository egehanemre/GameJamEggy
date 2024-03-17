using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Passcode : MonoBehaviour
{
    string Code = "35736";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;

    }
    public void Enter()
    {
        if (Nr == Code)
        {
            Debug.Log("Working");
        }
    }
    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}