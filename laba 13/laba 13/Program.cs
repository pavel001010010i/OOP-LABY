using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace laba_13
{
    class Program
    {
        static void Main(string[] args)
        {
            
            System.IO.File.Delete(@"E:\ООП 3 сем\laba 13\VPAInspect\Copyvpadirinfo.txt");
            System.IO.File.Delete(@"E:\ООП 3 сем\laba 13\VPAInspect\VPAFilesnew.txt");
            System.IO.Directory.Delete(@"E:\ООП 3 сем\laba 13\VPAInspect");
            System.IO.File.Delete(@"E:\ООП 3 сем\laba 13\VPAFiles\NewCopyvpadirinfo.txt");
            System.IO.File.Delete(@"E:\ООП 3 сем\laba 13\VPAFiles.gz");


            VPALog vpaLog = new VPALog();
            vpaLog.MethodLog();

            VPADiskInfo vpaDiskInfo = new VPADiskInfo();
            vpaDiskInfo.MetghodFreePlace();

            VPAFileInfo vpaFileInfo = new VPAFileInfo();
            vpaFileInfo.MethodFileInfo();

            VPADirInfo vpaDirInfo = new VPADirInfo();
            vpaDirInfo.VPADirInfoMethod();

            string sourceFile = @"E:\ООП 3 сем\laba 13\VPAFiles\NewCopyvpadirinfo.txt"; // исходный файл
            string compressedFile = @"E:\ООП 3 сем\laba 13\VPAFiles.gz"; // сжатый файл
            string targetFile = @"E:\ООП 3 сем\laba 13\VPAInspect\VPAFilesnew.txt"; // восстановленный файл

            VPAFileManager vpaFileManager = new VPAFileManager();
            vpaFileManager.FileAndDirectoryWorkMethod();
            vpaFileManager.Compress(sourceFile, compressedFile);
            vpaFileManager.Decompress(compressedFile, targetFile);


            ViewVPALogFile viewVPALogFile = new ViewVPALogFile();
            viewVPALogFile.ViewVPALogFileMethod();

        }


    }

   class VPALog
    {
        public void MethodLog()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(@"E:\ООП 3 сем\laba 13\VPAfileInfo.txt");
                fileInfo.Refresh();

                var nameOfFile = fileInfo.Name;
                var fullNameOfFile = fileInfo.FullName;
                var timeOfCreate = fileInfo.CreationTime;
                var timeOfAccess = fileInfo.LastAccessTime;
                var existOfFile = fileInfo.Exists;
                //Оператор using позволяет создавать объект в блоке кода, по завершению которого вызывается метод Dispose у этого объекта,
                //и, таким образом, объект уничтожается.
                using (StreamWriter sw = new StreamWriter(@"E:\ООП 3 сем\laba 13\VPAlogfile.txt", false, Encoding.Default))
                {
                    sw.WriteLine($"File name: {nameOfFile}");
                    sw.WriteLine($"Full file path: {fullNameOfFile}");
                    sw.WriteLine($"Date and time of file creation by user: {timeOfCreate}");
                    sw.WriteLine($"Date and time the file was last modified by the user.: {timeOfAccess}");
                    sw.WriteLine($"File existence: {existOfFile}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

   class VPADiskInfo
    {
        public void MetghodFreePlace()
        {
            try
            {
                DriveInfo[] drifeInfo = DriveInfo.GetDrives();//статический метод GetDrives, который возвращает имена всех логических дисков компьютера.

                foreach (DriveInfo drife in drifeInfo)
                {
                    Console.WriteLine($"Объем доступного места на диске:\n{drife.Name} {drife.AvailableFreeSpace}");
                    Console.WriteLine($"Файловая система: {drife.DriveFormat}");
                    Console.WriteLine($"Общий доступный объем места на диске: {drife.TotalFreeSpace}");
                    Console.WriteLine($"Метка тома: {drife.VolumeLabel}");
                    Console.WriteLine($"Oбщий размер диска в байтах: {drife.TotalSize}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    internal class VPAFileInfo
    {
        public void MethodFileInfo()
        {
            FileInfo fileInfo = new FileInfo(@"E:\ООП 3 сем\laba 13\VPAlogfile.txt");
            Console.WriteLine($"\n\nFile name: {fileInfo.Name}");
            Console.WriteLine($"Full file path: {fileInfo.DirectoryName}");
            Console.WriteLine($"File size: {fileInfo.Length}");
            Console.WriteLine($"File extension: {fileInfo.Extension}");
            Console.WriteLine($"File creation time: {fileInfo.CreationTime}");
        }
    }

    class VPADirInfo
    {
        //Класс Directory предоставляет ряд статических методов для управления каталогами. 
        public void VPADirInfoMethod()
        {
            Console.WriteLine("\nПодкаталоги каталога E:");
            string[] dirs = Directory.GetDirectories("E:\\"); //получает список каталогов в каталоге
            foreach (string s in dirs)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine($"\nКоличество подкаталогов каталога  E = {dirs.Length}");

            Console.WriteLine("\nФайлы:");
            string[] files = Directory.GetFiles("E:\\"); //получает список файлов в каталоге
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine($"\nКоличество подкаталогов каталога E = {files.Length}");

            var time = Directory.GetCreationTime("E:\\"); 
            Console.WriteLine($"Дата создания каталога E: {time}");

            var parent = Directory.GetParent("E:\\");
            Console.WriteLine($"Родительский каталог каталога E: {parent}");
        }

    }

    class VPAFileManager
    {
        public void FileAndDirectoryWorkMethod()
        {
            Console.WriteLine("\n");
            string[] listFiles = Directory.GetFiles("C:\\");
            string[] listDirectories = Directory.GetDirectories("C:\\");//список папок

            Console.WriteLine("\nСписок файлов каталога C");
            foreach (string i in listFiles)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nСписок папок каталога C:");
            foreach (string j in listDirectories)
            {
                Console.WriteLine(j);
            }

            Console.WriteLine("\nДерикторий создан.");
            Directory.CreateDirectory(@"E:\ООП 3 сем\laba 13\VPAInspect");

            Console.WriteLine("Creating a file and writing to it.");

            using (StreamWriter streamWriter = new StreamWriter(@"E:\ООП 3 сем\laba 13\VPAInspect\vpadirinfo.txt", true, Encoding.Default))
            {
                streamWriter.Write("Me like this laba");
                streamWriter.Close();
            }

            Console.WriteLine("\nFile copy created.");
            File.Copy(@"E:\ООП 3 сем\laba 13\VPAInspect\vpadirinfo.txt", @"E:\ООП 3 сем\laba 13\VPAInspect\Copyvpadirinfo.txt", false);

            Console.WriteLine("First file deleted.");
            File.Delete(@"E:\ООП 3 сем\laba 13\VPAInspect\vpadirinfo.txt");

            Directory.CreateDirectory(@"E:\ООП 3 сем\laba 13\VPAFiles");

            File.Copy(@"E:\ООП 3 сем\laba 13\VPAInspect\Copyvpadirinfo.txt", @"E:\ООП 3 сем\laba 13\VPAFiles\NewCopyvpadirinfo.txt", false);

        }

        public void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }

        public void Decompress(string compressedFile, string targetFile)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }
    }

    class ViewVPALogFile
    {
        public void ViewVPALogFileMethod()
        {
            string date = DateTime.Now.ToString("dd.mm.yy") + "" + DateTime.Now.Hour;
            using (StreamReader streamReader = new StreamReader(@"E:\ООП 3 сем\laba 13\VPAlogfile.txt", Encoding.Default))
            {
                Console.WriteLine();
                string str = " ";
                string stroka = streamReader.ReadToEnd();
                Console.WriteLine(stroka);
                int i = 0;
                foreach(string s in File.ReadLines(@"E:\ООП 3 сем\laba 13\VPAlogfile.txt"))
                {
                    if (s.Contains("File")) 
                    {
                        str += s + "\n";
                    }
                    i++;
                }
                Console.WriteLine("В файле {0} записей",i);
                Console.WriteLine("Вывод со строки\n"+ str);


            }
        }
    }

}


