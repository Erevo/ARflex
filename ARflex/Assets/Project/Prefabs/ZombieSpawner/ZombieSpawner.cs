using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject Map;
    [SerializeField] GameObject[] Zombies;
    [SerializeField] private GameObject[] SpawnPoints;

    public int zombieMax;
    public float zombieTime;
    public float startNewWaveTime;

    [SerializeField] bool Active = false;
    void OnEnable()
    {

        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        StartCoroutine(waveTime());
    }

    void Update()
    {
        if (Map.GetComponent<MeshRenderer>().enabled)
        {
            Active = true;
        }
        else
            Active = false;
    }

    IEnumerator waveTime()
    {
        yield return new WaitForSecondsRealtime(3);

        while (true)
        {
            for (int i = 0; i < zombieMax; i++)
            {
                if (Active)
                {
                    GameObject zombie = Instantiate(Zombies[Random.Range(0, Zombies.Length)], SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position, Quaternion.Euler(0, -90, 0));
                    zombie.transform.SetParent(GameObject.Find("Map").transform);
                    yield return new WaitForSecondsRealtime(zombieTime);

                }
            }
            if (zombieMax < 20)
                zombieMax += 5;
            if (zombieTime > 1)
                zombieTime *= 0.8f;
            yield return new WaitForSecondsRealtime(startNewWaveTime);
            //startNewWaveTime *= 0.9f;
        }
    }
}
