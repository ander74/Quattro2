using System;
using Android.Views;

namespace Quattro.Droid.Interfaces {


    public class GestureListener : GestureDetector.SimpleOnGestureListener {

        private const int SWIPE_THRESHOLD = 100;
        private const int SWIPE_VELOCITY_THRESHOLD = 100;

        private readonly Action onSwipeLeft;
        private readonly Action onSwipeRight;
        private readonly Action onSwipeTop;
        private readonly Action onSwipeBottom;

        public GestureListener(Action onSwipeLeft, Action onSwipeRight, Action onSwipeTop, Action onSwipeBottom) {
            this.onSwipeLeft = onSwipeLeft;
            this.onSwipeRight = onSwipeRight;
            this.onSwipeTop = onSwipeTop;
            this.onSwipeBottom = onSwipeBottom;
        }

        public override bool OnDown(MotionEvent e) {
            return true;
        }

        public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY) {
            bool result = false;
            try {
                float diffY = e2.GetY() - e1.GetY();
                float diffX = e2.GetX() - e1.GetX();
                if (Math.Abs(diffX) > Math.Abs(diffY)) {
                    if (Math.Abs(diffX) > SWIPE_THRESHOLD && Math.Abs(velocityX) > SWIPE_VELOCITY_THRESHOLD) {
                        if (diffX > 0) {
                            onSwipeRight?.Invoke();
                        } else {
                            onSwipeLeft?.Invoke();
                        }
                        result = true;
                    }
                    //} else if (Math.Abs(diffY) > SWIPE_THRESHOLD && Math.Abs(velocityY) > SWIPE_VELOCITY_THRESHOLD) {
                    //    if (diffY > 0) {
                    //        onSwipeBottom.Invoke();
                    //    } else {
                    //        onSwipeTop.Invoke();
                    //    }
                    //    result = true;
                }
            } catch (Exception e) {
                //exception.StackTrace;
            }
            return result;
        }
    }

}