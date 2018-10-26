using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronManager : MonoBehaviour {

    [SerializeField]
    private Transform spawnPosition;
    [SerializeField]
    private Transform doorPosition;
    [SerializeField]
    private Patron patronPrefab;
    [SerializeField]
    private List<Transform> chairs;
    [SerializeField]
    private List<Material> clothesMaterials;
    [SerializeField]
    private List<Material> skinMaterials;

    private void Awake()
    {

    }

    private void Start()
    {
        StartCoroutine(timer());
    }

    private void SpawnPatron()
    {
        Transform destination = getDestination();
        if (destination == null)
        {
            return;
        }
        Patron newPatron = Instantiate(patronPrefab, spawnPosition.position, new Quaternion(0,0,0,0), null);
        newPatron.SetLook(
            skinMaterials[Random.Range(0, skinMaterials.Count)], 
            clothesMaterials[Random.Range(0, clothesMaterials.Count)], 
            clothesMaterials[Random.Range(0, clothesMaterials.Count)]
        );

        newPatron.transform.position = doorPosition.position;
        newPatron.SetDestination(destination);
    }

    private Transform getDestination()
    {
        Transform chosenChair = chairs[Random.Range(0,chairs.Count)];
        chairs.Remove(chosenChair);
        return chosenChair;
    }

    private IEnumerator timer()
    {
        SpawnPatron();
        yield return new WaitForSeconds(2);
        StartCoroutine(timer());
    }
}
