using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] Transform target;
    Animator animator;
    [SerializeField] float dangerRange = 30;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = FindAnyObjectByType<FpsMove>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 distancia = agent.transform.position - target.position;

        if (distancia.sqrMagnitude > dangerRange) { return; }

        agent.destination = target.position;


        if (agent.velocity != null)
        {
            if (animator != null)
                animator.SetBool("run", true);



        }

    }
}
