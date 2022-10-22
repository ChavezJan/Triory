using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRenderQueue : MonoBehaviour
{

    public int queue;

    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        foreach (Material mat in renderer.materials)
        {
            mat.renderQueue = queue;
        }
    }
}
