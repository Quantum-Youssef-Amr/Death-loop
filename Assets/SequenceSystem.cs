using UnityEngine;
using System.Collections.Generic;

public class SequenceSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerInputSystem inputSystem;
    public List<PlayerPoints> pl_sequence = new List<PlayerPoints>();
    bool triggerEnter;
    private int currentIndex = 0;
    private CharacterController controller;
    public bool TriggerEnter { get => triggerEnter; set => triggerEnter = value; }
    public float reachThreshold = 0.1f;
    Animator anim;
    public GameObject player;
    private void Awake()
    {
        inputSystem = player.GetComponent<PlayerInputSystem>();
        controller = player.GetComponent<CharacterController>();

    }
    private void Start()
    {

    }
    
   
    void Update()
    {
        if (pl_sequence.Count == 0 || currentIndex >= pl_sequence.Count)
        {
            inputSystem.enabled = true;
            return;
        }
        if(triggerEnter)
        {
            inputSystem.enabled = false;
            SequenceStart();
        }
     
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEnter = true;
        }
    }
    public void SequenceStart()
    {
        PlayerPoints point = pl_sequence[currentIndex];
        Vector3 direction = (point.targetPoint.position - player.transform.position).normalized;
        controller.Move(direction * point.moveSpeed * Time.deltaTime);
        float distance = Vector3.Distance(player.transform.position, point.targetPoint.position);
        if (distance < reachThreshold)
        {
            currentIndex++;
            if (currentIndex < pl_sequence.Count)
                PlayAnimationForCurrentStep();
        }

    }

    void PlayAnimationForCurrentStep()
    {
        if (anim == null) return;
        string animName = pl_sequence [currentIndex].animationName;
        if (!string.IsNullOrEmpty(animName))
        {
            anim.Play(animName);
        }
    }
}
[System.Serializable]
public class PlayerPoints
{
    public Transform targetPoint;
    public float moveSpeed = 2f;
    public string animationName;
    public  bool stop;
}
