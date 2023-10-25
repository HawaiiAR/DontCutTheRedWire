using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireStopper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WireStopper"))
        {
            SetParentToNull();
        }
    }
    private void SetParentToNull()
    {
        this.transform.parent = null;
    }
}
