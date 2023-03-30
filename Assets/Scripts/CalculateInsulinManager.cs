using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CalculateInsulinManager : MonoBehaviour
{
    public enum Signs { greater, lower, equal, eqgreater, eqlower };
    public Text Carbs, Glucose;
    public GameObject Result, ShouldntEat, MissingInfo;
    public Text ResultText;

    void Start()
    {
        Result.SetActive(false);
        ShouldntEat.SetActive(false);
        MissingInfo.SetActive(false);
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

    public void CalculateInsulin()
    {
        DateTime currentDate = DateTime.Now;
        Debug.Log(currentDate.Hour);
        int h = currentDate.Hour;
        if (Carbs.text != "" && Glucose.text != "")
        {
            float gl = int.Parse(Glucose.text);
            if(PlayerPrefs.GetInt("glucoseLevelUnit", 1) == 0)
            {
                gl *= 18.018f;
            }
            int carbs = int.Parse(Carbs.text);
            float insulinTaken, changer = 0;
            if (gl <= 150)
            {
                if(h < 12)
                {
                    Debug.Log("Breakfest");
                    if(gl >= 120)
                    {
                        changer ++;
                    }
                    else if(gl <= 70)
                    {
                        changer--;
                        if(gl <= 55)
                        {
                            changer --;
                        }
                        if(gl <= 45)
                        {
                            changer --;
                        }
                    }

                    float ratio = PlayerPrefs.GetFloat("bRatio");

                    insulinTaken = ratio * carbs / 10 + changer;
                    if (insulinTaken < 0) insulinTaken = 0;

                    ResultText.text = "" + insulinTaken + "UI";
                }
                else if(h >=12 && h < 17)
                {
                    Debug.Log("Lunch");
                    if (gl >= 120)
                    {
                        changer++;
                    }
                    else if (gl <= 70)
                    {
                        changer--;
                        if (gl <= 50)
                        {
                            changer--;
                        }
                        if (gl <= 45)
                        {
                            changer--;
                        }
                    }

                    float ratio = PlayerPrefs.GetFloat("lRatio");

                    insulinTaken = ratio * carbs / 10 + changer;
                    if (insulinTaken < 0) insulinTaken = 0;

                    ResultText.text = "" + insulinTaken + "UI";
                }
                else if(h >= 17)
                {
                    Debug.Log("Dinner");
                    if (gl >= 120)
                    {
                        changer++;
                    }
                    else if (gl <= 70)
                    {
                        changer--;
                        if (gl <= 50)
                        {
                            changer--;
                        }
                        if (gl <= 45)
                        {
                            changer--;
                        }
                    }

                    float ratio = PlayerPrefs.GetFloat("dRatio");

                    insulinTaken = ratio * carbs / 10 + changer;
                    if (insulinTaken < 0) insulinTaken = 0;

                    ResultText.text = "" + insulinTaken + "UI";
                }
                Result.SetActive(true);
                ShouldntEat.SetActive(false);
                MissingInfo.SetActive(!true);
            }
            else
            {
                Debug.Log("U shouldnt eat");
                Result.SetActive(false);
                ShouldntEat.SetActive(!false);
                MissingInfo.SetActive(!true);
            }
        }
        else
        {
            Debug.Log("MissingInfo");
            Result.SetActive(false);
            ShouldntEat.SetActive(false);
            MissingInfo.SetActive(true);
        }
    }
}
