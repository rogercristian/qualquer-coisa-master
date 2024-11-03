using System.Collections;
using UnityEngine;

public class Carta : MonoBehaviour
{
    [SerializeField] GameObject carta;
    [SerializeField] GameObject inputbuttom;
    /* [SerializeField]*/
    BoxCollider box;
    bool show = false;
    // [SerializeField] GameObject arma;
    [SerializeField] Transform spawnArma;
    // Start is called before the first frame update
    void Start()
    {

        Hide();
        HideButtom();
        box = GetComponent<BoxCollider>();
        spawnArma.gameObject.SetActive(false);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && show)
        {

            HideButtom();
            Show();

            StartCoroutine(TimeToCount(5f));
            box.enabled = false;
            //  Instantiate(arma, spawnArma.position, spawnArma.rotation);
            spawnArma.gameObject.SetActive(true);
            show = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) & !show)
        {
            Hide();
            GameEvents.SetMove();
        }

    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowButtom();
            show = true;
            GameEvents.SetStop();

        }

    }
    void Hide() { carta.SetActive(false); }
    void Show() { carta.SetActive(true); }
    void HideButtom() { inputbuttom.SetActive(false); }

    void ShowButtom() { inputbuttom.SetActive(true); }


    //private void OnTriggerExit(Collider other)
    //{


    //    if (other.CompareTag("Player"))
    //    {
    //        Hide();
    //        box.enabled = false;

    //        show = false;
    //    }

    //}

    IEnumerator TimeToCount(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
