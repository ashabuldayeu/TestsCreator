using System;

namespace TestsCreator.Utils.UI.Services.Navigation.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PresentationFrameAttribute : Attribute
    {
        public PresentationFrameAttribute(string frameName)
        {
            FrameName = frameName;
        }

        public string FrameName { get; }
    }
}
