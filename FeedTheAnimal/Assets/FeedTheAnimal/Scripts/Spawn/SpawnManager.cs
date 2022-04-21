using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Serializable Variables

    [SerializeField]
    private GameObject[] animals;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private int spawnCount;

    [SerializeField]
    private List<GameObject> spawnedObjects;

    #endregion


    #region Unity

    private void Start()
    {
        CreateOnStart();
    }

    #endregion

    #region Functions

    IEnumerator SpawnAnimal()
    {
        for (int i = 0; i < spawnCount; i++)
        {           
            int num = Random.Range(0, spawnedObjects.Count);

            while (spawnedObjects[num].activeInHierarchy)
            {
                num = Random.Range(0, spawnedObjects.Count);
            }

            spawnedObjects[num].SetActive(true);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void CreateOnStart()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float randomNumber = Random.Range(-15f, 30f);
            float randomRotation = Random.Range(0f, 360f);
            int num = Random.Range(0, animals.Length);

            Vector3 targetLocation = new Vector3(randomNumber, 0, randomNumber);
            Quaternion targetRotation = Quaternion.Euler(0, randomRotation, 0);

            GameObject spawnedAnimal = Instantiate(animals[num], targetLocation, targetRotation);

            spawnedAnimal.transform.SetParent(target.transform);
            spawnedAnimal.SetActive(false);
            spawnedObjects.Add(spawnedAnimal);
        }
    }

    public void SpawnButton()
    {
        StartCoroutine(SpawnAnimal());
    }

    #endregion
}
