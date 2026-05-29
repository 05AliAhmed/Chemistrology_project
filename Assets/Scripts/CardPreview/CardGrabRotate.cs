using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CardGrabRotate : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationAmount = 8f;
    [SerializeField] private float rotationSmoothness = 10f;

    private Camera mainCam;

    private bool isDragging;

    private Vector3 lastMousePos;

    private float targetRotX;
    private float targetRotY;

    private Quaternion originalRotation;

    private Collider col;

    private CardPreview _cardPreview;

    private void Awake()
    {
        mainCam = Camera.main;

        col = GetComponent<Collider>();

        _cardPreview = GetComponent<CardPreview>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHit();
        }

        if (!isDragging)
            return;

        //
        // KEEP ORIGINAL ROTATION
        //

        originalRotation = transform.rotation;

        Vector3 currentMousePos = Input.mousePosition;

        Vector3 delta = currentMousePos - lastMousePos;

        lastMousePos = currentMousePos;

        //
        // Mouse Y affects X rotation
        //

        // targetRotX -= delta.y * rotationAmount * Time.deltaTime;

        //
        // Mouse X affects Y rotation
        //

        targetRotY += delta.x * rotationAmount * Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(
            targetRotX,
            targetRotY,
            0f
        );

        Quaternion dragRotation = Quaternion.Euler(
            targetRotX,
            targetRotY,
            0f
        );

        Quaternion finalRotation =
            originalRotation * dragRotation;

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            finalRotation,
            rotationSmoothness * Time.deltaTime
        );

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    private void CheckHit()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //
            // Check if THIS collider is the first hit
            //

            if (hit.collider == col)
            {
                isDragging = true;

                lastMousePos = Input.mousePosition;
            }
            else
            {
                this.enabled = false;

                _cardPreview.ToggleCard();
            }
        }
        else
        {
            this.enabled = false;

            _cardPreview.ToggleCard();
        }
    }
}