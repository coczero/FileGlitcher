﻿using FileGlitcher.Models.Processors;
using System.Collections.Generic;

namespace FileGlitcher.Models
{
  /// <summary>
  /// Configuration for the <see cref="Glitcher"/>.
  /// </summary>
  class GlitcherConfiguration
  {
    #region Properties

    /// <summary>
    /// The file to glitch.
    /// </summary>
    public BaseFile FileToGlitch;

    /// <summary>
    /// The processor chain used to
    /// glitch the <see cref="FileToGlitch"/>.
    /// </summary>
    public List<ProcessorBase> ProcessorChain { get; private set; }

    #endregion Properties

    public GlitcherConfiguration(BaseFile fileToGlitch)
    {
      FileToGlitch = fileToGlitch;
      ProcessorChain = new List<ProcessorBase>();
    }
  }
}