using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private GameObject splash;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "red")
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            base.GetComponent<Rigidbody>().AddForce(Vector3.down * 50, ForceMode.Impulse);
            HeartsFun(collision.gameObject);
            Destroy(base.gameObject,.1f);
            BallHandler.circleNo = 0;

        }
        else
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            GameObject go = Instantiate(splash) as GameObject;
            go.transform.parent = collision.gameObject.transform;
            Destroy(go, 0.1f);

            collision.gameObject.name = "color";
            collision.gameObject.tag = "red";
            StartCoroutine(ChangeColor(collision.gameObject));
        }
    }

    IEnumerator ChangeColor(GameObject g)
    {
        yield return new WaitForSeconds(0.1f);
        g.gameObject.GetComponent<MeshRenderer>().enabled = true;
        g.gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;
        Destroy(base.gameObject);
    }

    public void HeartsFun(GameObject g)
    {
        FindObjectOfType<BallHandler>().FailGame();
        FindObjectOfType<BallHandler>().HeartsLow();
        
    }

}
