
namespace MusicTheory.Rhythms
{
    /**********|| THIS IS ALL ASSUMING 4/4 TIME ||**********/

    public static class RhythmDefinitions { }

    //Whole note = 240 / BPM
    //Half note = 120 / BPM
    //Dotted quarter note = 90 / BPM
    //Quarter note = 60 / BPM
    //Dotted eighth note = 45 / BPM
    //Eighth note = 30 / BPM
    //Triplet eighth note = 20 / BPM
    //Sixteenth note = 15 / BPM
    //unit = 

    //    One = 01 + 00, OneE = 04 + 00, OneT = 05 + 00, OneN = 07 + 00, OneL = 09 + 00, OneA = 10 + 00,
    //    Two = 01 + 12, TwoE = 04 + 12, TwoT = 05 + 12, TwoN = 07 + 12, TwoL = 09 + 12, TwoA = 10 + 12,
    //    Thr = 01 + 24, ThrE = 04 + 24, ThrT = 05 + 24, ThrN = 07 + 24, ThrL = 09 + 24, ThrA = 10 + 24,
    //    For = 01 + 36, ForE = 04 + 36, ForT = 05 + 36, ForN = 07 + 36, ForL = 09 + 36, ForA = 10 + 36
    //    //out of 48 (last 2 are space)

    //    //||1 . . e T . + . L a . . 2 . . e T . + . L a . . 3 . . e T . + . L a . . 4 . . e T . + . L a . . |ALL
    //    //||1 . . . 5 . . . . 10. . . . 5 . . . . 20. . . . 5 . . . . 30. . . . 5 . . . . 40. . . . 5 . . 48|spaces
    //    //||1 . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . |WHOLE
    //    //||1 . . . . . . . . . . . . . . . . . . . . . . . 3 . . . . . . . . . . . . . . . . . . . . . . . |HALF
    //    //||1 . . . . . . . . . . . . . . . T . . . . . . . . . . . . . . . L . . . . . . . . . . . . . . . |TRIP QUARTER
    //    //||1 . . . . . . . . . . . 2 . . . . . . . . . . . 3 . . . . . . . . . . . 4 . . . . . . . . . . . |QUARTER
    //    //||1 . . . . . . . T . . . . . . . L . . . . . . . 3 . . . . . . . T . . . . . . . L . . . . . . . |TRIP QUARTER
    //    //||1 . . . . . + . . . . . 2 . . . . . + . . . . . 3 . . . . . + . . . . . 4 . . . . . + . . . . . |EIGHTH
    //    //||1 . . . T . . . L . . . 2 . . . T . . . L . . . 3 . . . T . . . L . . . 4 . . . T . . . L . . . |TRIP EIGHTH
    //    //||1 . . e . . + . . a . . 2 . . e . . + . . a . . 3 . . e . . + . . a . . 4 . . e . . + . . a . . |SIXTEENTH


    public struct BeatLocation
    {
        public MeasureNumber MeasureNumber;
        public BeatAssignment BeatAssignment;
        public readonly int BeatValue => BeatSpacingValue(this);

        public BeatLocation SetMeasure(MeasureNumber measure) { MeasureNumber = measure; return this; }
        public BeatLocation SetBeat(BeatAssignment beat) { BeatAssignment = beat; return this; }

        public BeatLocation(MeasureNumber measure, BeatAssignment beat) { MeasureNumber = measure; BeatAssignment = beat; }

        /// <summary>
        /// Measure one, Count one, on the downbeat.
        /// </summary>
        public static BeatLocation DownBeat => new() { MeasureNumber = MeasureNumber.One, BeatAssignment = BeatAssignment.OneD };
        /// <summary>
        /// Default cut off point for a one bar clip;
        /// </summary>
        public static BeatLocation OneBarThenOff => new() { MeasureNumber = MeasureNumber.Two, BeatAssignment = BeatAssignment.ForD };
        /// <summary>
        /// Default cut off point for a four bar clip;
        /// </summary>
        public static BeatLocation FourBarsThenOff => new() { MeasureNumber = MeasureNumber.Fiv, BeatAssignment = BeatAssignment.ForD };

        public static int operator +(BeatLocation a, BeatLocation b) => BeatSpacingValue(a) + BeatSpacingValue(b);
        public static int operator -(BeatLocation a, BeatLocation b) => BeatSpacingValue(a) - BeatSpacingValue(b);

        public static int BeatSpacingValue(BeatLocation bl) => (bl.MeasureNumber - 1 * 48) +
                                                               (bl.BeatAssignment.Count - 1 * 12) +
                                                               (bl.BeatAssignment.SubBeatAssignment - 1);
    }

    public class BeatAssignment : Enumeration
    {
        public Count Count;
        public SubBeatAssignment SubBeatAssignment;
        private BeatAssignment(int id, string name) : base(id, name) { }

