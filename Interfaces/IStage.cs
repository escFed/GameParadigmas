﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public interface IStage
    {
        void Initialize();
        void Reset();
        void Update();
        void Render();
        void StopMusic();
    }
}
