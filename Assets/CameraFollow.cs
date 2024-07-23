using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;
    private Transform mTransform;

    private Vector3 cameraPosition;

    [SerializeField]
    private Transform ground;

    private Vector2 activeAxis;
    private Vector3 targetBorderStopPosition;
    bool hasFixedAxis = false;
    bool canFollow = true;

    private Coroutine waitToContinueCoroutine;

    private Camera mCamera;

    private void OnEnable()
    {
        mTransform = GetComponent<Transform>();
        cameraPosition = mTransform.position;

        activeAxis = Vector2.one;

        Vector2 StartPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//
        Vector2 EndPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//

        mCamera = GetComponent<Camera>();
    }


    private void Update()
    {
        Vector3 pos = mCamera.WorldToViewportPoint(ground.position);

        Debug.Log("pos: " + pos);


        if (IsVisible(Camera.main, ground.gameObject))
        {
            Debug.Log("isVisibale: " + true);
        }
        else
        {
            Debug.Log("isVisibale: " + false);
        }
       
        
        if (pos.x < 0.0)
        {
            activeAxis = new Vector2(0, 1);
            //hasFixedAxis = true;
            //targetBorderStopPosition = followTarget.position;
            Debug.Log("I am left of the camera's view.");
          
            //return;
        }
        else if (pos.x > 1.0) 
        {
            activeAxis = new Vector2(0, 1);
            //hasFixedAxis = true;
            //targetBorderStopPosition = followTarget.position;
            Debug.Log("I am right of the camera's view.");
            //return;
        }
        else if (pos.y < 0.0)
        {
            activeAxis = new Vector2(1, 0);
            //hasFixedAxis = true;
            //targetBorderStopPosition = followTarget.position;
            Debug.Log("I am below the camera's view.");
            
        }
        else if (pos.y > 1.0f) 
        {
            activeAxis = new Vector2(1, 0);
            //asFixedAxis = true;
            //targetBorderStopPosition = followTarget.position;
            Debug.Log("I am above the camera's view.");
            
        }
        else
        {
            hasFixedAxis = false;
            activeAxis = new Vector2(1, 1);
            //Debug.Log("Else");

            hasFixedAxis = false;
        }
        

        mTransform.position = new Vector3((activeAxis.x == 0? mTransform.position.x: followTarget.position.x), mTransform.position.y, (activeAxis.y == 0 ? mTransform.position.z : followTarget.position.z));

        /*
        cameraPosition = new Vector3(followTarget.position.x * activeAxis.x, mTransform.position.y, followTarget.position.z * activeAxis.y);
        mTransform.position = Vector3.Lerp(mTransform.position, cameraPosition, 0.4f);
        */



    }

    private IEnumerator waitToContinueFollow()
    {
        while (Vector3.Distance(targetBorderStopPosition, followTarget.position) > 4f)
        {
            canFollow = true;
            yield return null;
        }
    }



    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if(plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }

        return true;
    }
}
