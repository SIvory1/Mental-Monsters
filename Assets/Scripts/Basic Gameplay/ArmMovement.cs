using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{

    public Animator armAnimator;
    public Movement playerMovement;

    public void ArmJump()
    {
        armAnimator.SetBool("IsArmJumping", true);
    }

    public void StopArmJump()
    {
        armAnimator.SetBool("IsArmJumping", false);
    }

    public void ArmRun()
    {
        armAnimator.SetFloat("ArmSpeed", playerMovement.moveX);
    }

}
