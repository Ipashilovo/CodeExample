using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Floor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out InteractiveItemPositionRemover usefullItemRemover))
        {
            usefullItemRemover.ReturnToStartPosition();
            return;
        }

        if (other.gameObject.TryGetComponent(out DestroingObject destroingObject))
        {
            StartCoroutine(DestroyDroping(destroingObject.gameObject));
        }
    }

    private IEnumerator DestroyDroping(GameObject gameObject)
    {
        float delay = 3f;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
