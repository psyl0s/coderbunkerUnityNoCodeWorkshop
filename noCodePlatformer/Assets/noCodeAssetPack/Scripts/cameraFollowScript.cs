using UnityEngine;

public class cameraFollowScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playerTarget;

    public float smoothSpeed = .125f;
    public Vector2 cameraLim = new Vector2();
    private Vector3 zero = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 finalPos = playerTarget.transform.position;
        finalPos.z -= 10;
        //Vector3 smoothPos = Vector3.Lerp(transform.position, finalPos, smoothSpeed);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, finalPos, ref zero, smoothSpeed);
        smoothPos.x = Mathf.Clamp(smoothPos.x, -cameraLim.x, cameraLim.x);
        smoothPos.y = Mathf.Clamp(smoothPos.y, -cameraLim.y, 100);
        transform.position = smoothPos;
    }
}
