using System.IO;
using System.Text;

namespace NearestVehiclePositions.Helpers
{
    public static class BinaryReaderExtensions
    {
        public static StringBuilder ReadNullTerminatedASCIIstring(this BinaryReader binaryReader)
        {
            var nullTerminatedString = new StringBuilder();
            while (true)
            {
                var _byte = binaryReader.ReadByte();
                if (_byte == 0)
                    break;
                nullTerminatedString.Append((char)_byte);
            }
            return nullTerminatedString;
        }
    }
}
