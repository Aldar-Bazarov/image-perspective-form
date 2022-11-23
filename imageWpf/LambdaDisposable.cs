﻿using System;

namespace imageWpf
{
    public class LambdaDisposable : IDisposable
    {
        private readonly Action _onDispose;

        public LambdaDisposable(Action onDispose)
        {
            _onDispose = onDispose;
        }

        public void Dispose()
        {
            _onDispose();
        }
    }
}
