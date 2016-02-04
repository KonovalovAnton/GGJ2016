using UnityEngine;
using UnityEngine.UI;

public enum Swipe { None, Up, Down, Left, Right };

public class SwipeManager : MonoBehaviour
{
	public float minSwipeLength = 150f;
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	public static Swipe swipeDirection;
	public Drums drums;
	public Animator drummer;

	bool left = false;
	void Update ()
	{
		DetectSwipe();
	}

	public void DetectSwipe ()
	{
		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch(0);

			if (t.phase == TouchPhase.Began) {
				firstPressPos = new Vector2(t.position.x, t.position.y);
			}

			if (t.phase == TouchPhase.Ended) {
				secondPressPos = new Vector2(t.position.x, t.position.y);
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

				// Make sure it was a legit swipe, not a tap
				if (currentSwipe.magnitude < minSwipeLength) {
					swipeDirection = Swipe.None;
					return;
				}

				currentSwipe.Normalize();

				if (left) {
					drummer.SetTrigger ("LEFT");
					left ^= true;
				} else {
					drummer.SetTrigger ("RIGHT");
					left^=true;
				}
				// Swipe up
				if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					swipeDirection = Swipe.Up;
					QTEController.instance.TakeInput(0);
					drums.PlayDrum(0);

					// Swipe down
				} else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f  && currentSwipe.x < 0.5f) {
					swipeDirection = Swipe.Down;
					QTEController.instance.TakeInput(2);
					drums.PlayDrum(2);
					// Swipe left
				} else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					swipeDirection = Swipe.Left;
					QTEController.instance.TakeInput(3);
					drums.PlayDrum(3);
					// Swipe right
				} else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f  && currentSwipe.y < 0.5f) {
					swipeDirection = Swipe.Right;
					QTEController.instance.TakeInput(1);
					drums.PlayDrum(1);
				}
			}
		} else {
			swipeDirection = Swipe.None;   
		}
	}
}