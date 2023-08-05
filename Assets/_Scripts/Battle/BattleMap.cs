
using UnityEngine;

public class BattleMap
{
    public BattleMap(int noOfNME, int noOfPCs)//todo nme data and pc data
    {
        NMECount = noOfNME;
        PCCount = noOfPCs;
        _ = NMEs;
        _ = PCs;
    }

    readonly int NMECount;
    readonly int PCCount;

    private Transform _parent;
    public Transform Parent => _parent != null ? _parent : _parent = new GameObject(nameof(Parent)).transform;

    private Card[] _nmes;
    public Card[] NMEs => _nmes ??= SetUpNMEs();

    private Card[] SetUpNMEs()
    {
        Card[] nmes = new Card[NMECount];
        for (int i = 0; i < NMECount; i++)
        {
            nmes[i] = new Card(nameof(NMEs) + i, Parent)
                .SetImageColor(Color.red)
                .SetImageSize(Vector2.one)
                .SetImagePosition(new Vector3(Cam.Io.OrthoX() * .5f, Cam.Io.Camera.aspect + NMECount * .5f - i));
        }

        return nmes;
    }

    private Card[] _pcs;
    public Card[] PCs => _pcs ??= SetUpPCs();
    private Card[] SetUpPCs()
    {
        Card[] nmes = new Card[PCCount];
        for (int i = 0; i < PCCount; i++)
        {
            nmes[i] = new Card(nameof(PCs) + i, Parent)
                .SetImageColor(Color.cyan)
                .SetImageSize(Vector2.one)
                .SetImagePosition(new Vector3(Cam.Io.OrthoX() * -.5f, Cam.Io.Camera.aspect + PCCount * .5f - i));
        }

        return nmes;
    }
}

