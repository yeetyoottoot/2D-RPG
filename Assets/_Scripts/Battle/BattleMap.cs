
using UnityEngine;

public class BattleMap
{
    public BattleMap(Enemy nme, PlayerCharacter[] pcs)
    {
        NME = nme;
        PCs = pcs;
        _ = NMECard;
        _ = PCCards;
    }
    public void SelfDestruct() { Object.Destroy(_parent.gameObject); }

    public Enemy NME;
    public PlayerCharacter[] PCs;

    private Card _activeCharacter;
    public Card ActiveCharacter
    {
        get => _activeCharacter;
        set
        {
            if (_activeCharacter == value) return;
            _activeCharacter = value;
            this.ActiveIndicator(value).StartCoroutine();
        }
    }

    private Transform _parent;
    public Transform Parent => _parent != null ? _parent : _parent = new GameObject(nameof(Parent)).transform;

    private Card _nmeCard;
    public Card NMECard => _nmeCard ??= SetUpNMEs();

    private Card SetUpNMEs()
    {
        return new Card(nameof(NMECard), Parent)
                .SetImageColor(Color.red)
                .SetImageSize(Vector2.one)
                .SetImagePosition(new Vector3(Cam.Io.OrthoX() * .5f, 0))
                .ImageClickable();
    }

    private Card[] _pcCards;
    public Card[] PCCards => _pcCards ??= SetUpPCs();
    private Card[] SetUpPCs()
    {
        Card[] nmes = new Card[PCs.Length];
        for (int i = 0; i < PCs.Length; i++)
        {
            nmes[i] = new Card(nameof(PCCards) + i, Parent)
                .SetImageColor(Color.cyan)
                .SetImageSize(Vector2.one)
                .SetImagePosition(new Vector3(Cam.Io.OrthoX() * -.5f, Cam.Io.Camera.aspect + PCs.Length * .5f - i))
                .ImageClickable();
        }

        return nmes;
    }
}

