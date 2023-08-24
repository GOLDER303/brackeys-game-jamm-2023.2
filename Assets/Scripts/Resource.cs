using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private string resourceName;
    public string ResourceName => resourceName;
}
