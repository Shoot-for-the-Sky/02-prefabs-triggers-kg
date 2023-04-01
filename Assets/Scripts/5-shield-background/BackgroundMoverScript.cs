using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoverScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Renderer backgroundRenderer;

    // Update is called once per frame
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
