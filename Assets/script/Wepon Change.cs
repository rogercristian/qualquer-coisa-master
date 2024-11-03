using UnityEngine;

public class Wepon_Change : MonoBehaviour
{
    [SerializeField] private int selectedWeapon = 0;
    bool hasWeapon = false;
    private void Start()
    {
        GameEvents.OnGetGun += HandleOnGetGun;
     // SelectWepon();
    }

    private void HandleOnGetGun()
    {
        SelectWepon();
        hasWeapon = true;

    }

    void Update()
    {
        if (!hasWeapon) return; // as trocas ate que se tenha arma

        int previusSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {

            if (previusSelectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;


            }
            else
            {
                selectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            if (previusSelectedWeapon <= 0)
            {


                if (previusSelectedWeapon <= 0)
                {
                    selectedWeapon = transform.childCount - 1;
                }
                else selectedWeapon--;

            }
        }
        if (previusSelectedWeapon != selectedWeapon) SelectWepon();


    }
    private void SelectWepon()
    {

        int i = 0;

        foreach (Transform wepon in transform)
        {

            if (i == selectedWeapon)
            {
                wepon.gameObject.SetActive(true);

            }
            else { wepon.gameObject.SetActive(false); }

            i++;
        }
    }




    // Start is called before the first frame update


    // Update is called once per frame

}
