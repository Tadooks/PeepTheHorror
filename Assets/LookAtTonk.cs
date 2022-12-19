using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTonk : MonoBehaviour
{
    public Transform Tonk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.LookAt(new Vector3(Tonk.position.x, this.transform.position.y, Tonk.position.z));
    }
}
