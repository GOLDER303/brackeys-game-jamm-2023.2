using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private GameObject fill;

    private void Awake()
    {
        fill = transform.Find("Fill").gameObject;
    }

    public void SetSize(float size)
    {
        if (size < 0)
        {
            size = 0;
        }
        else if (size > 1)
        {
            size = 1;
        }

        fill.transform.localScale = new Vector3(size, fill.transform.localScale.y);
    }
}
