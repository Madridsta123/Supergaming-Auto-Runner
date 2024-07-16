using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputShape : MonoBehaviour
{
    public GameObject upperPart;
    public GameObject lowerPart;

    private GameObject[] upperShapes;
    private GameObject[] lowerShapes;

    private int upperIndex = 0;
    private int lowerIndex = 0;
    void Start()
    {
        upperShapes = new GameObject[upperPart.transform.childCount];
        lowerShapes = new GameObject[lowerPart.transform.childCount];

        for (int i = 0; i < upperPart.transform.childCount; i++)
        {
            upperShapes[i] = upperPart.transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < lowerPart.transform.childCount; i++)
        {
            lowerShapes[i] = lowerPart.transform.GetChild(i).gameObject;
        }

        UpdateShape(upperShapes, upperIndex);
        UpdateShape(lowerShapes, lowerIndex);
    }
    void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CycleUpperShape();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CycleLowerShape();
        }
    }
    void CycleUpperShape()
    {
        upperIndex = (upperIndex + 1) % upperShapes.Length;
        UpdateShape(upperShapes, upperIndex);
    }

    void CycleLowerShape()
    {
        lowerIndex = (lowerIndex + 1) % lowerShapes.Length;
        UpdateShape(lowerShapes, lowerIndex);
    }
    void UpdateShape(GameObject[] shapes, int index)
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            shapes[i].SetActive(i == index);
        }
    }

}
