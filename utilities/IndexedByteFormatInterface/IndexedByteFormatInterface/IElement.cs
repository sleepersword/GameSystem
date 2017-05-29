using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IndexedByteFormatInterface
{
    public interface IElement
    {
        UInt16 ID { get; }
        string Extension { get; }

        long LengthInBytes { get; }
        Stream GetSourceStream();
    }
}
