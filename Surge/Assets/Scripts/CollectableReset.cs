using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableReset : MonoBehaviour
{
    [SerializeField] private GameObject[] collectables;
    [SerializeField] private int count;

    private void OnEnable()
    {
        ActivateCollectables();
    }

    private void ActivateCollectables()
    {
        for (int i = 0; i<count; i++)
        {
            if (!collectables[i].activeInHierarchy)
                collectables[i].SetActive(true);
        }
    }
}