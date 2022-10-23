using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    Rigidbody rig;

    public float speed;
    public int engagedTracks = 0; // -1 - Left, 0 - Both, 1 - Right
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
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
}
