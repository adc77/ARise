using UnityEngine;

public class ModelController : MonoBehaviour
{
    private float rotateSpeed = 5f;
    private float pinchSpeed = 0.05f;
    private float minPinchScale = 0.5f;
    private float maxPinchScale = 2f;
    private Vector2 prevPos1;
    private Vector2 prevPos2;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            // Rotate the model on the Y axis
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Rotate(0f, -touchDeltaPosition.x * rotateSpeed, 0f, Space.World);
            }
        }

        if (Input.touchCount == 2)
        {
            // Pinch to zoom the model
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 pos1 = touch1.position;
            Vector2 pos2 = touch2.position;

            if (touch2.phase == TouchPhase.Began)
            {
                prevPos1 = pos1;
                prevPos2 = pos2;
            }

            float prevPinchDistance = Vector2.Distance(prevPos1, prevPos2);
            float pinchDistance = Vector2.Distance(pos1, pos2);

            float deltaDistance = pinchDistance - prevPinchDistance;
            float pinchAmount = deltaDistance * pinchSpeed;

            float scaleAmount = transform.localScale.x + pinchAmount;

            scaleAmount = Mathf.Clamp(scaleAmount, minPinchScale, maxPinchScale);

            transform.localScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);

            // Rotate the model on the X and Y axes
            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float angle1 = Mathf.Atan2(prevPos2.y - prevPos1.y, prevPos2.x - prevPos1.x) * Mathf.Rad2Deg;
                float angle2 = Mathf.Atan2(pos2.y - pos1.y, pos2.x - pos1.x) * Mathf.Rad2Deg;

                transform.rotation *= Quaternion.Euler(0f, (angle2 - angle1) * 0.5f, 0f);
            }

            prevPos1 = pos1;
            prevPos2 = pos2;
        }
    }
}
