using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Day11.data
{
    public static class Ignoration
    {
        #pragma warning disable S2386 // Mutable fields should not be "public static"
        #pragma warning disable S1104 // Fields should not have public accessibility
        #pragma warning disable S2223 // Non-constant static fields should not be visible
        public static HashSet<string> ToIgnore = new HashSet<string>();

    }
}
