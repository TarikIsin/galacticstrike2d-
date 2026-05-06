using UnityEngine;

public class BackgroundRepeating : MonoBehaviour
{
    [SerializeField] float height = 20.48f;
    void Update()
    {
        if (transform.position.y < -height)
        {
            PositionUpdate();
        }
    }

    private void PositionUpdate()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + height * 2,
            transform.position.z
        );
    }
}
