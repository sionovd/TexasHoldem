﻿using System;

namespace Domain.GameCenterModule
{
    [Serializable]
    public class NotEnoughPlayersException : DomainException
    {
        public NotEnoughPlayersException(string message) : base(message)
        {
        }
    }
}