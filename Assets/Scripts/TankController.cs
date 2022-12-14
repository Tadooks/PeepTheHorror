using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    Rigidbody rig;

    public float speed;
    private float oldSpeed;
    public int engagedTracks = 0; // -1 - Left, 0 - Both, 1 - Right
    public List<GameObject> BatteryIndicators;
    public int batteryCharge;
    public Material batteryOff;
    public Material batteryOn;
    public bool Deathlined = false;
    public Light intLight;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        RenderBattery();
        oldSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MoveTank(float thrust)
    {
        if(speed > 0)
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

    public void DisengageControls()
    {
        speed = 0;
        intLight.intensity = 0.75f;
    }
    IEnumerator Control()
    {

        for (int i = 0; i < 2; i++)
        {
            Debug.LogWarning("Time started)");
            yield return new WaitForSeconds(3);
            Debug.LogWarning("Time passed");
            speed = oldSpeed;
            intLight.intensity = 2.28f;
        }
    }

    public void EngageControls()
    {
        if (speed <= 0)
        {
            StartCoroutine(Control());
        }
    }

 
}
