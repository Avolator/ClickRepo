using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour{

    public int resRed = 0;
    public int resGreen = 0;
    public int resBlue = 0;

    
    public void IncreaseActive(int amount, Controller.ActiveColor active)
    {
        switch (active) {
            case Controller.ActiveColor.Red:
                resRed += amount; 
                break;
            case Controller.ActiveColor.Green:
                resGreen += amount;
                break;
            case Controller.ActiveColor.Blue:
                resBlue += amount;
                break;
            default: break;
        }
    }

    public int DecreaseActive(int amount, Controller.ActiveColor active)
    {
        int returnValue = 0;
        switch (active)
        {
            case Controller.ActiveColor.Red:
                if (resRed - amount >= 0)
                {
                    resRed -= amount;
                    returnValue = 1;
                }
                break;
            case Controller.ActiveColor.Green:
                if (resGreen - amount >= 0)
                {
                    resGreen -= amount;
                    returnValue = 1;
                }
                break;
            case Controller.ActiveColor.Blue:
                if (resBlue - amount >= 0)
                {
                    resBlue -= amount;
                    returnValue = 1;
                }
                break;
            default: break;
        }
        return returnValue;
    }
}
