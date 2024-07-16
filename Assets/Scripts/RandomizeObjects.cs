using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeObjects : MonoBehaviour
{

    [SerializeField] private GameObject[] objects; // Array to hold the GameObjects

    void Start()
    {
        RandomizePrefabs();
    }

    void RandomizePrefabs()
    {
        // Ensure there are objects in the array
        if (objects.Length == 0) return;

        // Randomly select an index
        int randomIndex = Random.Range(0, objects.Length);

        // Loop through the array
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == randomIndex)
            {
                objects[i].SetActive(true); // Set the selected object active
            }
            else
            {
                objects[i].SetActive(false); // Set the other objects inactive
            }
        }
    }
}
