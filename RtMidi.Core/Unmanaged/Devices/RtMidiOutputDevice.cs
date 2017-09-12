﻿using System;
using RtMidi.Core.Unmanaged.API;

namespace RtMidi.Core.Unmanaged.Devices
{
    public class RtMidiOutputDevice : RtMidiDevice
    {
        public RtMidiOutputDevice()
            : base(RtMidiC.Output.CreateDefault())
        {
        }

        public RtMidiOutputDevice(RtMidiApi api, string clientName)
            : base(RtMidiC.Output.Create(api, clientName))
        {
        }

        public override RtMidiApi CurrentApi
        {
            get { return RtMidiC.Output.GetCurrentApi(Handle); }
        }

        protected override void ReleaseDevice()
        {
            RtMidiC.Output.Free(Handle);
        }

        public void SendMessage(byte[] message, int length)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            // While it could emit message parsing error, it still returns 0...!
            RtMidiC.Output.SendMessage(Handle, message, length);
        }
    }
}

/**
 * This is a derived work, based on https://github.com/atsushieno/managed-midi
 * 
 * Copyright (c) 2010 Atsushi Eno
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 * 
 **/