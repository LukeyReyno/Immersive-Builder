using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using TMPro;

public class TriggerPlacement : MonoBehaviour
{
    public GameObject gameManagerObject;
    public ParticleSystem particle;
    public AudioSource clickAudioSource;
    public AudioSource positiveAudioSource;
    public TextMeshProUGUI congratsText;
    public float duration = 0.5f;

    public GameObject[] parts;

    private void Start()
    {
        congratsText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Triggered by " + other.transform.name);

        gameManagerObject.GetComponent<PlaceARObjectOnHand>().arObject = null;
        other.transform.parent = transform;
        other.GetComponent<BoxCollider>().isTrigger = false;
        particle.Play();
        clickAudioSource.PlayOneShot(clickAudioSource.clip, 1f);
        positiveAudioSource.PlayOneShot(positiveAudioSource.clip, 1f);

        if (other.transform.name == parts[0].name)  // motherboard
        {
            Tween.LocalPosition(other.transform, new Vector3(0.773f, -11.0312f, -1.179602f), duration, 0f);
            Tween.LocalRotation(other.transform, Vector3.zero, duration, 0f);
            StartCoroutine(AttachNewObjectToHand(1));
            
        }
        else if (other.transform.name == parts[1].name) // cpu
        {
            Tween.LocalPosition(other.transform, new Vector3(0.67067f, -10.48776f, -1.356764f), duration, 0f);
            Tween.LocalRotation(other.transform, new Vector3(90, 0, 0), duration, 0f);
            StartCoroutine(AttachNewObjectToHand(2));
        }
        else if (other.transform.name == parts[2].name) // m2
        {
            Tween.LocalPosition(other.transform, new Vector3(0.803924f, -11.13056f, -1.313646f), duration, 0f);
            Tween.LocalRotation(other.transform, Vector3.zero, duration, 0f);
            StartCoroutine(AttachNewObjectToHand(3));
        }
        else if (other.transform.name == parts[3].name) // ram
        {
            Tween.LocalPosition(other.transform, new Vector3(0.197757f, -10.48165f, -1.154988f), duration, 0f);
            Tween.LocalRotation(other.transform, Vector3.zero, duration, 0f);
            StartCoroutine(AttachNewObjectToHand(4));
        }
        else if (other.transform.name == parts[4].name) // rtx3080
        {
            Tween.LocalPosition(other.transform, new Vector3(0.6862f, -11.1488f, -0.8209801f), duration, 0f);
            Tween.LocalRotation(other.transform, new Vector3(90f, 0, 0), duration, 0f);
            StartCoroutine(AttachNewObjectToHand(5));
        }
        else if (other.transform.name == parts[5].name) // cooler
        {
            Tween.LocalPosition(other.transform, new Vector3(0.8642f, -10.58f, -0.75f), duration, 0f);
            Tween.LocalRotation(other.transform, new Vector3(-90f, 180f, 0), duration, 0f);
            StartCoroutine(AttachNewObjectToHand(6));
        }
        else if (other.transform.name == parts[6].name) // psu
        {
            Tween.LocalPosition(other.transform, new Vector3(1.534f, -13.279f, -0.948f), duration, 0f);
            Tween.LocalRotation(other.transform, new Vector3(0, 90f, 0), duration, 0f);
            StartCoroutine(AttachNewObjectToHand(7));
        }
        else if (other.transform.name == parts[7].name) // side panel
        {
            Tween.LocalPosition(other.transform, new Vector3(0.01f, -11.31f, 0.44f), duration, 0f);
            Tween.LocalRotation(other.transform, Vector3.zero, duration, 0f);
            congratsText.gameObject.SetActive(true);
        }
    }

    IEnumerator AttachNewObjectToHand(int objectNum)
    {
        yield return new WaitForSeconds(2);
        gameManagerObject.GetComponent<PlaceARObjectOnHand>().arObject = parts[objectNum];
    }
}
