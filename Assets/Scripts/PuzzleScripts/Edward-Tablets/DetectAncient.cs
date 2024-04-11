using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class DetectAncient : MonoBehaviour
{
    public TabletManager tabletManager;
    public SoundManager soundManager;

    public Vector3 targetPosition = new Vector3(4.67f, 1.042f, 9.89f);
    public float positionRange = 0.01f;
    public float delay = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CheckPositionAfterDelay(other));
    }

    private IEnumerator CheckPositionAfterDelay(Collider other)
    {
        yield return new WaitForSeconds(delay);

        float distanceToTarget = Vector3.Distance(other.transform.position, targetPosition);

        GameObject socketObject = GameObject.FindGameObjectWithTag("aDet");
        XRSocketInteractor socketInteractor = socketObject.GetComponent<XRSocketInteractor>();

        if (distanceToTarget < positionRange)
        {
            soundManager.Play(SoundCat.STONE_SET_DOWN);
            if (other.CompareTag("AncientTablet"))
            {
                tabletManager.ancientPlacedCorrect = true;
                XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();              
                grabInteractable.enabled = false;

                socketInteractor.enabled = false;

                Rigidbody rigidbody = other.GetComponent<Rigidbody>();
                rigidbody.isKinematic = true;
            }
            else
            {
                socketInteractor.enabled = false;

                tabletManager.ResetTabletPosition(other.gameObject);

                socketInteractor.enabled = true;
            }
        }
    }
}

