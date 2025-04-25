using UnityEngine;
using UnityEngine.UIElements;

public class MovingObjectTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TryGetComponent<Rigidbody>(out rb);
        target = PlayerController.Instance.gameObject.transform;
    }
    public float speed;

    Vector3 move;
    Rigidbody rb;
    public float radius;
    public float angle;
    Transform target;
    // Update is called once per frame
    void Update()
    {
        if (rb)
        {
            Vector3 MoveVec = speed * Time.deltaTime * Time.timeScale * transform.TransformDirection(move);

            //FOLLOWS PLAYER
            //rb.linearVelocity = new Vector3(MoveVec.x, 0, MoveVec.z);
            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            //ORBITS AN OBJECT IN CIRCULAR PATH
            float x = target.position.x + Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float y = target.position.y;
            float z = target.position.z + Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

            transform.position = new Vector3(x, y, z);
            angle += speed * Time.deltaTime;

            if (angle >= 360)
            {
                angle = 0;
            }

            //ROTATE TOWARDS THE TARGET
            Vector3 lookat = Vector3.RotateTowards(transform.forward, target.position - transform.position, speed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(lookat);

        }
    }
}
