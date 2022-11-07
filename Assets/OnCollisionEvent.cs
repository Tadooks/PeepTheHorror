using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //on trigger do some jumpscare thing or something
        if (other.gameObject.tag=="EventTriggerTag")
        {
            Destroy(other.gameObject);
        }
    }
}
