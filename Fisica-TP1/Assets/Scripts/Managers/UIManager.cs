using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            instance = FindObjectOfType<UIManager>();
            if (instance == null)
            {
                GameObject go = new GameObject("UIManager");
                instance = go.AddComponent<UIManager>();
            }
            return instance;
        }
    }
    [SerializeField] Slider sliderP1;
    [SerializeField] Slider sliderP2;

    public float SliderP1
    {
        get { return sliderP1.value; }
    }

    public float SliderP2
    {
        get { return sliderP2.value; }
    }
}