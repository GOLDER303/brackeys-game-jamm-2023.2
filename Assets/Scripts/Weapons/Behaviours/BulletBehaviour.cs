using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : ProjectileWeaponBehaviour
{
    public Vector2 Direction { set; private get; }

    private void Update()
    {
        transform.position += new Vector3(Direction.x * speed * Time.deltaTime, Direction.y * speed * Time.deltaTime, 0);
    }
}
