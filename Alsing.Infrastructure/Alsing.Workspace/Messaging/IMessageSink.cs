﻿namespace Alsing.Messaging
{
    public interface IMessageSink
    {
        void Send<T>(T message) where T : class, IMessage;
    }
}