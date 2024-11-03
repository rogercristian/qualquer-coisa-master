using UnityEngine;

public class FpsMove : MonoBehaviour
{
    [SerializeField] float velocidade = 10;
    [SerializeField] LayerMask layer;
    [SerializeField] float raio = 1f;
    Vector2 input;
    Vector3 direction;
    Transform cam;
    Rigidbody rb;
    bool chao;
    [SerializeField] float alturaDoPulo = 4;


    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.OnSetStop += GameEvents_OnSetStop;
        GameEvents.OnSetMove += GameEvents_OnSetMove;
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void GameEvents_OnSetMove()
    {
        canMove = true;
    }

    private void GameEvents_OnSetStop()
    {
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return; 
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, cam.eulerAngles.y, transform.eulerAngles.z);

        input = InputManager.GetInstance().GetMovediraction();

        direction = input.y * Vector3.forward + input.x * Vector3.right;
        direction = transform.TransformDirection(direction);
        transform.Translate(direction * velocidade * Time.deltaTime, Space.World);

        RaycastHit hit;

        Physics.Raycast(transform.position, Vector3.down, out hit, raio, layer);
        chao = hit.collider;

        Jump();

    }

    void Jump()
    {
        if (InputManager.GetInstance().GetSubmitpressed() && chao) rb.velocity = Vector3.up * alturaDoPulo;

    }

}
