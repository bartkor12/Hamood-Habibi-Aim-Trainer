using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public float size = 1f;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        float xMin = bounds.min.x;
        float xMax = bounds.max.x;
        float yMin = bounds.min.y;
        float yMax = bounds.max.y;
        float zMin = bounds.min.z;
        float zMax = bounds.max.z;

        for (int i = 0; i < numberOfCubes; i++)
        {
            float x = Random.Range(xMin, xMax);
            float y = Random.Range(yMin, yMax);
            float z = Random.Range(zMin, zMax);
            Vector3 randomPos = new Vector3(x, y, z);
            Instantiate(cubePrefab, randomPos, Quaternion.identity);
        }
    }

    void Update()
    {
        GameObject[] allCubes = GameObject.FindGameObjectsWithTag("Cube");
        if (allCubes.Length == 0)
        {
            Spawn();
        }
    }
}