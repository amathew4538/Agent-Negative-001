using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandController : MonoBehaviour
{
    public float radius = 0.2f;
    public Camera mainCam;
    public Vector2 startVector;


    public void Start()
    {
        mainCam = Camera.main;
        startVector = new Vector2(0, 0);

        transform.position = startVector;
    }

    public void Update()
    {
        if (Mouse.current != null)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

            // Add depth so math stays consistent as camera moves
            float distanceFromCam = Mathf.Abs(mainCam.transform.position.z);
            Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, distanceFromCam));
            mouseWorldPos.z = 0;

            // Calc direction from Player
            Vector3 direction = mouseWorldPos - transform.parent.position;

            //  Clamp to radius
            if (direction.magnitude > radius)
            {
                direction = direction.normalized * radius;
            }

            // Update position relative to parent
            transform.position = transform.parent.position + direction;

            // Rotate
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

        }
    }
}