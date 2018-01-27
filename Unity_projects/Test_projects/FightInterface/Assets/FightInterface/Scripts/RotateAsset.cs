using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAsset : MonoBehaviour
{
    [SerializeField] private float RotationSpeed = 10f;


    void Update()
    {
        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }
}