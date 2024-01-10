using UnityEngine;

public class Aim : MonoBehaviour
{
    /*private bool aimVisivle = false;*/

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;

/*        if (Input.GetKey(KeyCode.Escape)) 
        {
            Cursor.visible = true;
            gameObject.SetActive(false);
        }*/

        /*if (aimVisivle == true)
        {
            Cursor.visible = true;
            gameObject.SetActive(false);
        }
        else if (aimVisivle == false)
        {
            gameObject.SetActive(true);
            Cursor.visible = false;
        }*/
    }
}
