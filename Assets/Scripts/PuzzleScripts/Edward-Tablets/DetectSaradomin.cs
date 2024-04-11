using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectSaradomin : MonoBehaviour
{
    public TabletManager tabletManager;
    public SoundManager soundManager;

    // targetPosition represents socket area
    public Vector3 targetPosition = new Vector3(4.6937f, 1.1525f, 12.0591f);
    public float positionRange = 0.1f;
    public float delay = 0.1f;

    // Add a delay so detection is smoother
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CheckPositionAfterDelay(other));
    }

    private IEnumerator CheckPositionAfterDelay(Collider other)
    {
        yield return new WaitForSeconds(delay);
        // Provide slight wiggle room. Make requirement less strict fot target area
        float distanceToTarget = Vector3.Distance(other.transform.position, targetPosition);

        GameObject socketObject = GameObject.FindGameObjectWithTag("sDet");
        XRSocketInteractor socketInteractor = socketObject.GetComponent<XRSocketInteractor>();

        if (distanceToTarget < positionRange)
        {
            soundManager.Play(SoundCat.STONE_SET_DOWN);
            if (other.CompareTag("SaradominTablet"))
            {
                tabletManager.saradominPlacedCorrect = true;
                // Disable Components
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
