﻿namespace Microsoft.Dafny.LanguageServer.Language {
  /// <summary>
  /// Options for the ghost state diagnostics.
  /// </summary>
  public class GhostOptions {
    /// <summary>
    /// The IConfiguration section of the ghost options.
    /// </summary>
    public const string Section = "Ghost";

    /// <summary>
    /// Gets or sets whether designators to ghost states should be faded out.
    /// </summary>
    public bool FadeDesignators { get; set; }

    /// <summary>
    /// Gets or sets whether the declarations of ghost states should be faded out.
    /// </summary>
    public bool FadeDeclarations { get; set; }
  }
}
