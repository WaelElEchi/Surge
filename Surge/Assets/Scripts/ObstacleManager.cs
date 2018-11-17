using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstacles;

    [SerializeField] private float distanceBetweenObstacles = 10f;

    public float lastY = 0;

    [SerializeField] private int spawnWaveCount = 5;

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
    }

    public void Spawn()
    {
        Shuffle(obstacles);

        for (int i = 0; i<spawnWaveCount; i++)
        {
            for (int j = 0; j<obstacles.Length; j++)
            {
                Vector3 pos = obstacles[j].transform.position;
                if (!obstacles[j].activeInHierarchy)
                {
                    pos.y=lastY+distanceBetweenObstacles;
                    pos.x=0;
                    obstacles[j].transform.position=pos;
                    obstacles[j].SetActive(true);
                    foreach (Transform child in obstacles[j].transform)
                    {
                        child.gameObject.SetActive(true);
                    }
                    lastY=pos.y;
                    break;
                }
            }
        }
    }

    private void Shuffle(GameObject[] T)
    {
        GameObject g;

        for (int i = 0; i<T.Length; i++)
        {
            int x = Random.Range(i, T.Length);
            g=T[i];
            T[i]=T[x];
            T[x]=g;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.position.y>=lastY)
        {
            Spawn();
        }
    }
}