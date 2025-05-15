using UnityEngine;

[ExecuteAlways]
public class Reveal : MonoBehaviour
{
    [SerializeField] private Material mat;
    [SerializeField] private Light spotLight;

    private void Update()
    {
        if (mat == null || spotLight == null)
            return;

        if (spotLight.type != LightType.Spot)
        {
            Debug.LogWarning("La luz asignada no es un spotlight. Cambia el tipo de luz.");
            return;
        }

        // Pasamos parámetros al shader
        mat.SetVector("_LightPos", spotLight.transform.position);
        mat.SetVector("_LightDir", -spotLight.transform.forward);
        mat.SetFloat("_LightAngle", spotLight.spotAngle);
    }
}
