using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEvent : MonoBehaviour
{
    public TankController TankScr;


    public GameObject Creatura1;
    public GameObject Creatura2;
    public GameObject WallAfter2;
    public List<GameObject> Deathlines;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "EventTriggerTag":
                Destroy(other.gameObject);
                break;
            case "Battery":
                TankScr.batteryCharge++;
                TankScr.RenderBattery();
                Destroy(other.gameObject);
                break;
            case "Battery 1":
                TankScr.batteryCharge++;
                TankScr.RenderBattery();
                Destroy(other.gameObject);
                Creatura1.SetActive(true); //Creatura appears behind tonka
                break;
            case "Battery 2":
                TankScr.batteryCharge++;
                TankScr.RenderBattery();
                Destroy(other.gameObject);
                Creatura2.SetActive(true); //Creatura appears behind tonka
                WallAfter2.SetActive(false);
                //Wall crumble noises

                foreach(GameObject dLine in Deathlines)
                {
                    dLine.SetActive(true);
                }
                break;
            case "Creatura": //Touched passive creatura
                //Spooky dookie sound 
                other.gameObject.SetActive(false);
                break;
            case "CreaturaSpook": //Touched giga spook creatura
                //Spooky dookie sound
                TankScr.DisengageControls();
                other.gameObject.SetActive(false);
                //Make spooky image
                break;
            case "Deathline": //Touched creatura after crossing death line
                other.GetComponent<DeathLine>().Creatura.SetActive(true);
                TankScr.Deathlined = true;
                //Spooky dookie sound
                break;

            default:
                break;
        }
    }
}
