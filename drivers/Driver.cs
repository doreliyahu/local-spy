using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elsoft_local_spy.drivers
{
    class Driver
    {
        private string path;        //Name
        private int size;           //TotalSize
        private int freeSpace;      //TotalFreeSpace
        private int availableSpace; //AvailableFreeSpace
        private string name;        //VolumeLabel
        private string format;      //DriveFormat
        private DriveType type;     //DriveType
        private bool ready;         //IsReady

        public Driver(string _path, bool _ready, DriveType _type, string _name)
        {
            path = _path;
            ready = _ready;
            type = _type;
            name = _name;
        }

        public bool IsHardDrive()
        {
            return (ready && type == DriveType.Removable);
        }

        public string Path
        {
            get => path;
        }
        public string Name
        {
            get => name;
        }

        public string[] Directories
        {
            get => Directory.GetDirectories(path);
        }

        public string[] Files
        {
            get {
                List<string> files = new List<string>();
                foreach (string dir in Directories)
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        files.Add(file);
                    }
                }
                return files.ToArray();
            }
        }
    }
}
