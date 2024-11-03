using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float live = 100;
    [SerializeField] private bool isPlayer;
   
    public void TakeDamege(float amount)
    {

        live -= amount;

        if (live <= 0)
        {

            Die();

         

        }
        
        
    }


    private void Die()
    {
   
        if (isPlayer) {
        
            StartCoroutine(WaitToDestroy());

            Destroy(gameObject);

           
        
        
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    public bool IsPlayer() { return isPlayer; }

    public float Life() { return live; }



    IEnumerator WaitToDestroy () {
        yield return new WaitForSeconds(1);
            }

}
