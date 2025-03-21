using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net.IO
{
    class PacketReader : BinaryReader
    {
        private NetworkStream _stream;
        public PacketReader(NetworkStream stream) : base(stream)
        {
            _stream = stream;
        }
        public string ReadMessage()
        {
            byte[] buffer;
            var len = ReadInt32();
            buffer = new byte[len];
            _stream.Read(buffer, 0, len);
            var msg = Encoding.ASCII.GetString(buffer);
            return msg;
        }
    }
}
