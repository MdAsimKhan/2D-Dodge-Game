using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject prefab;
    public float minX = -2f, maxX = 2f;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawnDemons());
    }

    IEnumerator SpawnDemons()
    {
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        Instantiate(prefab, new Vector2(Random.Range(minX, maxX), transform.position.y), Quaternion.identity);
        StartCoroutine(SpawnDemons());
    }
}
