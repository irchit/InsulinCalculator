using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseApp : MonoBehaviour
{
    public void OnClickCloseMe()
    {
        Debug.Log("Closing");
        Application.Quit();
    }
}
