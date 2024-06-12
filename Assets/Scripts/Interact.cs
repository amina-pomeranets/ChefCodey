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
                }
                else 
                {
                    print("Codey is empty handed!");
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
}
