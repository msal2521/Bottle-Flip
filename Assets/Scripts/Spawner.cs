﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int PooledAmount;
    public float StartSpawningPos, SpawnInterval;
    public GameObject Bottle, ItemsContainer;
    public Vector3 BottlePos;
    public List<GameObject> ItemsPool, ItemsPrefab;
    public List<Transform> checkPoints;

    private void Start()
    {
        ItemsPool = new List<GameObject>();
        for (int i = 0; i < PooledAmount; i++)
        {
            GameObject Items = Instantiate(ItemsPrefab[i]);
            Items.transform.SetParent(ItemsContainer.transform);
            Items.SetActive(false);
            ItemsPool.Add(Items);
        }
    }

    private void Update()
    {
        BottlePos.x = Bottle.transform.position.x;
        if (BottlePos.x >= StartSpawningPos)
        {
            SpawnItems();
            StartSpawningPos = BottlePos.x + SpawnInterval;
        }
    }

    private void SpawnItems()
    {
        for (int i = 0; i < PooledAmount; i++)
        {
            float randomX = Random.Range(BottlePos.x + 4f, 40f);
            Vector3 spawnPosition = new Vector3(randomX, 1.0f, 1.0f);

            if (!ItemsPool[i].activeInHierarchy)
            {
                ItemsPool[i].SetActive(true);
                ItemsPool[i].transform.position = spawnPosition;
                break;
            }
        }
    }
}