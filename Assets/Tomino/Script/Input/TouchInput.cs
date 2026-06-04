using UnityEngine;
using Tomino;

public class TouchInput : IPlayerInput
{
    public float blockSize;
    public bool Enabled
    {
        get => enabled;
        set
        {
            enabled = value;
            cancelCurrentTouch = false;
            playerAction = null;
        }
    }

    private Vector2 initialPosition = Vector2.zero;
    private Vector2 processedOffset = Vector2.zero;
    private PlayerAction? playerAction;
    private bool moveDownDetected;
    private float touchBeginTime;

    private readonly float tapMaxDuration = 0.35f;
    private readonly float tapMaxOffset = 30.0f;
    private readonly float swipeMaxDuration = 0.3f;

    private bool cancelCurrentTouch;
    private bool enabled = true;

    public void Update()
    {
        playerAction = null;

        if (!Enabled)
            return;

        if (Input.touchCount == 0)
        {
            cancelCurrentTouch = false;
            return;
        }

        Touch touch = Input.GetTouch(0);

        if (cancelCurrentTouch)
        {
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                cancelCurrentTouch = false;

            return;
        }

        switch (touch.phase)
        {
            case TouchPhase.Began:
                TouchBegan(touch);
                break;

            case TouchPhase.Moved:
            case TouchPhase.Stationary:
            {
                Vector2 offset = touch.position - initialPosition - processedOffset;
                HandleMove(touch, offset);
                break;
            }

            case TouchPhase.Ended:
            {
                float touchDuration = Time.time - touchBeginTime;
                Vector2 totalOffset = touch.position - initialPosition;

                bool isTap =
                    touchDuration <= tapMaxDuration &&
                    totalOffset.magnitude <= tapMaxOffset &&
                    !moveDownDetected;

                if (isTap)
                {
                    playerAction = PlayerAction.Rotate;
                }

                break;
            }

            case TouchPhase.Canceled:
                playerAction = null;
                break;
        }
    }

    public PlayerAction? GetPlayerAction()
    {
        return Enabled ? playerAction : null;
    }

    public void Cancel()
    {
        cancelCurrentTouch |= Input.touchCount > 0;
    }

    private void TouchBegan(Touch touch)
    {
        initialPosition = touch.position;
        processedOffset = Vector2.zero;
        moveDownDetected = false;
        touchBeginTime = Time.time;
    }

    private void HandleMove(Touch touch, Vector2 offset)
    {
        if (Mathf.Abs(offset.x) >= blockSize)
        {
            HandleHorizontalMove(touch, offset.x);
            playerAction = ActionForHorizontalMoveOffset(offset.x);
        }
        if (offset.y <= -blockSize)
        {
            HandleVerticalMove(touch);
            playerAction = PlayerAction.MoveDown;
        }
    }

    private void HandleHorizontalMove(Touch touch, float offset)
    {
        processedOffset.x += Mathf.Sign(offset) * blockSize;
        processedOffset.y = (touch.position - initialPosition).y;
    }

    private void HandleVerticalMove(Touch touch)
    {
        moveDownDetected = true;
        processedOffset.y -= blockSize;
        processedOffset.x = (touch.position - initialPosition).x;
    }

    private PlayerAction ActionForHorizontalMoveOffset(float offset)
    {
        return offset > 0 ? PlayerAction.MoveRight : PlayerAction.MoveLeft;
    }
}
