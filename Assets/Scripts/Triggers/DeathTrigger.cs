using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BaseObject>(out var obj)) {
            obj.EnterDeathZone();
        }
    }
}
