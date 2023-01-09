using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject CanvasUP;

    public GameObject UnitOn;

    public bool istaken;

    void Update()
    {//Detecting the click on gameobject with tag "cube"
        if (Input.GetMouseButtonDown(0) && !GeneralVars.OverlayIsActive)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "turretSpawn")
                {
                    if (!hit.transform.GetComponent<TurretSpawner>().istaken)
                    {
                        Canvas.SetActive(true);
                        Canvas.GetComponent<MenusBehavior>().targettedSpawner = hit.transform.gameObject;
                        GeneralVars.OverlayIsActive = true;
                    } else if (hit.transform.GetComponent<TurretSpawner>().UnitOn.GetComponent<Turret>().Level < hit.transform.GetComponent<TurretSpawner>().UnitOn.GetComponent<Turret>().LevelMax)
                    {
                        CanvasUP.SetActive(true);
                        CanvasUP.GetComponent<Upgrade>().targettedSpawner = hit.transform.gameObject;
                        CanvasUP.GetComponent<Upgrade>().upStart(hit.transform.GetComponent<TurretSpawner>().UnitOn);
                        GeneralVars.OverlayIsActive = true;
                    }
                }
            }
        }
    }

    /*private void OnMouseUp()
    {
        if (!istaken)
        {
            Canvas.SetActive(true);
            Canvas.GetComponent<MenusBehavior>().targettedSpawner = gameObject;
        }
    }*/
}
