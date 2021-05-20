using System;

namespace ServerApp.SharedKernel.Helpers
{
    public static class ExceptionHelper
    {
        public static ArgumentNullException ArgNullEx(string message)
            => new ArgumentNullException(message);
    }
}
