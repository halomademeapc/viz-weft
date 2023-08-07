using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    [SerializeField] private Vector3 maxRotationChange;
    [SerializeField] private Vector3 maxPositionChange;
    [SerializeField] private Vector3 minPosition;
    [SerializeField] private Vector3 maxPosition;
    [SerializeField] private float smoothing = .001f;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        BeginNewShot();
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.SetPositionAndRotation(
            Vector3.Lerp(camera.transform.position, targetPosition, smoothing),
            Quaternion.Lerp(camera.transform.rotation, targetRotation, smoothing)
            );
    }

    public void BeginNewShot()
    {
        var startPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z));
        var displacement = new Vector3(
            Random.Range(-1 * maxPositionChange.x, maxPositionChange.x),
            Random.Range(-1 * maxPositionChange.y, maxPositionChange.y),
            Random.Range(-1 * maxPositionChange.z, maxPositionChange.z));
        targetPosition = startPosition + displacement;
        var startRotation = Random.rotation;
        targetRotation = startRotation * Quaternion.Euler(
            Random.Range(-1 * maxRotationChange.x, maxRotationChange.x),
            Random.Range(-1 * maxRotationChange.y, maxRotationChange.y),
            Random.Range(-1 * maxRotationChange.z, maxRotationChange.z)
            );
        camera.transform.SetPositionAndRotation(startPosition, startRotation);
        Invoke(nameof(BeginNewShot), 5);
    }
}
