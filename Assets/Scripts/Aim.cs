using UnityEngine;

public class Aim : MonoBehaviour
{
    private bool aimVisivle = false;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;
    }

    internal void CurVis()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            aimVisivle = !aimVisivle;
        }

        if (aimVisivle == true)
        {
            Cursor.visible = true;
            gameObject.SetActive(false);
        }
        else if (aimVisivle == false)
        {
            Cursor.visible = false;
            gameObject.SetActive(true);
        }
    }
}
