using System;

namespace MyGame
{
    class GameObjektExeption:Exception
    {
        public int ErrCode { get; set; }

        public GameObjektExeption(string Msg, int ErrCode):base(Msg)
        {
           this.ErrCode = ErrCode;
        }
    }
}
