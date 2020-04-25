using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public Animator animator;
    public GameObject dialogManager;
    public DialogueTrigger trigger;


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    [Header("Events")]
	[Space]

    public UnityEvent OnFireEndEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    private void Awake()
    {
        FindObjectOfType<DialogueTrigger>();

        if (OnFireEndEvent == null)
            OnFireEndEvent = new UnityEvent();
    }
    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Delay());
        if (Input.GetButton("Fire1"))
        {
            Shoot();
            animator.SetBool("IsFiring", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            Kill();
            animator.SetBool("IsFiring", false);
        }
    }

    void Shoot()
    {
        //StartCoroutine(Delay());
        muzzleFlashPrefab.SetActive(true);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        StartCoroutine(Delay());
        //Destroy();
    }

    void Kill()
    {
        muzzleFlashPrefab.SetActive(false);
    }
}
