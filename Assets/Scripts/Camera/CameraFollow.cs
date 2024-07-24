using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;
    private Transform mTransform;



    [SerializeField]
    private float XBorder;
    [SerializeField]
    private float ZBorder;

    [SerializeField]
    private Transform ground;




    private void OnEnable()
    {
        mTransform = GetComponent<Transform>();
    }


    private void Update()
    {
       
        mTransform.position = new Vector3(Mathf.Clamp(followTarget.position.x, -XBorder, XBorder), mTransform.position.y, Mathf.Clamp(followTarget.position.z, -ZBorder, ZBorder));


    }


}
