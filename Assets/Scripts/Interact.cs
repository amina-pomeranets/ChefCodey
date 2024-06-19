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
    public GameObject eggPrefab;
    public GameObject friedEggPrefab;

    public GameObject heldItem;
    public string heldItemName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Bread")
            {
                /*
                heldItem = Instantiate(breadPrefab, transform, true);
                heldItem.transform.localPosition = new Vector3(0, 2, 2);
                heldItemName = "breadSlice";
                */
                PickUpItem(breadPrefab, "breadSlice");
                heldItem.transform.localScale = new Vector3(16, 2, 16);
            }

            if (triggerName == "Egg")
            {
                PickUpItem(eggPrefab, "egg");
                heldItem.transform.localScale = new Vector3(0.5f, 0.7f, 0.5f);
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
                else if (heldItemName == "egg")
                {
                    stove.FryEgg();
                    PlaceHeldItem();
                }

                else 
                {
                    //print("not holding toast");
                    if (stove.cookedFood == "toast")
                    {
                        /*
                        print("toasted");
                        heldItem = Instantiate(breadPrefab, transform, false);
                        heldItem.transform.localPosition = new Vector3(0, 2, 2);
                        heldItem.transform.localScale = new Vector3(16, 2, 16);
                        heldItemName = "toastSlice";
                        stove.CleanStove();
                        */
                        PickUpItem(breadPrefab, "toastSlice");
                        heldItem.transform.localScale = new Vector3(16, 2, 16);
                        stove.CleanStove();
                    }

                    if (stove.cookedFood == "friedEgg")
                    {
                        PickUpItem(friedEggPrefab, "friedEgg");
                        //heldItem.transform.localScale = new Vector3(16, 2, 16);
                        stove.CleanStove();
                    }

                }
            }

            if (triggerName == "Receivers")
            {
                if (heldItemName == "toastSlice")
                {
                    Destroy(heldItem);
                    GameObject.Find("Receivers/French Toast/toastSlice").SetActive(true);
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

    private void PickUpItem(GameObject itemPrefab, string itemName)
    {
        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = new Vector3(0, 2, 2);
        heldItemName = itemName;
    }
}
