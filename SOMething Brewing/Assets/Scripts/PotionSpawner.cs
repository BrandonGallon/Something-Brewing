using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    public GameObject[] potionPrefabs;
    public Transform[] spawnPoints;
    public int maxPotions = 3;

    void Start()
    {
        SpawnPotions();
    }

    public void SpawnPotions()
    {
        int count = Mathf.Min(maxPotions, spawnPoints.Length);

        for (int i = 0; i < count; i++)
        {
            int randomPotion = Random.Range(0, potionPrefabs.Length);
            Instantiate(potionPrefabs[randomPotion], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }
}
