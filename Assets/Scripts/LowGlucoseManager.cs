using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowGlucoseManager : MonoBehaviour
{
    public Text High, Normal, resultShow;
    public GameObject Result, WrongInput, MissingInfo, CallText;
    public enum Signs { greater, lower, equal, eqgreater, eqlower };

    void Start()
    {
        Result.SetActive(false);
        WrongInput.SetActive(false);
        MissingInfo.SetActive(false);
        CallText.SetActive(false);
    }

    private bool VerificateEquationMgOrMmol(float num, float defaultnum, Signs sign)
    {
        if (PlayerPrefs.GetInt("glucoseLevelUnit", 1) == 0)
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

    public void OnClickCalculate()
    {
        if (High.text != "" && Normal.text != "")
        {
            Debug.Log("Calculating");
            float l = float.Parse(High.text);
            float n = float.Parse(Normal.text);
            float r;
            if (l <= n && VerificateEquationMgOrMmol(l, 40, Signs.eqgreater))
            {
                CallText.SetActive(false);
                WrongInput.SetActive(false);
                MissingInfo.SetActive(false);
                r = n - l;

                if(PlayerPrefs.GetInt("glucoseLevelUnit", 1) == 0)
                {
                    r *= 18.018f;
                    Debug.Log(r);
                }
                float weight = PlayerPrefs.GetInt("wRatio");

                if(PlayerPrefs.GetInt("massUnit", 1) == 0)
                {
                    weight *= 0.454f;
                }

                //calculations
                if(weight <= 28)
                {
                    r /= 6;
                }
                else if(weight <= 47)
                {
                    r /= 5;
                }
                else if(weight <= 76)
                {
                    r /= 4;
                    Debug.Log(r);
                }
                else if(weight <= 105)
                {
                    r /= 3;
                }
                else
                {
                    r /= 2;
                }
                if(PlayerPrefs.GetString("language", "english") == "english")
                    resultShow.text = "You should eat:\n" + (int)r + " Carbs";
                else if(PlayerPrefs.GetString("language", "english") == "french")
                    resultShow.text = "Vous devriez manger:\n" + (int)r + " Glucides";
                else if (PlayerPrefs.GetString("language", "english") == "romana")
                    resultShow.text = "Ar trebui să mâcati:\n" + (int)r + " HC";
                else if (PlayerPrefs.GetString("language", "english") == "deutsch")
                    resultShow.text = "Sie sollten :\n" + (int)r + " HC essen.";

                Result.SetActive(true);
            }
            else if (VerificateEquationMgOrMmol(l, 40, Signs.lower))
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
