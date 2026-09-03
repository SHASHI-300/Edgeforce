using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class gunhovereffect : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 targetScale;

    [SerializeField] private TMP_Text pickupText;

    private void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;

        XRGrabInteractable grab =
            GetComponent<XRGrabInteractable>();

        if (grab != null)
        {
            grab.hoverEntered.AddListener(OnHoverEnter);
            grab.hoverExited.AddListener(OnHoverExit);
        }

        // Hide text at the beginning
        if (pickupText != null)
            pickupText.gameObject.SetActive(false);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        targetScale = originalScale * 1.2f;

        // SHOW only while pointing at gun
        if (pickupText != null)
            pickupText.gameObject.SetActive(true);
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        targetScale = originalScale;

        // HIDE when ray leaves gun
        if (pickupText != null)
            pickupText.gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.deltaTime * 5f
        );
    }

    private void OnDestroy()
    {
        XRGrabInteractable grab =
            GetComponent<XRGrabInteractable>();

        if (grab != null)
        {
            grab.hoverEntered.RemoveListener(OnHoverEnter);
            grab.hoverExited.RemoveListener(OnHoverExit);
        }
    }
}