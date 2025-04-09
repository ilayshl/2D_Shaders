using System.Collections;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private Target targetObject;
    private Coroutine spawnCoroutine;
    private bool gameActive = true;

    void Start()
    {
        spawnCoroutine = StartCoroutine(Spawn());
    }

    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        while(gameActive)
        {
            Vector2 spawnPosition = new Vector2(RandomX(), -5);
            Vector3 spwanRotation = new Vector3(0, 0, RandomRotation());
            Instantiate(targetObject, spawnPosition, Quaternion.Euler(spwanRotation));
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
}
