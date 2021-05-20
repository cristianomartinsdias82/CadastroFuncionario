﻿using static ServerApp.SharedKernel.Helpers.ExceptionHelper;

namespace ServerApp.SharedKernel
{
    public class FailureDetail
    {
        public string Field { get; private set; }
        public string Description { get; private set; }

        public FailureDetail(string field, string description)
        {
            Field = field ?? throw ArgNullEx(field);
            Description = description ?? throw ArgNullEx(description);
        }
    }
}