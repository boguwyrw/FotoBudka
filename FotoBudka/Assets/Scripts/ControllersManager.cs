using UnityEngine;

public class ControllersManager : MonoBehaviour
{
    #region Singleton
    private static ControllersManager _instance;

    public static ControllersManager Instance
    {
        get
        {
            if (_instance == null) _instance = new ControllersManager();
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    [HideInInspector] public GameObject modelSetPoint;

    private void Start()
    {
        modelSetPoint = transform.GetChild(0).gameObject;
    }

    public void ResetModelRotation()
    {
        modelSetPoint.transform.localRotation = Quaternion.identity;
    }
}
