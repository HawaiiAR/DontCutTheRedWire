using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireStopper : MonoBehaviour
{

    [SerializeField] Collider[] _wireColliders;


    private void Awake()
    {
        ColliderActiveState(false);
    }
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
        ColliderActiveState(true);
    }

    private void ColliderActiveState(bool state)
    {
        foreach (Collider c in _wireColliders)
        {
            c.enabled = state;
        }
    }
}
