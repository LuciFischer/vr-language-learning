using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    private Collider thisObject;
    private int points = 0;

    public float movementSpeed = 10;
    public float topBound = 30;
    public float bottomBound = -20;

    void Start() {
        thisObject = gameObject.GetComponent<Collider>();
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed*-1);

        /*if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        } else if (transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }*/
    }

    //Steuerung mit der Maus muss durch Steuerung mit den VR Controllern ersetzt werden
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    
    }
    
    //Steuerung mit der Maus muss durch Steuerung mit den VR Controllern ersetzt werden
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    
    }

     private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Bucket_der") && thisObject.CompareTag("der")) || (other.CompareTag("Bucket_die") && thisObject.CompareTag("die")) || (other.CompareTag("Bucket_das") && thisObject.CompareTag("das")))
        {
            //Fehler bei der Punktezaehlung. Bleibt immer bei 1 haengen
            points++;
            Debug.Log("Richtig! Sie haben " + points + " Punkte.");
            gameObject.SetActive(false);
        }

        if ((other.CompareTag("Bucket_der") && thisObject.CompareTag("die")) || (other.CompareTag("Bucket_der") && thisObject.CompareTag("das")) || (other.CompareTag("Bucket_die") && thisObject.CompareTag("der")) || (other.CompareTag("Bucket_die") && thisObject.CompareTag("das")) || (other.CompareTag("Bucket_das") && thisObject.CompareTag("der")) || (other.CompareTag("Bucket_das") && thisObject.CompareTag("die")))
        {
            Debug.Log("Leider falsch");
        }
    }
}
