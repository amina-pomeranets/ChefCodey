using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Interact : MonoBehaviour
{

    public GameObject toast;

    public Stove stove;

    public string triggerName = "";

    public GameObject breadPrefab;

    public GameObject heldItem;
    public string heldItemName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Bread")
            {
                heldItem = Instantiate(breadPrefab, transform, true);
                heldItem.transform.localPosition = new Vector3(0, 2, 2);
                heldItemName = "breadSlice";
            }

            if (triggerName == "Stove")
            {
                print("I'm at the stove!");
                if (heldItemName == "breadSlice") 
                {
                    print("Ready to toast!");
                    Destroy(heldItem);
                    heldItemName = "";
                    toast.SetActive(true);
                    stove.ToastBread();
                }
                else 
                {
                    print("not holding toast");
                    if (stove.cookedFood == "toast")
                    {
                        print("toasted");
                        heldItem = Instantiate(breadPrefab, transform, false);
                        heldItem.transform.localPosition = new Vector3(0, 2, 2);
                        heldItem.transform.localScale = new Vector3(16, 2, 16);
                        heldItemName = "toastSlice";
                        stove.CleanStove();
                    }
                }
            }

            if (triggerName == "Receivers")
            {
                if (heldItemName == "toastSlice")
                {
                    Destroy(heldItem);
                    heldItemName = "";
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }

    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }
}
