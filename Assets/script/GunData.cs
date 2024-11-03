
using UnityEngine;
[CreateAssetMenu(fileName = "gun_",menuName = "new gun")]
public class GunData : ScriptableObject

{ 
    public string gunName;
    public int gunId;
    public int damage;
    public GameObject gunPrefab;

}
