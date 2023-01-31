using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusBehavior : MonoBehaviour
{
    public GameObject targettedSpawner;
    public GameObject[] Towers;
    public float[] TowerPrice;

    #region(craft des tours)
    public void CraftTower0()
    {
        if (TowerPrice[0] <= GeneralVars.Money)
        {
            GeneralVars.Money -= ((int)TowerPrice[0]);
            targettedSpawner.GetComponent<TurretSpawner>().istaken = true;
            GameObject newUnit = Instantiate(Towers[0], new Vector2(targettedSpawner.transform.position.x, targettedSpawner.transform.position.y), targettedSpawner.transform.rotation, targettedSpawner.transform);
            targettedSpawner.GetComponent<TurretSpawner>().UnitOn = newUnit;
            GeneralVars.OverlayIsActive = false;
            gameObject.SetActive(false);
        } else
        {
            Debug.Log("Not enough money");
        }
    }
    
    public void CraftTower1()
    {
        if (TowerPrice[1] <= GeneralVars.Money)
        {
            GeneralVars.Money -= ((int)TowerPrice[1]);
            targettedSpawner.GetComponent<TurretSpawner>().istaken = true;
            GameObject newUnit = Instantiate(Towers[1], new Vector2(targettedSpawner.transform.position.x, targettedSpawner.transform.position.y), targettedSpawner.transform.rotation, targettedSpawner.transform);
            targettedSpawner.GetComponent<TurretSpawner>().UnitOn = newUnit;
            GeneralVars.OverlayIsActive = false;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void CraftTower2()
    {
        if (TowerPrice[2] <= GeneralVars.Money)
        {
            GeneralVars.Money -= ((int)TowerPrice[2]);
            targettedSpawner.GetComponent<TurretSpawner>().istaken = true;
            GameObject newUnit = Instantiate(Towers[2], new Vector2(targettedSpawner.transform.position.x, targettedSpawner.transform.position.y), targettedSpawner.transform.rotation, targettedSpawner.transform);
            targettedSpawner.GetComponent<TurretSpawner>().UnitOn = newUnit;
            GeneralVars.OverlayIsActive = false;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void CraftTower3()
    {
        if (TowerPrice[3] <= GeneralVars.Money)
        {
            GeneralVars.Money -= ((int)TowerPrice[3]);
            targettedSpawner.GetComponent<TurretSpawner>().istaken = true;
            GameObject newUnit = Instantiate(Towers[3], new Vector2(targettedSpawner.transform.position.x, targettedSpawner.transform.position.y), targettedSpawner.transform.rotation, targettedSpawner.transform);
            targettedSpawner.GetComponent<TurretSpawner>().UnitOn = newUnit;
            GeneralVars.OverlayIsActive = false;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void CraftTower4()
    {
        if (TowerPrice[4] <= GeneralVars.Money)
        {
            GeneralVars.Money -= ((int)TowerPrice[4]);
            targettedSpawner.GetComponent<TurretSpawner>().istaken = true;
            GameObject newUnit = Instantiate(Towers[4], new Vector2(targettedSpawner.transform.position.x, targettedSpawner.transform.position.y), targettedSpawner.transform.rotation, targettedSpawner.transform);
            targettedSpawner.GetComponent<TurretSpawner>().UnitOn = newUnit;
            GeneralVars.OverlayIsActive = false;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void CraftTower5()
    {
        if (TowerPrice[5] <= GeneralVars.Money)
        {
            GeneralVars.Money -= ((int)TowerPrice[5]);
            targettedSpawner.GetComponent<TurretSpawner>().istaken = true;
            GameObject newUnit = Instantiate(Towers[5], new Vector2(targettedSpawner.transform.position.x, targettedSpawner.transform.position.y), targettedSpawner.transform.rotation, targettedSpawner.transform);
            targettedSpawner.GetComponent<TurretSpawner>().UnitOn = newUnit;
            GeneralVars.OverlayIsActive = false;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    #endregion
}
