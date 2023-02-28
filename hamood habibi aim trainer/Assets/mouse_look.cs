using UnityEngine;

public class mouse_look : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    float RotationX = 0f;
    public Transform playerBody;

    public Camera fpsCam;
    public Points points;
    public AudioSource mp3;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        RotationX -= mouseY;
        RotationX = Mathf.Clamp(RotationX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(RotationX, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        mp3.time = 0.1f;
        mp3.pitch = Random.Range(0.5f,1.3f);
        mp3.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 1000))
        {
            if (hit.transform.name != "Baseplate") {
                Destroy(hit.transform.gameObject);
                points.AddPoints(1);
            }
            else
            {
                points.AddPoints(-1);
            }
        }
    } 
}
