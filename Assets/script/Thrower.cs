using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troher : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject explosivo;
    [SerializeField] int capacidadeMaxima = 3;
    [SerializeField] float throweForce = 20;
    int currentExplisiveMax;
    
    
    
    void Start()
    {
        currentExplisiveMax = capacidadeMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentExplisiveMax > 0)
        {

            AtirarExplosivo();
        }
    }

    private void AtirarExplosivo()
    {
        currentExplisiveMax--;

        GameObject go= Instantiate(explosivo,transform.position,transform.rotation);

        Rigidbody rb = go.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * throweForce, ForceMode.VelocityChange);
    }
}
