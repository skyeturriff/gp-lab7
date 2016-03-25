using UnityEngine;
using System.Collections;

public class Picking : MonoBehaviour
{
    public Camera pickingCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            // Creates a ray that is cast from the mouse's position into the world.
            Vector3 mousePosition = Input.mousePosition;
            Ray pickingRay = pickingCamera.ScreenPointToRay(mousePosition);

            // Use the ray to see if any object collides with it.
            RaycastHit hit;
            bool success = Physics.Raycast(pickingRay, out hit);

            if (success && hit.collider.gameObject.tag.Equals("Tooth"))
            {
                // Make object dissapear if hit
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
