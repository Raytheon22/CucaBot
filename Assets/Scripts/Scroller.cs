using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage Imagen;
    [SerializeField] private float _x, _y;

    void Update()
    {
        Imagen.uvRect = new Rect(Imagen.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, Imagen.uvRect.size);
    }
}
