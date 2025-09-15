using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageController :MonoBehaviour, IPointerClickHandler
{

    public Image imagenGrande;
    public Image imagenPequeña;
    [HideInInspector] public bool ActivoPequeña;
    
    private Sprite[] imagenes;
    private int index = 0;

    void Start()
    {
        imagenes = Resources.LoadAll<Sprite>("Imagenes");

    }


    void AvanzarImagen()
    {
        if (index < imagenes.Length - 1)
        {
            index++;
            imagenGrande.sprite = imagenes[index];
            imagenPequeña.sprite = imagenes[index];
        }
    }

    void RegresarImagen()
    {
        if (index > 0)
        {
            index--;
            imagenGrande.sprite = imagenes[index];
            imagenPequeña.sprite = imagenes[index];
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        if (Input.GetMouseButtonDown(0)) // Detecta clic izquierdo
        {
            Debug.Log("Boton pulsado");
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPosition = new Vector2(worldPoint.x, worldPoint.y);

            Collider2D hitCollider = Physics2D.OverlapPoint(clickPosition);

            if (hitCollider != null)
            {
                Debug.Log("Clic dentro de un collider");
                if (ActivoPequeña)
                {
                    if (hitCollider.gameObject.name == "ImagePequeña")
                    {
                        Debug.Log("Clic dentro del spritePequeño en posición: " + clickPosition);
                    }
                }
                else
                {
                    if (hitCollider.gameObject.name == "ImageGrande")
                    {
                        Debug.Log("Clic dentro del spriteGrande en posición: " + clickPosition);
                    }
                }
            }
        }
        
    }
    
    public void ChangeActivoPequeña()
    {
        ActivoPequeña = !ActivoPequeña;
    }
}

