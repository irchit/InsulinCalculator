using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGlucoseLvlUnit : MonoBehaviour
{
    public Text mg_dl, mmol_L, placeHolder;

    private void Start()
    {
        if (PlayerPrefs.GetInt("glucoseLevelUnit", 1) == 1)
        {
            mg_dl.enabled = true;
            mmol_L.enabled = false;
            placeHolder.text = "mg/dl";
        }
        else
        {
            placeHolder.text = "mmol/L";
            mg_dl.enabled = !true;
            mmol_L.enabled = !false;
        }
    }

    public void OnValueChange()
    {
        mg_dl.enabled = !mg_dl.enabled;
        mmol_L.enabled = !mmol_L.enabled;
        if (mg_dl.enabled)
        {
            placeHolder.text = "mg/dl";
            PlayerPrefs.SetInt("glucoseLevelUnit", 1);
            Debug.Log("mg/dl");
        }
        else
        {
            placeHolder.text = "mmol/L";
            PlayerPrefs.SetInt("glucoseLevelUnit", 0);
            Debug.Log("mmol/L");
        }
    }
}
