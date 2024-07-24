using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float incrementSpeed = 0;
    private float multiplierSpeed = 1;

    private Transform mTransform;
    private Quaternion mRotation;
    //private Rigidbody mRigidbody;

    private void Start()
    {
        mTransform = GetComponent<Transform>();
        mRotation = mTransform.rotation;

        //mRigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction -= Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= Vector3.forward;
        }

        mTransform.position += direction * ((speed + incrementSpeed) * multiplierSpeed) * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            Vector3 targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mTransform.position;
            //mTransform.LookAt(targetPoint);
            float angle = Mathf.Atan2(targetPoint.z, targetPoint.x) * Mathf.Rad2Deg;
            mRotation = Quaternion.AngleAxis(-angle + 90, Vector3.up);
        }


        mTransform.rotation = Quaternion.Lerp(mTransform.rotation, mRotation, 0.1f);
    }

    public void ChangeIncrementSpeedValue(float inputValue)
    {
        incrementSpeed += inputValue;
    }
    public void ChangeMuiltiplierSpeedValue(float inputValue)
    {
        multiplierSpeed = inputValue;
    }
}
