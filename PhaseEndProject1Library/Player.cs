using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseEndProject1Library
{

    [Serializable]
    public class InvalidPlayerIDException : Exception
    {
        public InvalidPlayerIDException() { }
        public InvalidPlayerIDException(string message) : base(message) { }
        public InvalidPlayerIDException(string message, Exception inner) : base(message, inner) { }
        protected InvalidPlayerIDException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    public class Player
    {
        int _playerId;
        public int PlayerId { get { return _playerId; }
            set 
            { 
                if(value <= 0)
                {
                    throw new InvalidPlayerIDException("Its not a valid Player ID to record or search...");
                }
                else
                {
                    _playerId = value;
                }
            }
        }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
    }
}
