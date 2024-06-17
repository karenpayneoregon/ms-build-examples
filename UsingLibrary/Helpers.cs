﻿using System.Text.RegularExpressions;

namespace UsingLibrary;

public partial class Helpers
{

    /// <summary>
    /// Wrapper for NextValue as some may like this name
    /// </summary>
    public static string NextInvoiceNumber(string sender)
        => NextValue(sender);


    /// <summary>
    /// Wrapper for NextValue as some may like this name
    /// </summary>
    public static string NextInvoiceNumber(string sender, int incrementBy)
        => NextValue(sender, incrementBy);

    /// <summary>
    /// Given a string which ends with a number, increment the number by  <seealso cref="incrementBy"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="incrementBy">increment by</param>
    /// <returns>string with ending number incremented by <seealso cref="incrementBy"/></returns>
    public static string NextValue(string sender, int incrementBy = 1)
    {
        string value = NumbersPattern().Match(sender).Value;
        return sender[..^value.Length] + (long.Parse(value) + incrementBy)
            .ToString().PadLeft(value.Length, '0');
    }

    [GeneratedRegex("[0-9]+$")]
    private static partial Regex NumbersPattern();
}
