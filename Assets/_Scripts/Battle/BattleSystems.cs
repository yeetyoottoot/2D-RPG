using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BattleSystems
{

    public static IEnumerator ActiveIndicator(this BattleMap bm, Card card)
    {
        Vector2 ogSize = card.Image.rectTransform.localScale;
        Color ogColor = card.Image.color;

        while (card == bm.ActiveCharacter)
        {
            yield return null;
            float scale = (Mathf.Sin(Time.time) * .15f) + .85f;
            card.SetImageSize(ogSize * scale)
                .SetImageColor(ogColor * new Color(scale, scale, .5f, 1));
        }

        card.SetImageSize(ogSize)
            .SetImageColor(ogColor);
    }


}