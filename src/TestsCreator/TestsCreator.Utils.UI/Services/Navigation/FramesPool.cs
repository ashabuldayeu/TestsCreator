using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace TestsCreator.Utils.UI.Services.Navigation
{
    public static class FramesPool
    {
        private static ConcurrentDictionary<string, Frame> _storedFrames = new ConcurrentDictionary<string, Frame>();

        public static void InitFrame(Frame frame, string frameName)
        {
            if (frame is null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            if (string.IsNullOrWhiteSpace(frameName))
            {
                throw new ArgumentException($"'{nameof(frameName)}' cannot be null or empty.", nameof(frameName));
            }

            var success = _storedFrames.TryAdd(frameName, frame);
            if (!success)
            {
                //throw new ArgumentException($"Frame {frameName} already defined.");
                _storedFrames[frameName] = frame;
            }
        }

        public static Frame GetFrame(string frameName)
        {
            if (string.IsNullOrWhiteSpace(frameName))
            {
                throw new ArgumentException($"'{nameof(frameName)}' cannot be null or whitespace.", nameof(frameName));
            }

            return _storedFrames.TryGetValue(frameName, out Frame frame)
                ? frame
                : throw new ArgumentException($"No registered frames with name {frameName}");
        }

        public static Frame GetDefaultFrame()
        {
            return _storedFrames.FirstOrDefault().Value;
        }
    }
}
