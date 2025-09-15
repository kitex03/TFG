using TMPro;
using UnityEngine;
using CesiumGlobeAnchor = CesiumForUnity.CesiumGlobeAnchor;

public class Obstaculo: MonoBehaviour
{
    // public CesiumGlobeAnchor anchorA;
    // public CesiumGlobeAnchor anchorB;
    public TextMeshPro distanceText;

    void Start()
    {
        /*// Example: Automatically find anchors if not assigned
        if (anchorA == null)
        {
            anchorA = GetComponent<CesiumGlobeAnchor>();
            if (anchorA == null)
            {
                Debug.LogError("AnchorA is not assigned and no CesiumGlobeAnchor found on this GameObject.");
            }
        }

        if (anchorB == null)
        {
            // Replace with logic to find or assign anchorB, e.g., by tag or name
            Debug.LogWarning("AnchorB is not assigned. Please assign it in the Inspector.");
        }*/
    }
    
    void Update()
    {
        // if (anchorA != null && anchorB != null)
        // {
            //double distance = CalculateGeodeticDistance(anchorA, anchorB);
            if (distanceText != null)
            {
                double distance = 139;
                // Actualiza el texto con la distancia
                distanceText.text = ((int)distance).ToString();
                

                // Cambia el tamaño y la altura según la distancia
                float maxDistance = 50f; // Distancia máxima para tamaño y altura máximos
                float minScale = 0.5f; // Escala mínima
                float maxScale = 2f; // Escala máxima

                // Calcula la escala basada en la distancia
                float scale = Mathf.Lerp(minScale, maxScale, Mathf.Clamp01((float)distance / maxDistance));
                distanceText.rectTransform.localScale = new Vector3(scale, scale, scale);

                // Cambia la altura (posición Y) basada en la distancia
                float minHeight = 9; // Altura mínima
                float maxHeight = 10; // Altura máxima
                float height = Mathf.Lerp(minHeight, maxHeight, Mathf.Clamp01((float)distance / maxDistance));
                distanceText.rectTransform.localPosition = new Vector3(
                    distanceText.rectTransform.localPosition.x,
                    height,
                    distanceText.rectTransform.localPosition.z
                );
                
                Vector3 direction = distanceText.rectTransform.position - Camera.main.transform.position;
                distanceText.rectTransform.rotation = Quaternion.LookRotation(direction);
            }
        //}
    }

    private double CalculateGeodeticDistance(CesiumGlobeAnchor a, CesiumGlobeAnchor b)
    {
        var geoA = a.longitudeLatitudeHeight;
        var geoB = b.longitudeLatitudeHeight;

        double lat1 = geoA.y * Mathf.Deg2Rad;
        double lon1 = geoA.x * Mathf.Deg2Rad;
        double lat2 = geoB.y * Mathf.Deg2Rad;
        double lon2 = geoB.x * Mathf.Deg2Rad;

        double dLat = lat2 - lat1;
        double dLon = lon2 - lon1;

        double aHarv = Mathf.Sin((float)(dLat / 2)) * Mathf.Sin((float)(dLat / 2)) +
                       Mathf.Cos((float)lat1) * Mathf.Cos((float)lat2) *
                       Mathf.Sin((float)(dLon / 2)) * Mathf.Sin((float)(dLon / 2));

        double c = 2 * Mathf.Atan2(Mathf.Sqrt((float)aHarv), Mathf.Sqrt((float)(1 - aHarv)));

        double surfaceDistance = 6371000.0 * c; // Radio medio de la Tierra en metros

        return surfaceDistance;
    }
}
