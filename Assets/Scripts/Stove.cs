using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject toast;
    public GameObject friedEgg;

    [Header("Inventory")]
    public string cookedFood = "";

    [Header("Particles")]
    public ParticleSystem smoke;
    public ParticleSystem complete;

    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
    }

    public void ToastBread()
    {
        smoke.Play();
        toast.SetActive(true);
        cookedFood = "toast";
    }

    public void FryEgg()
    {
        smoke.Play();
        friedEgg.SetActive(true);
        cookedFood = "friedEgg";
    }

    public void CleanStove()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
        cookedFood = "";
    }
}