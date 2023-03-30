using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatioRememberer : MonoBehaviour
{
    public Text bInput, lInput, dInput, wInput, mg_dl, correction;
    public Text bPlace, lPlace, dPlace, wPlace;
    public GameObject missingInfo;
    public Button Cancel;
    public GameObject Main, Ratio;
    public LanguageManager languageManager;
    
    void Start()
    {
        languageManager.OnStart();
        if (0 == PlayerPrefs.GetInt("firstEnter", 0))
        {
            Cancel.interactable = false;
            wPlace.text = PlayerPrefs.GetString("units", "(units)");
            bPlace.text = PlayerPrefs.GetString("units", "(units)");
            lPlace.text = PlayerPrefs.GetString("units", "(units)");
            dPlace.text = PlayerPrefs.GetString("units", "(units)");
        }
        else
        {
            Cancel.interactable = true;
            Ratio.SetActive(false);
            Main.SetActive(true);
            wPlace.text = "" + PlayerPrefs.GetInt("wRatio");
            bPlace.text = "" + PlayerPrefs.GetFloat("bRatio");
            lPlace.text = "" + PlayerPrefs.GetFloat("lRatio");
            dPlace.text = "" + PlayerPrefs.GetFloat("dRatio");
        }
    }

    public void OnConfirmEnter()
    {
        if (mg_dl.enabled)
        {
            PlayerPrefs.SetInt("glucoseLevelUnit", 1);
            Debug.Log("mg/dl");
        }
        else
        {
            PlayerPrefs.SetInt("glucoseLevelUnit", 0);
            Debug.Log("mmol/L");
        }
        if ((wInput.text != "" || bInput.text != "" || lInput.text != "" || dInput.text != "" || correction.text != "") && (PlayerPrefs.GetInt("firstEnter", 0) == 1))
        {
            if (wInput.text != "")
            {
                PlayerPrefs.SetInt("wRatio", int.Parse(wInput.text));
            }

            if (bInput.text != "")
            {
                PlayerPrefs.SetFloat("bRatio", float.Parse(bInput.text));
            }

            if (lInput.text != "")
            {
                PlayerPrefs.SetFloat("lRatio", float.Parse(lInput.text));
            }

            if (dInput.text != "")
            {
                PlayerPrefs.SetFloat("dRatio", float.Parse(dInput.text));
            }

            if(correction.text != "")
            {
                PlayerPrefs.SetFloat("correction", float.Parse(correction.text));
            }

            string s = "Weight: " + PlayerPrefs.GetInt("wRatio") + ". B: " + PlayerPrefs.GetFloat("bRatio") + ". L: " + PlayerPrefs.GetFloat("lRatio") + ". D: " + PlayerPrefs.GetFloat("dRatio") + ". Correction: " + PlayerPrefs.GetFloat("correction");
            Debug.Log(s);
            Cancel.interactable = true;
            Main.SetActive(true);
            Ratio.SetActive(!true);
            missingInfo.SetActive(!true); 
        }
        else if ((wInput.text != "" && bInput.text != "" && lInput.text != "" && dInput.text != "") && (PlayerPrefs.GetInt("firstEnter", 0) == 0))
        {

                PlayerPrefs.SetInt("wRatio", int.Parse(wInput.text));

                PlayerPrefs.SetFloat("bRatio", float.Parse(bInput.text));

                PlayerPrefs.SetFloat("lRatio", float.Parse(lInput.text));

                PlayerPrefs.SetFloat("dRatio", float.Parse(dInput.text));

                PlayerPrefs.SetFloat("correction", float.Parse(correction.text));

            string s = "Weight: " + PlayerPrefs.GetInt("wRatio") + ". B: " + PlayerPrefs.GetFloat("bRatio") + ". L: " + PlayerPrefs.GetFloat("lRatio") + ". D: " + PlayerPrefs.GetFloat("dRatio");
            Debug.Log(s);
            PlayerPrefs.SetInt("firstEnter", 1);
            Cancel.interactable = true;
            Main.SetActive(true);
            Ratio.SetActive(!true);
            missingInfo.SetActive(!true);
        }
        else if(PlayerPrefs.GetInt("firstEnter", 0) == 0)
        {
            missingInfo.SetActive(true);
        }
    }
}
