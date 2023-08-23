using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentWeaponBehaviour : MonoBehaviour
{
    public GameObject followedObject { set; get; }

    [SerializeField] protected float speed;
}
