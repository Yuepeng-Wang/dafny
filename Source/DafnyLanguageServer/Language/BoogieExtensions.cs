﻿using Microsoft.Boogie;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;

namespace Microsoft.Dafny.LanguageServer.Language {
  /// <summary>
  /// Extension methods for the use with boogie data.
  /// </summary>
  public static class BoogieExtensions {
    /// <summary>
    /// The offset to convert a boogie line-number to an LSP line-number.
    /// </summary>
    private const int LineOffset = -1;

    /// <summary>
    /// The offset to convert a boogie column-number to an LSP column-number.
    /// </summary>
    private const int ColumnOffset = -1;

    /// <summary>
    /// Gets the LSP range of the specified token.
    /// </summary>
    /// <param name="token">The token to get the range of.</param>
    /// <param name="other">An optional other token to get the end of the range of.</param>
    /// <returns>The LSP range of the token.</returns>
    public static Range GetLspRange(this IToken token, IToken? other = null) {
      other ??= token;
      return new Range(
        GetLspPosition(token),
        ToLspPosition(other.line, other.col + other.val.Length)
      );
    }

    /// <summary>
    /// Gets the LSP position of the specified token (i.e., the position of the first character of the token).
    /// </summary>
    /// <param name="token">The token to get the position of.</param>
    /// <param name="end">Whether to take the ending position of the token instead.</param>
    /// <returns>The LSP position of the token.</returns>
    public static Position GetLspPosition(this IToken token, bool end = false) {
      return ToLspPosition(token.line, token.col + (end ? token.val.Length : 0));
    }

    /// <summary>
    /// Converts a given line and column of a boogie document to its LSP counterpart.
    /// </summary>
    /// <param name="boogieLine">The line in the boogie format.</param>
    /// <param name="boogieColumn">The column in the boogie format.</param>
    /// <returns>The given boogie line and column as a LSP position.</returns>
    public static Position ToLspPosition(int boogieLine, int boogieColumn) {
      return new Position(boogieLine + LineOffset, boogieColumn + ColumnOffset);
    }
  }
}
