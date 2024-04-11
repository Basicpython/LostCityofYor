using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectSaradomin : MonoBehaviour
{
    public TabletManager tabletManager;

    public Vector3 targetPosition = new Vector3(4.67f, 1.042f, 12.02f);
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

        GameObject socketObject = GameObject.FindGameObjectWithTag("sDet");
        XRSocketInteractor socketInteractor = socketObject.GetComponent<XRSocketInteractor>();

        if (distanceToTarget < positionRange)
        {
            if (other.CompareTag("SaradominTablet"))
            {
                tabletManager.saradominPlacedCorrect = true;
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
