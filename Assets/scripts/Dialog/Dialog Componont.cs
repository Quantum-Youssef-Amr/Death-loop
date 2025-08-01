using UnityEngine;
using TMPro;
using System.Collections;

public class DialogComponont : MonoBehaviour
{
    public string NpcName;
    public string[] lines;
    public KeyCode keyToPress = KeyCode.KeypadEnter;
    public string TagToDetect = "Player";
    private bool playerInside = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagToDetect))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(TagToDetect))
        {
            playerInside = false;
        }
    }

    private void Update()
    {
        if (!playerInside) return;
        if (DialogManager.Instance.IsDialogActive()) return;
        Debug.Log(Input.GetKeyDown(keyToPress));
        if (Input.GetKeyDown(keyToPress))
        {
            DialogManager.Instance.SetDialogActive(lines, NpcName);
        }
    }



}
