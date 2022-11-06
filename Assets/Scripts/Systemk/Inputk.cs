using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systemk {

    public class Inputk : Input {

        public static Vector2 GetAxis() {
            float x = 0f;
            float y = 0f;

            if (GetKey(KeyCode.W)) {
                y = 1f;
            }

            if (GetKey(KeyCode.S)) {
                y = -1f;
            }

            if (GetKey(KeyCode.A)) {
                x = -1f;
            }

            if (GetKey(KeyCode.D)) {
                x = 1f;
            }

            return new Vector2(x, y).normalized;
        }

    }

}