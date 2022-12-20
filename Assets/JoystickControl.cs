using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    public AudioSource audio;
    public Transform topOfJoystick;

    public TankController tankScr;
    public ControlType ctrlType;

    [SerializeField]
    private float forwardBackwardTilt = 0;

    [SerializeField]
    private float sideToSideTilt = 0;

    public enum ControlType
    {
        Gears,
        Throttle
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;
        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
        {
            forwardBackwardTilt = Math.Abs(forwardBackwardTilt - 360);
            Debug.Log("Backward" + forwardBackwardTilt);
            //move something using forwardbackwardtilt as speed (car/tank)
            if(ctrlType == ControlType.Gears)
            {
                tankScr.engagedTracks = -1;
            }
            else if(ctrlType == ControlType.Throttle)
            {
                tankScr.MoveTank(-forwardBackwardTilt / 2);
            }
                
        }
        else if(forwardBackwardTilt > 5 && forwardBackwardTilt<74)
        {
            Debug.Log("Forward" + forwardBackwardTilt);
            
            //move something using forwardbackwardtilt as speed (car/tank)
            if (ctrlType == ControlType.Gears)
            {
                tankScr.engagedTracks = 1;
            }
            else if (ctrlType == ControlType.Throttle)
            {
                tankScr.MoveTank(forwardBackwardTilt);
                //audio pitch here maybie
            }
        }
        else
        {
            if (ctrlType == ControlType.Gears)
            {
                tankScr.engagedTracks = 0;
            }
            else if (ctrlType == ControlType.Throttle)
            {
                tankScr.MoveTank(0);
            }
        }

        sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;
        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Math.Abs(sideToSideTilt - 360);
            Debug.Log("Right" + sideToSideTilt);

        }
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            Debug.Log("Left" + sideToSideTilt);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
