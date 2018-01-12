using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public Logic logic;
    public enum ActiveColor {Red, Green, Blue, White, Black, Error};

    private ActiveColor active = ActiveColor.Red;

    public Camera cam;

    public Text txtRed;
    public Text txtGreen;
    public Text txtBlue;

    public Button btnLeft;
    public Button btnMid;
    public Button btnRight;

    public Button btnShop;

    public Button btnAfkRed;
    public Button btnAfkGreen;
    public Button btnAfkBlue;

    //Todo
    public int amount = 1;
    public int modifier = 1;
    public int cost = 10;

    public int afkAmountRed = 0;
    public int afkAmountBlue = 0;
    public int afkAmountGreen = 0;

    public int afkCostRed = 10;
    public int afkCostGreen = 10;
    public int afkCostBlue = 10;

    private float f_tmp= 0f;

    // Use this for initialization
    void Start () {
       btnLeft.onClick.AddListener(ChangeCurrentActiveLeft);
       btnMid.onClick.AddListener(IncreaseButton);
       btnRight.onClick.AddListener(ChangeCurrentActiveRight);
       btnShop.onClick.AddListener(IncreaseAmountModifier);

       btnAfkRed.onClick.AddListener(IncreaseAfkAmountRed);
       btnAfkGreen.onClick.AddListener(IncreaseAfkAmountGreen);
       btnAfkBlue.onClick.AddListener(IncreaseAfkAmountBlue);
    }
	
	// Update is called once per frame
	void Update () {
        f_tmp += Time.deltaTime;
        if(f_tmp > 1f)
        {
            f_tmp = 0;
            logic.resRed += afkAmountRed;
            logic.resGreen += afkAmountGreen;
            logic.resBlue += afkAmountBlue;

            UpdateResText();
        }
        
	}
    
    void ChangeCurrentActiveLeft()
    {
        switch (active)
        {
            case Controller.ActiveColor.Red:
                active = ActiveColor.Blue;
                cam.backgroundColor = Color.blue;
                btnLeft.image.color = Color.green;
                btnRight.image.color = Color.red;
                break;
            case Controller.ActiveColor.Green:
                active = ActiveColor.Red;
                cam.backgroundColor = Color.red;
                btnLeft.image.color = Color.blue;
                btnRight.image.color = Color.green;
                break;
            case Controller.ActiveColor.Blue:
                active = ActiveColor.Green;
                cam.backgroundColor = Color.green;
                btnLeft.image.color = Color.red;
                btnRight.image.color = Color.blue;
                break;
            default: break;
        }

        
    }

    void ChangeCurrentActiveRight()
    {
        switch (active)
        {
            case Controller.ActiveColor.Red:
                active = ActiveColor.Green;
                cam.backgroundColor = Color.green;
                btnLeft.image.color = Color.red;
                btnRight.image.color = Color.blue;
                break;
            case Controller.ActiveColor.Green:
                active = ActiveColor.Blue;
                cam.backgroundColor = Color.blue;
                btnLeft.image.color = Color.green;
                btnRight.image.color = Color.red;
                break;
            case Controller.ActiveColor.Blue:
                active = ActiveColor.Red;
                cam.backgroundColor = Color.red;
                btnLeft.image.color = Color.blue;
                btnRight.image.color = Color.green;
                break;
            default: break;
        }
    }

    void IncreaseButton()
    {
        logic.IncreaseActive(amount * modifier, active);
        UpdateResText();
    }

    void IncreaseAmountModifier()
    {
        if (logic.DecreaseActive(amount * cost, active) == 1)
        {
            modifier *= 2;
            cost *= 3;

            btnShop.GetComponentsInChildren<Text>()[0].text = (modifier * 2).ToString() + "x for only: " + cost.ToString();
            btnMid.GetComponentsInChildren<Text>()[0].text = "+"  +(modifier*amount).ToString();
            UpdateResText();
        }     
    }

    void IncreaseAfkAmountRed()
    {
        if (logic.DecreaseActive(afkCostRed, ActiveColor.Red) == 1)
        {
            afkAmountRed += amount;
            afkCostRed *= 2;

            btnAfkRed.GetComponentsInChildren<Text>()[0].text = (afkAmountRed + amount).ToString() + "/s: " + afkCostRed.ToString();
            UpdateResText();
        }
    }

    void IncreaseAfkAmountGreen()
    {
        if (logic.DecreaseActive(afkCostGreen, ActiveColor.Green) == 1)
        {
            afkAmountGreen += amount;
            afkCostGreen *= 2;

            btnAfkGreen.GetComponentsInChildren<Text>()[0].text = (afkAmountGreen + amount).ToString() + "/s: " + afkCostGreen.ToString();
            UpdateResText();
        }
    }

    void IncreaseAfkAmountBlue()
    {
        if (logic.DecreaseActive(afkCostBlue, ActiveColor.Blue) == 1)
        {
            afkAmountBlue += amount;
            afkCostBlue *= 2;

            btnAfkBlue.GetComponentsInChildren<Text>()[0].text = (afkAmountBlue + amount).ToString() + "/s: " + afkCostBlue.ToString();
            UpdateResText();
        }
    }

    private void UpdateResText()
    {
        txtRed.text = logic.resRed.ToString();
        txtGreen.text = logic.resGreen.ToString();
        txtBlue.text = logic.resBlue.ToString();
    }
}
