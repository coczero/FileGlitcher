﻿using System;

namespace FileGlitcher.Processors.ByteIndexProviders
{
  /// <summary>
  /// Byte rule where every nth byte is selected
  /// for glitching.
  /// </summary>
  public class EveryNthByteIndexProvider : ByteIndexProviderBase
  {
    #region Member

    /// <summary>
    /// Every 'nth' byte should be glitched.
    /// </summary>
    private uint _n;

    #endregion Member

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="maxNumBytesToGlitch">Maximum number of bytes to glitch.</param>
    /// <param name="n"/>Byte skip factor.
    public EveryNthByteIndexProvider(ByteRange range, uint maxNumBytesToGlitch, uint n)
      : base(range, maxNumBytesToGlitch)
    {
      if (n == 0 || n > range.End - range.Start)
        throw new ArgumentOutOfRangeException(nameof(n));
      if (maxNumBytesToGlitch == 0)
        throw new ArgumentOutOfRangeException(nameof(maxNumBytesToGlitch));

      _n = n;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="n">Byte skip factor.</param>
    public EveryNthByteIndexProvider(ByteRange range, uint n)
      : this(range, range.End - range.Start, n)
    { }

    /// <summary>
    /// Creates the possible byte indexes to use.
    /// </summary>
    public override void CreatePossibleByteIndexes()
    {
      for (uint i = 0; i <= _range.End - _range.Start; i++)
      {
        if ((i + 1) % _n == 0)
          _possibleByteIndexes.Add(_range.Start + i);
        if (_possibleByteIndexes.Count == _numBytesToGlitch)
          return;
      }
    }
  }
}