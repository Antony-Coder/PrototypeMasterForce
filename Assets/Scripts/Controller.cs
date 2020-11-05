using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] private float nearClipPlane;
    [SerializeField] private float speed;
    [SerializeField] private float TurnSpeed;
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform forceObj;

    private float time = 0;
    private Vector3 touchPos;
    private Vector2 Begin;
    private Vector2 End;
    public static Vector2 dir { get; private set; }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal * TurnSpeed;
        transform.Translate(-direction * speed);

        //print("vertical"+ variableJoystick.Vertical +  "horizontal"+variableJoystick.Horizontal);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            time = 0;
            Vector2 mPos = Input.mousePosition;
            touchPos = camera.ScreenToWorldPoint(new Vector3(mPos.x, mPos.y, nearClipPlane));
            Begin = mPos;

        }

        if (Input.GetMouseButton(0))
        {
            time += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (time < 0.5f)
            {
                End = Input.mousePosition;

                dir = End - Begin;
                dir = dir.normalized;
                Force(dir);
               // print(dir);

            }
        }

        Debug.DrawLine(transform.position - Vector3.forward, touchPos, Color.green);
    }



    private void Force(Vector2 dir)
    {
        float angle = Vector2.Angle(Vector2.left, dir);

        //print(dir);

        if (dir.y < 0)
        {
            angle = 180 + (180 - angle);
        }


        forceObj.rotation = Quaternion.Euler(0,angle,0); 
        
        Vector3 begin = transform.position - Vector3.forward;
        Vector3 point;
        RaycastHit hit;


        if (Physics.Raycast(begin,touchPos-begin,out hit))
        {

            point = hit.point;



            point = new Vector3(point.x, 0.5f, point.z);
            forceObj.position = point;
        }

        forceObj.gameObject.SetActive(true);
        Invoke("OffParticle",0.8f);

    }

    public void OffParticle()
    {
        forceObj.gameObject.SetActive(false);
    }
}
