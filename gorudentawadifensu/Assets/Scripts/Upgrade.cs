using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public GameObject targettedSpawner;

    public GameObject ToUpObject;
    public Image ToUpUnit;
    public Text ToUpLevel;
    public Text ToUpName;
    public Text ToUpCost;
    public int Cost;


    public void upStart(GameObject unit)
    {
        ToUpObject = unit;
        ToUpUnit.sprite = unit.GetComponent<SpriteRenderer>().sprite;
        ToUpLevel.text = unit.GetComponent<Turret>().Level.ToString() + " / 10";
        ToUpName.text = unit.GetComponent<Turret>().nametag;
        Cost = unit.GetComponent<Turret>().Cost * unit.GetComponent<Turret>().Level;
        ToUpCost.text = Cost.ToString();
    }

    public void Upgradation()
    {
        if (GeneralVars.Money >= Cost && ToUpObject.GetComponent<Turret>().Level < 10)
        {
            GeneralVars.Money -= Cost;
            ToUpObject.GetComponent<Turret>().Level++;
            ToUpObject.GetComponent<Turret>().damage = ToUpObject.GetComponent<Turret>().damage + ToUpObject.GetComponent<Turret>().damage / 5;
            ToUpObject.GetComponent<Turret>().attackSpeed = ToUpObject.GetComponent<Turret>().attackSpeed * 0.9f;
            Time.timeScale = 1f;
            GeneralVars.OverlayIsActive = false;
            gameObject.SetActive(false);
        }
    }

    public void Continue()
    {
        Time.timeScale = 1f; 
        GeneralVars.OverlayIsActive = false;
        gameObject.SetActive(false);
    }
}
