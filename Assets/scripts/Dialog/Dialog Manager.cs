using UnityEngine;
using TMPro;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    // set that class on an empty game object and the canves with textbox under it

    public TextMeshProUGUI dialogText;  // text component
    public TextMeshProUGUI nameText;
    public GameObject dialogBox;  // dialog box
    public float textSpeed = 0.3f;  // the spped that the text will appear

    private string[] lines; // will hold the dialuge lines from the npc
    private int index;

    private bool dialogActive = false;
    private static DialogManager s_instance;
    public static DialogManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = FindFirstObjectByType<DialogManager>();
            }
            return s_instance;
        }
    }

    void Start()
    {
        dialogBox.SetActive(false);
    }


    void Update()
    {
        if (!dialogActive) return;
        
        if(Input.GetMouseButtonDown(0))
        {
            if(dialogText.text == lines[index])
            {
                NextLine();
            }
            else                                                // if the text is not complete complete it else go to the next line
            {
                StopAllCoroutines();
                dialogText.text = lines[index];
            }
        }

        EndDialouge();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);         // to appear the text letter by letter
        }
    }

    void NextLine()
    {
        if(index < lines.Length-1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogText.text = "";
            index++;
        }
    }

    void EndDialouge()         
    {
        if(index >= lines.Length)
        {
            dialogActive = false;
            index = 0;
            lines = null;
            dialogText.text = "";
            nameText.text = "";
            dialogBox.SetActive(false);

        }
    }

    public void SetLines(string[] newLines)
    {
        lines = newLines;
    }

    public bool IsDialogActive()
    {
        return dialogActive;
    }

    public void SetDialogActive(string[] lines,string name)
    {
       
        dialogBox.SetActive(true);
        dialogActive = true;
        nameText.text = name;
        index = 0;
        SetLines(lines);
        StartDialogue();
    }
}
