using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Collider playerCollider;
    private MeshRenderer playerMeshRenderer;
    private Material greenMaterial; // Material with a green color

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider>();
        playerMeshRenderer = GetComponent<MeshRenderer>();

        // Create a material with a green color
        greenMaterial = new Material(Shader.Find("Standard"));
        greenMaterial.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerCollider.enabled = !playerCollider.enabled;

            // Toggle the mesh color between green and the original material
            if (playerCollider.enabled)
            {
                playerMeshRenderer.material = greenMaterial; // Set to green material
            }
            else
            {
                // Revert to the default material (Unity's default gray material)
                playerMeshRenderer.material = new Material(Shader.Find("Standard"));
            }
        }
    }
}
