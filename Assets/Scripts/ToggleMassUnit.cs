using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMassUnit : MonoBehaviour
{
    public Text Kg, Lbs;

    private void Start()
    {
        if (PlayerPrefs.GetInt("massUnit", 1) == 1)
        {
            Kg.enabled = true;
            Lbs.enabled = false;
        }
        else
        {
            Kg.enabled = !true;
            Lbs.enabled = !false;
        }
    }

    public void OnValueChange()
    {
        Kg.enabled = !Kg.enabled;
        Lbs.enabled = !Lbs.enabled;
        if (Kg.enabled)
        {
            PlayerPrefs.SetInt("massUnit", 1);
            Debug.Log("kg");
        }
        else
        {
            PlayerPrefs.SetInt("massUnit", 0);
            Debug.Log("lbs");
        }
    }
}
