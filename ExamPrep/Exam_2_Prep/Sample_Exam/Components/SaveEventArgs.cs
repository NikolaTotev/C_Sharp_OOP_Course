using Common;

namespace Components
{
    public class SaveEventArgs : CommandEventArgs
    {
        public FileDataRecord Data { get; set; }

        public SaveEventArgs(string cmd, FileDataRecord data) : base(cmd)
        {
            Data = data;
        }
    }
}