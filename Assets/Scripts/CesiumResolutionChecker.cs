using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CesiumResolutionChecker : MonoBehaviour
{
    public Transform pointA; // Asigna dos puntos en la escena
    public Transform pointB;

    private float metrosPorPixel;

    void Update()
    {
        if (pointA == null || pointB == null || Camera.main == null)
            return;

        // 1. Distancia real en el mundo (en metros)
        float distanciaEnMetros = Vector3.Distance(pointA.position, pointB.position);

        // 2. Distancia en pantalla (en píxeles)
        Vector3 screenA = Camera.main.WorldToScreenPoint(pointA.position);
        Vector3 screenB = Camera.main.WorldToScreenPoint(pointB.position);

        float distanciaEnPixeles = Vector2.Distance(
            new Vector2(screenA.x, screenA.y),
            new Vector2(screenB.x, screenB.y)
        );

        // 3. Relación metros por píxel
        if (distanciaEnPixeles > 0)
            metrosPorPixel = distanciaEnMetros / distanciaEnPixeles;
    }

    void OnGUI()
    {
        GUIStyle estilo = new GUIStyle();
        estilo.fontSize = 20;
        estilo.normal.textColor = Color.white;

        GUI.Label(new Rect(20, 20, 500, 40), $"Resolución Cesium: {metrosPorPixel:F2} metros/pixel", estilo);
    }
}

