using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    [SerializeField] private scoreManager scoreManager;
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private float scale;
    [SerializeField] private float gridSize;

    [SerializeField] private float spawnX;
    [SerializeField] private float spawnZ;


    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                var instantiatedGameObject = Instantiate(prefabToSpawn, container.transform);
                instantiatedGameObject.transform.localScale = new Vector3(scale, scale, scale);
                instantiatedGameObject.transform.position = new Vector3((i * scale)+spawnX, 0, (j * scale)+spawnZ);
                var TriggerWithCustomEventBehavior = instantiatedGameObject.GetComponent<TriggerWithCustomEventBehavior>();  
                scoreManager.triggerWithCustomEventBehaviors.Add(TriggerWithCustomEventBehavior); 
            }
        }
    }
}