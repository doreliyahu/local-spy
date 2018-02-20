using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elsoft_local_spy.movers
{
    class Mover
    {
        private string dstPath;

        public Mover(string _dstPath)
        {
            this.dstPath = _dstPath + "/";
        }
        public void MoveDirectory(string SourcePath, string SubDstDirectory)
        {
            string dstDirPath = this.dstPath + "/" + SubDstDirectory + "/";
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(SourcePath, dstDirPath));
            }
            //Copy all the files & Replaces any files with the same name
            foreach (string dstPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
            {
                try { File.Copy(dstPath, dstPath.Replace(SourcePath, dstDirPath), true); }
                catch { }
            }
        }
        public void MoveFile(string _srcFilePath, string _dstFilePath = null)
        {
            if (_dstFilePath == null)
            {
                _dstFilePath = this.dstPath;
            }
            
            System.IO.File.Copy(_srcFilePath, _dstFilePath, true);
        }
    }
}
