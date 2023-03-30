using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighGlucoseManager : MonoBehaviour
{
    public Text Notice, High, Normal, resultShow;
    public GameObject Result, WrongInput, MissingInfo, CallText;
    public enum Signs { greater, lower, equal, eqgreater, eqlower };

    void Start()
    {
        Result.SetActive(false);
        WrongInput.SetActive(false);
        MissingInfo.SetActive(false);
        CallText.SetActive(false);
    }

    public bool VerificateEquationMgOrMmol(float num, float defaultnum,  Signs sign)
    {
        if(PlayerPrefs.GetInt("glucoseLevelUnit", 1) == 0)
        {
            defaultnum /= 18.018f;
        }

        if (sign == Signs.eqgreater)
            return num >= defaultnum;
        else if (sign == Signs.eqlower)
            return num <= defaultnum;
        else if (sign == Signs.equal)
            return num == defaultnum;
        else if (sign == Signs.greater)
            return num > defaultnum;
        else if (sign == Signs.lower)
            return num < defaultnum;

        return false;
    }

    void LanguageFinder()
    {
        if(PlayerPrefs.GetString("language", "english") == "english")
        {
            if (PlayerPrefs.GetInt("glucoseLevelUnit", 1) == 1)
                Notice.text = "This is a aproximation based on the formula:\n1 unit to lower " + PlayerPrefs.GetFloat("correction") + " mg / dl";
            else
                Notice.text = "This is a aproximation based on the formula:\n1 unit to lower " + PlayerPrefs.GetFloat("correction") + " mmol/L";
        }
        else if(PlayerPrefs.GetString("language", "english") == "french")
        {
            if (PlayerPrefs.GetInt("glucoseLevelUnit", 1) == 1)
                Notice.text = "C'est une approximation basée sur la formule:\n1 l'unité s'abaisse " + PlayerPrefs.GetFloat("correction") + "\nmg / dl";
            else
                Notice.text = "C'est une approximation basée sur la formule:\n1 l'unité s'abaisse " + PlayerPrefs.GetFloat("correction") + "\nmmol / L";
        }
        else if(PlayerPrefs.GetString("language", "english") == "romana")
        {
            if(PlayerPrefs.GetInt("glucoseLevelUnit", 1) == 1)
                Notice.text = "Aceasta este o aproximare cu formula:\n1 UI scade" + PlayerPrefs.GetFloat("correction") + "\nmg / dl";
            else
                Notice.text = "Aceasta este o aproximare cu formula:\n1 UI scade" + PlayerPrefs.GetFloat("correction") + "\nmmol / L";
        }
        else if(PlayerPrefs.GetString("language", "english") == "deutsch")
        {
            if (PlayerPrefs.GetInt("glucoseLevelUnit", 1) == 1)
                Notice.text = "Diese ist eine Annäherung mit der Formel:\n1 UI sinkt" + PlayerPrefs.GetFloat("correction") + "\nmg / dl";
            else
                Notice.text = "Diese ist eine Annäherung mit der Formel:\n1 UI sinkt" + PlayerPrefs.GetFloat("correction") + "\nmmol / L";

        }
    }

    public void OnClickCalculate()
    {
        LanguageFinder();

        if (High.text != "" && Normal.text != "")
        {
            Debug.Log("Calculating");
            float h = float.Parse(High.text);
            float n = float.Parse(Normal.text);
            float r;
            if(h >= n && n >= 0 && VerificateEquationMgOrMmol(h, 400, Signs.eqlower))
            {
                CallText.SetActive(false);
                WrongInput.SetActive(false);
                MissingInfo.SetActive(false);
                if (PlayerPrefs.GetInt("glucoseLevelUnit", 1) == 1)
                    if(h < 300)
                        r = (h - n) / PlayerPrefs.GetFloat("correction", 30);
                    else
                        r = (h - n) / PlayerPrefs.GetFloat("correction", 30) * 1.5f;
                else
                    if(h < 17)
                        r = (h - n) / PlayerPrefs.GetFloat("correction", 1.7f);
                    else
                        r = (h - n) / PlayerPrefs.GetFloat("correction", 1.7f) * 1.5f;

                //aproximations
                if ((r - (int)(r)) < 0.25)
                    r = (int)(r);
                else if (((r - (int)(r)) >= 0.25 && (r - (int)(r)) <= 0.5) || ((r - (int)(r)) <= 0.75 && (r - (int)(r)) >= 0.5))
                    r = (int)(r) + 0.5f;
                else
                    r = (int)(r) + 1;

                resultShow.text = "" + r + "UI";
                Result.SetActive(true);
            }
            else if(n >= 0 && VerificateEquationMgOrMmol(h, 400, Signs.greater))
            {
                WrongInput.SetActive(false);
                Result.SetActive(false);
                MissingInfo.SetActive(false);
                Debug.Log("Call The Doctor");
                CallText.SetActive(true);
            }
            else
            {
                CallText.SetActive(false);
                Result.SetActive(false);
                MissingInfo.SetActive(false);
                Debug.Log("Wrong Input");
                WrongInput.SetActive(true);
            }
        }
        else
        {
            WrongInput.SetActive(false);
            CallText.SetActive(false);
            Result.SetActive(false);
            Debug.Log("Missing Info");
            MissingInfo.SetActive(true);
        }
    }
}
