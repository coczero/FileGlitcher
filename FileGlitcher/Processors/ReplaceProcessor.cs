﻿using FileGlitcher.Processors.ByteProviders;
using FileGlitcher.Processors.ByteIndexProviders;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Processor that replaces bytes.
  /// </summary>
  public class ReplaceProcessor : ByteProvidedProcessorBase
  {
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteRule">Byte rule to apply.</param>
    /// <param name="byteProvider">Provider of bytes.</param>
    public ReplaceProcessor(ByteIndexProviderBase byteRule, IByteProvider byteProvider)
      : base(byteRule, byteProvider)
    { }

    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes to apply the processor to.</param>
    /// <returns>Modified bytes.</returns>
    public override byte[] Apply(byte[] bytes)
    {
      _byteIndexProvider.CreatePossibleByteIndexes();

      while (_byteIndexProvider.ByteIndexPool.Count != 0)
      {
        bytes[_byteIndexProvider.GetNextByteIndex()] = ByteProvider.GetByte();
      }

      return bytes;
    }
  }
}