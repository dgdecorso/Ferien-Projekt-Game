using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RapperScript : MonoBehaviour
{
    public Image ImageDrake;
    public Image ImageTervis;
    public Image ImageYe;
    public Image ImageTyler;

    public Image ImageKendrick;
   // private bool isYeOn = true;


    void Start()
    {
        if (ImageDrake == null)
        {
            Debug.LogError("ImageDrake is not assigned in the Inspector!");
            return;
        }

         if (ImageYe == null)
        {
            Debug.LogError("ImageYe is not assigned in the Inspector!");
            return;
        }

         if (ImageTervis == null)
        {
            Debug.LogError("ImageTervis is not assigned in the Inspector!");
            return;
        }


        ImageTervis.gameObject.SetActive(false);
        ImageDrake.gameObject.SetActive(false);
        ImageYe.gameObject.SetActive(true);
        ImageTyler.gameObject.SetActive(false);
 ImageKendrick.gameObject.SetActive(false);
    }



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ImageYe.gameObject.SetActive(false);
            ImageTervis.gameObject.SetActive(true);
            ImageDrake.gameObject.SetActive(false);
                             ImageTyler.gameObject.SetActive(false);
ImageKendrick.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {       
            ImageYe.gameObject.SetActive(true);
            ImageTervis.gameObject.SetActive(false);
              ImageDrake.gameObject.SetActive(false);
                               ImageTyler.gameObject.SetActive(false);
                               ImageKendrick.gameObject.SetActive(false);

        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            ImageDrake.gameObject.SetActive(true);
                 ImageTervis.gameObject.SetActive(false);
                 ImageYe.gameObject.SetActive(false);
                 ImageTyler.gameObject.SetActive(false);
                 ImageKendrick.gameObject.SetActive(false);
        }

   if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            ImageDrake.gameObject.SetActive(false);
                 ImageTervis.gameObject.SetActive(false);
                 ImageYe.gameObject.SetActive(false);
                 ImageTyler.gameObject.SetActive(true);
                 ImageKendrick.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            ImageDrake.gameObject.SetActive(false);
                 ImageTervis.gameObject.SetActive(false);
                 ImageYe.gameObject.SetActive(false);
                 ImageTyler.gameObject.SetActive(false);
                 ImageKendrick.gameObject.SetActive(true);
        }
    }
}
