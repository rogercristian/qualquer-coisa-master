using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float delay = 3f;
    [SerializeField] private float radios = 5f;
    [SerializeField] private float force = 500f;
    [SerializeField] GameObject explosaoEfeito;
    float countDown;
    bool explosion = false;
    

    void Start()
    {
        countDown = delay;
        
    }

    // Update is called once per frame
    void Update()
    { 
        countDown -= Time.deltaTime;

        if (countDown <= 0 && !explosion) {
            Explosion();
            explosion = true;
        
        }
        
    }

    private void Explosion()
    {
       Instantiate(explosaoEfeito,transform.position,transform.rotation);

        Collider[] fragmentos = Physics.OverlapSphere(transform.position, radios);

        foreach (Collider frag in fragmentos) {
        
        Destruir destruir = frag.GetComponent<Destruir>();


            if (destruir != null)
            {

                destruir.Destruindo();
            }
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, radios);

        foreach(Collider collider in colliders)
        {

            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb != null) {

                rb.AddExplosionForce(force, transform.position, radios);
            } 

        }

        Collider[] explosaoQueMata = Physics.OverlapSphere (transform.position, radios);
        foreach(Collider conTarget in explosaoQueMata) { 
        
        Target target = conTarget.GetComponent<Target>();   
            if (target != null)
            {

                target.TakeDamege(1000);

            }
        
        
        }
        
        
        
        
        
        
        
        
        Destroy(gameObject);









    }



  


}
