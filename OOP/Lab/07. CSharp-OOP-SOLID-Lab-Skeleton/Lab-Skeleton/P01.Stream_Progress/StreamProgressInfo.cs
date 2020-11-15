﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable streamable;

        public StreamProgressInfo(IStreamable streamable)
        {
            this.streamable = streamable;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamable.BytesSent * 100) / this.streamable.Length;
        }
    }
}
