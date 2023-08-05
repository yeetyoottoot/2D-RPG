using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MusicTheory
{
    public static class TonalDefinitions
    {

    }

    public struct Tonality
    {
        public KeyOf KeyOf;
        public Quality Quality;

        public static Tonality CMaj => new() { KeyOf = KeyOf.C, Quality = Quality.Maj };
        public static Tonality Cmin => new() { KeyOf = KeyOf.C, Quality = Quality.min };
        public static Tonality CDom => new() { KeyOf = KeyOf.C, Quality = Quality.Dom };
        public static Tonality Cdim => new() { KeyOf = KeyOf.C, Quality = Quality.dim };
        public static Tonality DbMaj => new() { KeyOf = KeyOf.Db, Quality = Quality.Maj };
        public static Tonality Dbmin => new() { KeyOf = KeyOf.Db, Quality = Quality.min };
        public static Tonality DbDom => new() { KeyOf = KeyOf.Db, Quality = Quality.Dom };
        public static Tonality Dbdim => new() { KeyOf = KeyOf.Db, Quality = Quality.dim };
        public static Tonality DMaj => new() { KeyOf = KeyOf.D, Quality = Quality.Maj };
        public static Tonality Dmin => new() { KeyOf = KeyOf.D, Quality = Quality.min };
        public static Tonality DDom => new() { KeyOf = KeyOf.D, Quality = Quality.Dom };
        public static Tonality Ddim => new() { KeyOf = KeyOf.D, Quality = Quality.dim };
        public static Tonality EbMaj => new() { KeyOf = KeyOf.Eb, Quality = Quality.Maj };
        public static Tonality Ebmin => new() { KeyOf = KeyOf.Eb, Quality = Quality.min };
        public static Tonality EbDom => new() { KeyOf = KeyOf.Eb, Quality = Quality.Dom };
        public static Tonality Ebdim => new() { KeyOf = KeyOf.Eb, Quality = Quality.dim };
        public static Tonality EMaj => new() { KeyOf = KeyOf.E, Quality = Quality.Maj };
        public static Tonality Emin => new() { KeyOf = KeyOf.E, Quality = Quality.min };
        public static Tonality EDom => new() { KeyOf = KeyOf.E, Quality = Quality.Dom };
        public static Tonality Edim => new() { KeyOf = KeyOf.E, Quality = Quality.dim };

        public static Tonality FMaj => new() { KeyOf = KeyOf.F, Quality = Quality.Maj };
        public static Tonality Fmin => new() { KeyOf = KeyOf.F, Quality = Quality.min };
        public static Tonality FDom => new() { KeyOf = KeyOf.F, Quality = Quality.Dom };
        public static Tonality Fdim => new() { KeyOf = KeyOf.F, Quality = Quality.dim };
        public static Tonality GbMaj => new() { KeyOf = KeyOf.Gb, Quality = Quality.Maj };
        public static Tonality Gbmin => new() { KeyOf = KeyOf.Gb, Quality = Quality.min };
        public static Tonality GbDom => new() { KeyOf = KeyOf.Gb, Quality = Quality.Dom };
        public static Tonality Gbdim => new() { KeyOf = KeyOf.Gb, Quality = Quality.dim };
        public static Tonality GMaj => new() { KeyOf = KeyOf.G, Quality = Quality.Maj };
        public static Tonality Gmin => new() { KeyOf = KeyOf.G, Quality = Quality.min };
        public static Tonality GDom => new() { KeyOf = KeyOf.G, Quality = Quality.Dom };
        public static Tonality Gdim => new() { KeyOf = KeyOf.G, Quality = Quality.dim };
        public static Tonality AbMaj => new() { KeyOf = KeyOf.Ab, Quality = Quality.Maj };
        public static Tonality Abmin => new() { KeyOf = KeyOf.Ab, Quality = Quality.min };
        public static Tonality AbDom => new() { KeyOf = KeyOf.Ab, Quality = Quality.Dom };
        public static Tonality Abdim => new() { KeyOf = KeyOf.Ab, Quality = Quality.dim };
        public static Tonality AMaj => new() { KeyOf = KeyOf.A, Quality = Quality.Maj };
        public static Tonality Amin => new() { KeyOf = KeyOf.A, Quality = Quality.min };
        public static Tonality ADom => new() { KeyOf = KeyOf.A, Quality = Quality.Dom };
        public static Tonality Adim => new() { KeyOf = KeyOf.A, Quality = Quality.dim };
        public static Tonality BbMaj => new() { KeyOf = KeyOf.Bb, Quality = Quality.Maj };
        public static Tonality Bbmin => new() { KeyOf = KeyOf.Bb, Quality = Quality.min };
        public static Tonality BbDom => new() { KeyOf = KeyOf.Bb, Quality = Quality.Dom };
        public static Tonality Bbdim => new() { KeyOf = KeyOf.Bb, Quality = Quality.dim };
        public static Tonality BMaj => new() { KeyOf = KeyOf.B, Quality = Quality.Maj };
        public static Tonality Bmin => new() { KeyOf = KeyOf.B, Quality = Quality.min };
        public static Tonality BDom => new() { KeyOf = KeyOf.B, Quality = Quality.Dom };
        public static Tonality Bdim => new() { KeyOf = KeyOf.B, Quality = Quality.dim };

        public static bool operator ==(Tonality a, Tonality b) => a.KeyOf == b.KeyOf && a.Quality == b.Quality;
        public static bool operator !=(Tonality a, Tonality b) => a.KeyOf != b.KeyOf || a.Quality != b.Quality;
        public readonly override bool Equals(object obj) => obj is Tonality e && KeyOf == e.KeyOf && Quality == e.Quality;
        public readonly override int GetHashCode() => HashCode.Combine(KeyOf, Quality);
    }

    public enum KeyOf { C, Db, D, Eb, E, F, Gb, G, Ab, A, Bb, B, }
    public enum Quality { Maj, min, Dom, dim }

    public enum Genre { Rock, Jazz, Blues, Classical, Folk }

}
