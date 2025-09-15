using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Campo : MonoBehaviour
{
    public List<Hoyo> hoyos = new List<Hoyo>();
    public int numeroHoyo ;
    
    public Camera mainCamera;

    public Button botonHoyoX;
    public Image imagenVerticalPequeña;

    public Image imagenVerticalGrande;
    

    public void AvanzarHoyo()
    {
        if (numeroHoyo < 18)
        {
            Debug.Log("Avanzando al hoyo " + (numeroHoyo + 1));
            // Desactiva el hoyo actual
            hoyos[numeroHoyo-1].gameObject.SetActive(false);
            numeroHoyo++;
            // Activa el siguiente hoyo
            hoyos[numeroHoyo-1].gameObject.SetActive(true);
            // Mueve la cámara a la posición del nuevo hoyo
            
            MoverHoyo();
            
        }
    }
    
    public void RetrocederHoyo()
    {
        Debug.Log("retroceder hoyo");
        if (numeroHoyo > 1)
        {
            Debug.Log("Retrocediendo al hoyo " + (numeroHoyo - 1));
            // Desactiva el hoyo actual
            hoyos[numeroHoyo-1].gameObject.SetActive(false);
            numeroHoyo--;
            // Activa el hoyo anterior
            hoyos[numeroHoyo-1].gameObject.SetActive(true);
            // Mueve la cámara a la posición del nuevo hoyo
            
            MoverHoyo();
        }
    }
    
    public void CambiarHoyo(int nuevoHoyo)
    {
        if (nuevoHoyo >= 1 && nuevoHoyo <= hoyos.Count)
        {
            // Desactiva el hoyo actual
            hoyos[numeroHoyo-1].gameObject.SetActive(false);
            numeroHoyo = nuevoHoyo;
            // Activa el nuevo hoyo
            hoyos[numeroHoyo-1].gameObject.SetActive(true);
            // Mueve la cámara a la posición del nuevo hoyo
            
            MoverHoyo();
        }
    }
    private void MoverHoyo()
    {
        if (mainCamera != null)
        {
            mainCamera.transform.position = hoyos[numeroHoyo-1].posiciónInicial;
        }
        if(botonHoyoX != null)
        {
            var textMeshPro = botonHoyoX.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = "Hoyo " + numeroHoyo;
            }
            else
            {
                Debug.LogError("No se encontró el componente TextMeshProUGUI en el botón.");
            }
        }
        if (imagenVerticalPequeña != null && hoyos[numeroHoyo-1].ImagenVertical != null && imagenVerticalGrande != null)
        {
            String rutaImagen = "Images/"+hoyos[numeroHoyo-1].ImagenVertical;
            imagenVerticalPequeña.sprite = Resources.Load<Sprite>(rutaImagen);
            imagenVerticalGrande.sprite = Resources.Load<Sprite>(rutaImagen);
        }
    }

    public void CambiarPersona()
    {
        var vector3 = mainCamera.transform.position;
        vector3.y = 78.15f + 1.5f;
        mainCamera.transform.position = vector3;
    }

    public void CambiarPajaro()
    {
        var vector3 = mainCamera.transform.position;
        vector3.y = 78.15f + 10f;
        mainCamera.transform.position = vector3;
    }
}
