using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    Rigidbody rig;

    public float speed;
    public int engagedTracks = 0; // -1 - Left, 0 - Both, 1 - Right
    public List<GameObject> BatteryIndicators;
    public int batteryCharge;
    public Material batteryOff;
    public Material batteryOn;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        RenderBattery();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MoveTank(float thrust)
    {
        switch (engagedTracks)
        {
            case 0:
                rig.velocity = transform.forward * thrust / 10 * speed;
                break;
            case 1:
                this.gameObject.transform.RotateAround(Vector3.up, 0.01f * thrust / 50);
                break;
            case -1:
                this.gameObject.transform.RotateAround(Vector3.up, -0.01f * thrust / 50);
                break;
            default:
                break;
        }
    }

    public void RenderBattery()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i < batteryCharge)
            {
                BatteryIndicators[i].GetComponent<MeshRenderer>().material = batteryOn;
            }
            else
            {
                BatteryIndicators[i].GetComponent<MeshRenderer>().material = batteryOff;
            }
        }
    }
}
