using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotations : MonoBehaviour
{
    public GameObject target;
    public GameObject carRotat;
    public void CopyRotation(GameObject Target,GameObject SecondTarget, Vector3 Offset = default(Vector3))
    {
        transform.rotation = Quaternion.Euler(Offset) * (Target.transform.localRotation * SecondTarget.transform.localRotation);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(carRotat)
        CopyRotation(target,carRotat);
    }
}
