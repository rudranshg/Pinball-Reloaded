using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDirectionDrawer : MonoBehaviour
{   public float length = 1f;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * length));
    }
}
