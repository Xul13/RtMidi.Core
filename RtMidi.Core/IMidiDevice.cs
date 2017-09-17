﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RtMidi.Core.Tests")]

namespace RtMidi.Core
{
    public interface IMidiDevice
    {
        /// <summary>
        /// Whether or not the device is open
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Open midi device
        /// </summary>
        /// <returns>True if device was opened, false otherwise</returns>
        bool Open();

        /// <summary>
        /// Close midi device (if already open, <see cref="IsOpen"/>)
        /// </summary>
        void Close();
    }
}
