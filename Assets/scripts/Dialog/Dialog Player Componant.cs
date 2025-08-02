using UnityEngine;

public class DialogPlayerComponant : MonoBehaviour
{

    //this componant is attached to the player
    // so the player will just be the one who check on trigger instead of each npc for performance
    //player component will access the dialouge component on the npc and get the lines and name of the npc

    public KeyCode keyToPress = KeyCode.E;
    public string NpcTag = "Npc";
    private bool NpcInside = false;
    private DialogComponont dialogComponant = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(NpcTag))
        {
            NpcInside = true;
            dialogComponant = collision.GetComponent<DialogComponont>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(NpcTag))
        {
            NpcInside = false;
            dialogComponant = null;
        }
    }

    private void Update()
    {
        if (!NpcInside) return;
        if (DialogManager.Instance.IsDialogActive()) return;
        if (Input.GetKeyDown(keyToPress)&& dialogComponant != null)
        {
            DialogManager.Instance.SetDialogActive(dialogComponant.lines, dialogComponant.NpcName);
        }
    }

  
}
