using UnityEngine;
using System.Collections;

public class DragnDrop : MonoBehaviour
{
    public GameObject effect;

    private Vector3 screenPosition;
    private Vector3 offset;
    private bool isMouseDrag;
    private GameObject target;

    private GameObject destination;
    private RaycastHit hitinfo;

    private Vector3 position;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);
            if (target != null && target.gameObject.tag == "PIECEMOVE")
            {
                position = target.transform.localPosition;
                isMouseDrag = true;
                Debug.Log("target position :" + target.transform.position);
                //Convert world position to screen position.

                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);

                offset = target.transform.position -

                    Camera.main.ScreenToWorldPoint

                    (new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (target != null && target.gameObject.tag == "PIECEMOVE")
            {
                RaycastHit hitInfo;
                destination = ReturnClickedObject(out hitInfo);
                //Debug.Log("destination name is =" + destination.name + " des tag is=" + destination.tag);
                if (destination != null && destination.gameObject.tag != "PIECEMOVE")
                {
                    if (target.gameObject.name == destination.gameObject.name)
                    {
                        target.gameObject.collider.enabled = false;
                        destination.gameObject.collider.enabled = false;
                        target.gameObject.transform.localPosition = destination.gameObject.transform.localPosition;

                        puzzleManager.getInstance.Game();

                        target.GetComponent<UISprite>().depth = 6;
                        GameObject obj = (GameObject)Instantiate(effect, destination.transform.position, Quaternion.identity);
                        obj.SetActive(true);
                        Destroy(obj, 1f);

                    }
                    else {
                        target.transform.localPosition = position;
                    }
                }
                else {
                    target.transform.localPosition = position;
                }
            }
            isMouseDrag = false;

        }

        if (isMouseDrag)
        {
            //track mouse position.

            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

            //convert screen position to world position with offset changes.

            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;    //오프셋을 더하지 않으면 오브젝트의 어느곳을 클릭 하더라도 드래그 상태에서 input.mouseposition의 중심에 오브젝트가 위치하게 됨

            //It will update target gameobject's current postion.

            target.transform.position = currentPosition;
        }
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}
