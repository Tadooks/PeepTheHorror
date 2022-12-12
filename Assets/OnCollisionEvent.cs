using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEvent : MonoBehaviour
{
    public TankController TankScr;

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

            default:
                break;
        }
    }
}
