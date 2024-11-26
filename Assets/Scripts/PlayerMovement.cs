using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float jumpHeight = 2f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private float gravity = -9.81f;

    private void Start()
    {
        // Obtenir le composant CharacterController
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Permet de déplacer uniquement le joueur local
        if (IsOwner)
        {
            HandleMovement();
            HandleRotation();
        }
    }

    private void HandleMovement()
    {
        // Récupérer les entrées pour les mouvements
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou Flèches
        float vertical = Input.GetAxis("Vertical");     // W/S ou Flèches

        // Calculer la direction de déplacement
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Appliquer la vitesse de déplacement au CharacterController
        moveDirection *= moveSpeed;

        // Appliquer la gravité
        if (!controller.isGrounded)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        // Déplacer le CharacterController avec les nouvelles valeurs
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void HandleRotation()
    {
        // Récupérer les entrées de rotation (rotation du personnage en fonction de la souris)
        float rotationInput = Input.GetAxis("Mouse X");

        // Appliquer la rotation au joueur
        transform.Rotate(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
    }

    // Vous pouvez également ajouter un saut avec le CharacterController, si besoin
    public void Jump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
