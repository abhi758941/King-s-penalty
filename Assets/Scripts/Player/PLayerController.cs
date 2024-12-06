using UnityEngine;
using UnityEngine.InputSystem;

public class PLayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float clampX = 5f;
    [SerializeField] float clampZ = 5f;
    Vector2 movement;
    Rigidbody rigidBody;
    private void Awake() 
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() 
    {
        MovePlayer();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        
    }
    void MovePlayer()
    {
        Vector3 currentPostion = rigidBody.position;
        Vector3 moveDIrection = new Vector3(movement.x, 0 , movement.y);
        Vector3 newPosition = currentPostion + moveDIrection * (movementSpeed * Time.fixedDeltaTime);
        newPosition.x = Mathf.Clamp(newPosition.x,-clampX,clampX);
        newPosition.z = Mathf.Clamp(newPosition.z,-clampZ,clampZ);
        rigidBody.MovePosition(newPosition);
    }
    
}
