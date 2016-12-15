namespace MonoGameGui.Toolkit
{
    using System;

    public class WindowInvalidMinimumSizeException : Exception
    {
        public WindowInvalidMinimumSizeException()
        {
        }

        public WindowInvalidMinimumSizeException(string message)
            : base(message)
        {
        }

        public WindowInvalidMinimumSizeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
