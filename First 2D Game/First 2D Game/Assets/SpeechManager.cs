using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text nameText;
    public Text dialogText;
    private bool dialogActive=false;

    private Queue<string> sentences;

    //public bool dialogActive;

    [Header("Dialogues")]
    [Space()]
    public string characterName;

    [TextArea(5,10)]
    public string[] dialogues;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            dialogBox.SetActive(false);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            dialogBox.SetActive(true);
            if (dialogActive == true)
            {
                DisplayNextSentence();
            }
            if (dialogActive == false)
            {
                StartDialogue();
                dialogActive = true;
            }
        }
    }

    void StartDialogue()
    {
        //sentences.Clear();

        nameText.text = characterName;

        foreach (string sentence in dialogues)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndOfDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }
    public void EndOfDialogue()
    {
        dialogBox.SetActive(false);
    }
}
