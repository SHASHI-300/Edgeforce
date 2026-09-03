using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MatchingScript : XRSocketInteractor
{
    public string socketName;

    protected override void Start()
    {
        base.Start();
        socketName = this.gameObject.name;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && socketName == interactable.transform.name;
    }

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && socketName == interactable.transform.name;
    }
}








//Socket script for matching name(Xr socket Interactor)