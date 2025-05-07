using System.Collections;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private Target[] targetObjects;
    private Coroutine spawnCoroutine;

    void Start()
    {
        StartSpawning();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 2f));
        while (true)
        {
            Vector2 spawnPosition = new Vector2(RandomX(), -5);
            Vector3 spwanRotation = new Vector3(0, 0, RandomRotation());
            Instantiate(targetObjects[Random.Range(0, targetObjects.Length)], spawnPosition, Quaternion.Euler(spwanRotation));
            yield return new WaitForSeconds(Random.Range(0.2f, 2f));
        }
    }

    private int RandomX()
    {
        return Random.Range(-8, 8);
    }

    private int RandomRotation()
    {
        return Random.Range(0, 360);
    }

    public void HandleStateChange(bool isPaused)
    {
        if (!isPaused)
        {
            StopSpawning();
        }
        else
        {
            StartSpawning();
        }
    }
    private void StartSpawning()
    {
        spawnCoroutine = StartCoroutine(Spawn());
    }

    private void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
        else
        {
            Debug.Log("Error: No coroutine to stop.");
        }
    }
}
