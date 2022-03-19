using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[] models3D;
    private int currentIndex = 0;

    private const int FirstModelIndex = 0;
    private const int DecreaseValue = -1;
    private const int IncreaseValue = 1;

    private void Start()
    {
        models3D = Resources.LoadAll<GameObject>("Input");
        Instantiate(models3D[currentIndex], transform);
    }

    private void Update()
    {
        
    }

    private void LoadModelsSystem(int conditionLimit, int indexLimit, int calculationValue)
    {
        Destroy(transform.GetChild(0).gameObject);

        currentIndex = currentIndex + calculationValue;
        if (currentIndex == conditionLimit)
        {
            currentIndex = indexLimit;
        }

        Instantiate(models3D[currentIndex], transform);
    }

    public void LoadPreviousModel()
    {
        int lastModelIndex = models3D.Length - 1;
        LoadModelsSystem(-1, lastModelIndex, DecreaseValue);
    }

    public void LoadNextModel()
    {
        LoadModelsSystem(models3D.Length, FirstModelIndex, IncreaseValue);
    }

    public void TakeFoto()
    {

    }
}
