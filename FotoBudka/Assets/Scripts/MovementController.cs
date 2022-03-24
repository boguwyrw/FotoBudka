using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private GameObject cameraGO;

    private float sensitivity = 1000.0f;
    private float modelRotationX = 0.0f;
    private float modelRotationY = 0.0f;

    private const float MiddleScrollValue = 0.0f;
    private const float ZoomInBoundary = -2.0f;
    private const float ZoomOutBoundary = -30.0f;

    private void LateUpdate()
    {
        CameraMovementFunctionality();

        ModelRotationFunctionality();
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
    private void ModelRotationFunctionality()
    {
        bool isFrontView = ControllersManager.Instance.modelSetPoint.transform.localRotation == Quaternion.identity;

        if (Input.GetMouseButton(1))
        {
            float modelAxisY = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float modelAxisX = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            modelRotationX += modelAxisX;
            modelRotationY -= modelAxisY;

            ControllersManager.Instance.modelSetPoint.transform.localRotation = Quaternion.Euler(modelRotationX, modelRotationY, 0.0f);
        }
        else if (isFrontView)
        {
            modelRotationX = 0.0f;
            modelRotationY = 0.0f;
        }
    }
    #endregion
}
