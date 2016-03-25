using UnityEngine;
using System.Collections;

public class Infection : MonoBehaviour 
{
    public Color infectedColor;
    private Color oldColor;
    private Material rendererMaterial;
    private float elapsedTime = 0.0f;

	void Start () 
    {
        // Get MeshRenderer
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        // Get reference to material attached to renderer
        if (renderer != null)
        {
            rendererMaterial = renderer.material;
            oldColor = rendererMaterial.color;
        }
	}
	
	void Update () 
    {
        // Slowly change old colour to infected colour
	    if (elapsedTime < 1.0f) {
            elapsedTime += Time.deltaTime;
            rendererMaterial.color = Color.Lerp(oldColor, infectedColor, elapsedTime);
        }
	}
}
