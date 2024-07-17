using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public float GetMoveSpeed()
    {
        return this.moveSpeed;
    }
    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    [SerializeField] float dashingSpeed;
    public float GetDashingSpeed()
    {
        return dashingSpeed;
    }
    public void SetDashingSpeed(float dashingSpeed)
    {
        this.dashingSpeed = dashingSpeed;
    }

    [SerializeField] float dashingDuration;
    public float GetDashingDuration() { return dashingDuration; }
    public void SetDashingDuration(float dashingDuration) { this.dashingDuration = dashingDuration; }

    [SerializeField] float delayBetweenDashes;
    public float GetDelayBetweenDashes() { return delayBetweenDashes; }
    public void SetDelayBetweenDashes(float delayBetweenDashes) { this.delayBetweenDashes = delayBetweenDashes; }



    Rigidbody2D rb;
    [SerializeField] TrailRenderer tailRenderer;
    public TrailRenderer GetTailRenderer()
    {
        return tailRenderer;
    }
    public void SetTailRenderer(TrailRenderer tailRenderer)
    {
        this.tailRenderer = tailRenderer;
    }

    public void SetTrailRendererEmitting(bool emitting)
    {
        tailRenderer.emitting = emitting;
    }


    bool facingLeft;
    public bool GetFacingLeft()
    {
        return facingLeft;
    }
    public void SetFacingLeft(bool facingLeft)
    {
        this.facingLeft = facingLeft;
    }


    bool isDashing=false;
    public bool GetIsDashing()
    {
    return isDashing; 
    }
    public void SetIsDashing(bool isDashing)
    {
        this.isDashing = isDashing;
    }


    bool canDash=true;
    public bool GetCanDash() {
        return canDash;
    }
    public void SetCanDash(bool canDash) { this.canDash = canDash; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveTowards(Vector2 movement)
    {

        Vector2 delta2d = movement * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(transform.position + new Vector3(delta2d.x, delta2d.y, 0));

    }

    public void SetRotation(Vector3 rotation)
    {
        transform.eulerAngles = rotation;
    }


    public Vector3 GetRotation()
    {
        return transform.eulerAngles;
    }


    public Quaternion GetQuaternionRotation()
    {
        return transform.rotation;
    }


}
