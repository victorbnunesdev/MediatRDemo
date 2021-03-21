﻿namespace Scheduler.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T @event) where T : Event;
    }
}