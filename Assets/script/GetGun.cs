using UnityEngine;

public class GetGun : MonoBehaviour

{
    public GunData gunData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<FpsMove>(out FpsMove player))
        {
            Wepon_Change wepon_Change = FindAnyObjectByType<Wepon_Change>();
            GameObject temp = Instantiate(gunData.gunPrefab, wepon_Change.transform.position, wepon_Change.transform.rotation);
            temp.transform.SetParent(wepon_Change.transform);
            GameEvents.GetGun();
            Destroy(gameObject);
        }
    }
}
