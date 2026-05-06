using UnityEngine;

public class ObjcetMover : MonoBehaviour
{
    [SerializeField] float speed ;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
