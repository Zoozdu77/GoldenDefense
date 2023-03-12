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
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Ended && !GeneralVars.OverlayIsActive)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.gameObject.CompareTag("turretSpawn"))
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
                            CanvasUP.GetComponent<Upgrade>().UpStart(hit.transform.GetComponent<TurretSpawner>().UnitOn);
                            GeneralVars.OverlayIsActive = true;
                        }
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
