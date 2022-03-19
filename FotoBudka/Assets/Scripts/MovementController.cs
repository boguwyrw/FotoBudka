using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private GameObject cameraGO;

    private GameObject modelSetPoint;

    private const float MiddleScrollValue = 0.0f;
    private const float ZoomInBoundary = -2.0f;
    private const float ZoomOutBoundary = -30.0f;

    private void Start()
    {
        modelSetPoint = transform.GetChild(0).gameObject;
    }

    private void LateUpdate()
    {
        CameraMovementFunctionality();
    }

    #region CameraMovement
    private void CameraMovementFunctionality()
    {
        float cameraZoomValue = Input.mouseScrollDelta.y;
        float cameraPositionZ = cameraGO.transform.position.z;

        CameraZoom(cameraZoomValue, cameraPositionZ);
    }

    private void CameraZoom(float zoomValue, float positionZ)
    {
        if (zoomValue > MiddleScrollValue && positionZ < ZoomInBoundary)
        {
            CameraMovement(zoomValue);
        }
        else if (zoomValue < MiddleScrollValue && positionZ > ZoomOutBoundary)
        {
            CameraMovement(zoomValue);
        }
    }

    private void CameraMovement(float directionValue)
    {
        cameraGO.transform.Translate(Vector3.forward * directionValue);
    }
    #endregion

    #region ModelMovement
    
    #endregion
}
