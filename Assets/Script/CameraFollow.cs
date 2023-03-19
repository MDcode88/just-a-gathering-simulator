using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;
    public float damping = 2.0f;
    public float rotationDamping = 5.0f;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 wantedPosition = target.TransformPoint(0, height, -distance);
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
    }
}
