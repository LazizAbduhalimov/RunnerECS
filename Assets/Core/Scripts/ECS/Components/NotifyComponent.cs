using System;

namespace RunnerECS
{
    public struct NotifyComponent
    {
        public Action<object> OnTriggerEnterEvent;
    }
}