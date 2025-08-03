using UnityEngine;

public class PositionWatcher : MonoBehaviour
{
    private Vector3 lastPosition;

    void LateUpdate()
    {
        if (transform.position != lastPosition)
        {
            Debug.Log($"[PositionWatcher] Posici�n CAMBIADA en frame {Time.frameCount}: {transform.position}");
            lastPosition = transform.position;
        }
    }
}
