using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject buttonsGO;

    private GameObject[] models3D;
    private int currentIndex = 0;
    private string directoryPath = "";

    private const int FirstModelIndex = 0;
    private const int DecreaseValue = -1;
    private const int IncreaseValue = 1;

    private void Start()
    {
        models3D = Resources.LoadAll<GameObject>("Input");
        CreatingModel();

        directoryPath = Application.dataPath + "/Resources/Output/";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void LoadModelsSystem(int conditionLimit, int indexLimit, int calculationValue)
    {
        Transform modelSetPoint = transform.GetChild(0);
        Destroy(modelSetPoint.GetChild(0).gameObject);

        currentIndex = currentIndex + calculationValue;
        if (currentIndex == conditionLimit)
        {
            currentIndex = indexLimit;
        }

        CreatingModel();
    }

    private void CreatingModel()
    {
        Instantiate(models3D[currentIndex], transform.GetChild(0));
    }

    public void LoadPreviousModel()
    {
        ControllersManager.Instance.ResetModelRotation();
        int lastModelIndex = models3D.Length - 1;
        LoadModelsSystem(-1, lastModelIndex, DecreaseValue);
    }

    public void LoadNextModel()
    {
        ControllersManager.Instance.ResetModelRotation();
        LoadModelsSystem(models3D.Length, FirstModelIndex, IncreaseValue);
    }

    public void TakePhoto()
    {
        buttonsGO.SetActive(false);
        StartCoroutine("PhotoMaker");
    }

    private IEnumerator PhotoMaker()
    {
        yield return new WaitForEndOfFrame();

        ScreenCapture.CaptureScreenshot(directoryPath + SetPhotoFileName() + ".png");

        buttonsGO.SetActive(true);
    }

    private string SetPhotoFileName()
    {
        string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        return fileName;
    }
}
