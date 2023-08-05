using UnityEngine;
using MusicTheory.Rhythms;
using MusicTheory.Harmony;

public class Riff
{
    /// <summary>
    /// Does the audioclip start before the downbeat.
    /// </summary>
    public bool HasPickup => StartBeat.MeasureNumber == 0;
    /// <summary>
    /// Length of riff disregarding any leading or trailing audio.
    /// </summary>
    public double LengthInSec => (EndBeat.BeatValue - StartBeat.BeatValue) / 12 * (60 / BPM);
    public int BPM { get; private set; }
    public Genre Genre;
    public Instrument Instrument;
    public Tonality Tonality { get; private set; }
    public AudioClip AudioClip { get; private set; }
    /// <summary>
    /// The beat where the Riff starts.
    /// </summary>
    public BeatLocation StartBeat { get; private set; } = BeatLocation.DownBeat;
    /// <summary>
    /// (Exclusive) The beat where the Riff ends.
    /// </summary>
    public BeatLocation EndBeat { get; private set; } = BeatLocation.OneBarThenOff;

    public Riff SetBPM(int bpm) { BPM = bpm; return this; }
    public Riff SetGenre(Genre genre) { Genre = genre; return this; }
    public Riff SetInstrument(Instrument instrument) { Instrument = instrument; return this; }
    public Riff SetTonality(Tonality tonality) { Tonality = tonality; return this; }
    public Riff SetAudioClip(AudioClip audioClip) { AudioClip = audioClip; return this; }
    public Riff SetStartBeat(BeatLocation beatLocation) { StartBeat = beatLocation; return this; }
    public Riff SetEndBeat(BeatLocation beatLocation) { EndBeat = beatLocation; return this; }
}