        public static BeatAssignment OneD => new(01, nameof(OneD)) { Count = Count.One, SubBeatAssignment = SubBeatAssignment.D };
        public static BeatAssignment OneE => new(02, nameof(OneE)) { Count = Count.One, SubBeatAssignment = SubBeatAssignment.E };
        public static BeatAssignment OneT => new(03, nameof(OneT)) { Count = Count.One, SubBeatAssignment = SubBeatAssignment.T };
        public static BeatAssignment OneN => new(04, nameof(OneN)) { Count = Count.One, SubBeatAssignment = SubBeatAssignment.N };
        public static BeatAssignment OneL => new(05, nameof(OneL)) { Count = Count.One, SubBeatAssignment = SubBeatAssignment.L };
        public static BeatAssignment OneA => new(06, nameof(TwoA)) { Count = Count.One, SubBeatAssignment = SubBeatAssignment.A };
        public static BeatAssignment TwoD => new(07, nameof(TwoD)) { Count = Count.Two, SubBeatAssignment = SubBeatAssignment.D };
        public static BeatAssignment TwoE => new(08, nameof(TwoE)) { Count = Count.Two, SubBeatAssignment = SubBeatAssignment.E };
        public static BeatAssignment TwoT => new(09, nameof(TwoT)) { Count = Count.Two, SubBeatAssignment = SubBeatAssignment.T };
        public static BeatAssignment TwoN => new(10, nameof(TwoN)) { Count = Count.Two, SubBeatAssignment = SubBeatAssignment.N };
        public static BeatAssignment TwoL => new(11, nameof(TwoL)) { Count = Count.Two, SubBeatAssignment = SubBeatAssignment.L };
        public static BeatAssignment TwoA => new(12, nameof(TwoA)) { Count = Count.Two, SubBeatAssignment = SubBeatAssignment.A };
        public static BeatAssignment ThrD => new(13, nameof(ThrD)) { Count = Count.Thr, SubBeatAssignment = SubBeatAssignment.D };
        public static BeatAssignment ThrE => new(14, nameof(ThrE)) { Count = Count.Thr, SubBeatAssignment = SubBeatAssignment.E };
        public static BeatAssignment ThrT => new(15, nameof(ThrT)) { Count = Count.Thr, SubBeatAssignment = SubBeatAssignment.T };
        public static BeatAssignment ThrN => new(16, nameof(ThrN)) { Count = Count.Thr, SubBeatAssignment = SubBeatAssignment.N };
        public static BeatAssignment ThrL => new(17, nameof(ThrL)) { Count = Count.Thr, SubBeatAssignment = SubBeatAssignment.L };
        public static BeatAssignment ThrA => new(18, nameof(ThrA)) { Count = Count.Thr, SubBeatAssignment = SubBeatAssignment.A };
        public static BeatAssignment ForD => new(19, nameof(ForD)) { Count = Count.For, SubBeatAssignment = SubBeatAssignment.D };
        public static BeatAssignment ForE => new(20, nameof(ForE)) { Count = Count.For, SubBeatAssignment = SubBeatAssignment.E };
        public static BeatAssignment ForT => new(21, nameof(ForT)) { Count = Count.For, SubBeatAssignment = SubBeatAssignment.T };
        public static BeatAssignment ForN => new(22, nameof(ForN)) { Count = Count.For, SubBeatAssignment = SubBeatAssignment.N };
        public static BeatAssignment ForL => new(23, nameof(ForL)) { Count = Count.For, SubBeatAssignment = SubBeatAssignment.L };
        public static BeatAssignment ForA => new(24, nameof(ForA)) { Count = Count.For, SubBeatAssignment = SubBeatAssignment.A };
    }

    public class MeasureNumber : Enumeration
    {
        private MeasureNumber(int id, string name) : base(id, name) { }
        public static MeasureNumber Pickup => new(0, nameof(Pickup));
        public static MeasureNumber One => new(1, nameof(One));
        public static MeasureNumber Two => new(2, nameof(Two));
        public static MeasureNumber Thr => new(3, nameof(Thr));
        public static MeasureNumber For => new(4, nameof(For));
        public static MeasureNumber Fiv => new(5, nameof(Fiv));
    }

    public class Count : Enumeration
    {
        private Count(int id, string name) : base(id, name) { }
        public static Count One => new(01, nameof(One));
        public static Count Two => new(02, nameof(Two));
        public static Count Thr => new(03, nameof(Thr));
        public static Count For => new(04, nameof(For));
        public static Count Fiv => new(05, nameof(Fiv));
        public static Count Six => new(06, nameof(Six));
        public static Count Sev => new(07, nameof(Sev));
        public static Count Eht => new(08, nameof(Eht));
        public static Count Nin => new(09, nameof(Nin));
        public static Count Ten => new(10, nameof(Ten));
        public static Count Elv => new(11, nameof(Elv));
        public static Count Tlv => new(12, nameof(Tlv));
    }

    public class SubBeatAssignment : Enumeration
    {
        private SubBeatAssignment(int id, string name) : base(id, name) { }

        /// <summary>
        /// The Downbeat, conventionally called whatever the count number is.
        /// </summary>
        public static SubBeatAssignment D => new(01, nameof(D));

        /// <summary>
        /// 'e', the first sixteenth note subdivision of the beat.
        /// </summary>
        public static SubBeatAssignment E => new(04, nameof(E));

        /// <summary>
        /// 'trip', first triplet subdivision of the beat. 
        /// </summary>
        public static SubBeatAssignment T => new(05, nameof(T));
        //Sometimes called "and" when counting "1 + a 2 + a ...".
        //Note that triplet names & placement invert at every beat level.

        /// <summary>
        /// '+' : "and", The frist 8th note, or second 16th note subdivision.
        /// </summary>
        public static SubBeatAssignment N => new(07, nameof(N));

        /// <summary>
        /// 'let', second triplet subdivision of the beat. 
        /// </summary>
        public static SubBeatAssignment L => new(09, nameof(L));
        //Sometimes called "and" when counting "1 + a 2 + a ..."
        //Note that triplet names & placement invert at every beat level.

        /// <summary>
        /// 'a' the 3rd and final sixteenth note subdivision.
        /// </summary>
        public static SubBeatAssignment A => new(10, nameof(A));


        /*
                 |pass   the  god  damn  but-ter      |p...
                 |down     e tup    +    let a        |d...
                 |1  .  .  e  T  .  +  .  L  a  .  .  |1... 
                 |1  2  3  4  5  6  7  8  9  10 11 12 |1...
        */
    }
}
