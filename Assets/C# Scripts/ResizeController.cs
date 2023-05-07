using UnityEngine;

public class ResizeController : MonoBehaviour
{
    public float scaleFactor = 1f;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            // Get the touch positions
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Calculate the pinch distance
            float pinchDistance = Vector2.Distance(touch0.position, touch1.position);

            // Calculate the pinch delta
            float prevPinchDistance = Vector2.Distance(touch0.position - touch0.deltaPosition, touch1.position - touch1.deltaPosition);
            float pinchDelta = pinchDistance - prevPinchDistance;

            // Update the scale factor
            scaleFactor += pinchDelta * Time.deltaTime;

            // Clamp the scale factor
            scaleFactor = Mathf.Clamp(scaleFactor, 0.1f, 10f);
        }

        // Apply the scaling to the 3D model
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
}
