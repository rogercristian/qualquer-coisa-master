using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{
    [SerializeField] GameObject corpser;
    [SerializeField] GameObject zombie;
    NavMesh navMesh;
  //  bool interact = false;
    // Start is called before the first frame update
    void Start()
    {
        zombie.SetActive(false);
        GameEvents.OnSpawner += GameEvents_OnSpawner;
        navMesh = zombie.GetComponent<NavMesh>();
        navMesh.enabled = false;
    }

    private void GameEvents_OnSpawner()
    {
        corpser.SetActive(false);
        zombie.SetActive(true);
      //  interact = true;
        navMesh.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
