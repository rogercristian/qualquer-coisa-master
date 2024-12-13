using UnityEngine;

public class Spawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<FpsMove>(out var player))
        {
            GameEvents.Spawner();
        }
    }
}
