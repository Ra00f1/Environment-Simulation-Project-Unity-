using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChanger : MonoBehaviour
{
    private int Layerint;

    void Start()
    {
        Layerint = LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.layer = Layerint;
        }
    }
}