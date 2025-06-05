using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 2f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipe = Instantiate(prefab, transform.position, Quaternion.identity);
        pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
