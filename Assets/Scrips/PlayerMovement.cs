using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("Sensibilidad del Mouse")]
    public float mouseSensitivity = 200f;
    
    private float xRotation = 0f;
    private Transform cameraTransform;
    private Rigidbody rb;

    private bool estaEnSuelo = true;

    void Start()
    {
        // Localiza la cámara hija dentro del personaje
        cameraTransform = GetComponentInChildren<Camera>().transform;
        
        // Obtiene el componente de física asignado al cubo
        rb = GetComponent<Rigidbody>();
        
        // Bloquea el cursor en el centro de la pantalla de juego
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. ROTACIÓN CON EL MOUSE (MIRADA)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotar el cuerpo del jugador de izquierda a derecha en el eje Y
        transform.Rotate(Vector3.up * mouseX);

        // Rotar la cámara de arriba a abajo con límites angulares
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 2. MOVIMIENTO CON EL TECLADO (WASD / FLECHAS)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calcular dirección de movimiento relativa a la orientación del jugador
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        // 3. SALTO CON LA BARRA ESPACIADORA (SPACE)
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
        {
            // Aplica un impulso físico vertical inmediato
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            estaEnSuelo = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el jugador ha tocado el suelo para permitir saltar nuevamente
        if (collision.gameObject.CompareTag("Ground"))
        {
            estaEnSuelo = true;
        }
    }
}
