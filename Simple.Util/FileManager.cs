using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Diagnostics;

namespace Simple.Util
{

    [Serializable]
    public class FileItem
    {
        public FileItem()
        { }

        #region ˽���ֶ�
        private string _Name;
        private string _FullName;
        private DateTime _CreationDate;
        private bool _IsFolder;
        private long _Size;
        private DateTime _LastAccessDate;
        private DateTime _LastWriteDate;
        private int _FileCount;
        private int _SubFolderCount;
        #endregion

        #region ��������
        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// �ļ���Ŀ¼������Ŀ¼
        /// </summary>
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        /// <summary>
        ///  ����ʱ��
        /// </summary>
        public DateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }

        public bool IsFolder
        {
            get { return _IsFolder; }
            set { _IsFolder = value; }
        }

        /// <summary>
        /// �ļ���С
        /// </summary>
        public long Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        /// <summary>
        /// �ϴη���ʱ��
        /// </summary>
        public DateTime LastAccessDate
        {
            get { return _LastAccessDate; }
            set { _LastAccessDate = value; }
        }

        /// <summary>
        /// �ϴζ�дʱ��
        /// </summary>
        public DateTime LastWriteDate
        {
            get { return _LastWriteDate; }
            set { _LastWriteDate = value; }
        }

        /// <summary>
        /// �ļ�����
        /// </summary>
        public int FileCount
        {
            get { return _FileCount; }
            set { _FileCount = value; }
        }

        /// <summary>
        /// Ŀ¼����
        /// </summary>
        public int SubFolderCount
        {
            get { return _SubFolderCount; }
            set { _SubFolderCount = value; }
        }
        #endregion
    }



    public class FileManager
    {
        private static string strRootFolder;
        public FileManager()
        {
            strRootFolder = HttpContext.Current.Request.PhysicalApplicationPath + "File\\";
            strRootFolder = strRootFolder.Substring(0, strRootFolder.LastIndexOf(@"\"));
        }

        #region Ŀ¼
        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        public static string GetRootPath()
        {
            return strRootFolder;
        }

        /// <summary>
        /// д��Ŀ¼
        /// </summary>
        public static void SetRootPath(string path)
        {
            strRootFolder = path;
        }

        /// <summary>
        /// ��ȡĿ¼�б�
        /// </summary>
        public static List<FileItem> GetDirectoryItems()
        {
            return GetDirectoryItems(strRootFolder);
        }

        /// <summary>
        /// ��ȡĿ¼�б�
        /// </summary>
        public static List<FileItem> GetDirectoryItems(string path)
        {
            List<FileItem> list = new List<FileItem>();
            string[] folders = Directory.GetDirectories(path);
            foreach (string s in folders)
            {
                FileItem item = new FileItem();
                DirectoryInfo di = new DirectoryInfo(s);
                item.Name = di.Name;
                item.FullName = di.FullName;
                item.CreationDate = di.CreationTime;
                item.IsFolder = false;
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region �ļ�

        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="fileFullPath">�ļ�ȫ·��</param>
        /// <returns>bool �Ƿ�ɾ���ɹ�</returns>
        public static bool DeleteFile(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                if (File.GetAttributes(fileFullPath) == FileAttributes.Normal)
                {
                    File.Delete(fileFullPath);
                }
                else
                {
                    File.SetAttributes(fileFullPath, FileAttributes.Normal);
                    File.Delete(fileFullPath);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// ���ݴ������ļ�ȫ·������ȡ�ļ����Ʋ���Ĭ�ϰ�����չ��
        /// </summary>
        /// <param name="fileFullPath">�ļ�ȫ·��</param>
        /// <returns>string �ļ�����</returns>
        public static string GetFileName(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                var f = new FileInfo(fileFullPath);
                return f.Name;
            }
            return null;
        }

        /// <summary>
        /// ���ݴ������ļ�ȫ·������ȡ�ļ����Ʋ���
        /// </summary>
        /// <param name="fileFullPath">�ļ�ȫ·��</param>
        /// <param name="includeExtension">�Ƿ�����ļ���չ��</param>
        /// <returns>string �ļ�����</returns>
        public static string GetFileName(string fileFullPath, bool includeExtension)
        {
            if (File.Exists(fileFullPath))
            {
                var f = new FileInfo(fileFullPath);
                if (includeExtension)
                {
                    return f.Name;
                }
                return f.Name.Replace(f.Extension, "");
            }
            return null;
        }

        /// <summary>
        /// ���ݴ������ļ�ȫ·������ȡ�µ��ļ�����ȫ·��,һ��������ʱ������
        /// </summary>
        /// <param name="fileFullPath">�ļ�ȫ·��</param>
        /// <returns>string �µ��ļ�ȫ·������</returns>
        public static string GetNewFileFullName(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                var f = new FileInfo(fileFullPath);
                string tempFileName = fileFullPath.Replace(f.Extension, "");
                for (int i = 0; i < 1000; i++)
                {
                    fileFullPath = tempFileName + i.ToString() + f.Extension;
                    if (File.Exists(fileFullPath) == false)
                    {
                        break;
                    }
                }
            }
            return fileFullPath;
        }

        /// <summary>
        /// ���ݴ������ļ�ȫ·������ȡ�ļ���չ����������.�����硰doc��
        /// </summary>
        /// <param name="fileFullPath">�ļ�ȫ·��</param>
        /// <returns>string �ļ���չ��</returns>
        public static string GetFileExtension(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                var f = new FileInfo(fileFullPath);
                return f.Extension;
            }
            return null;
        }

        /// <summary>
        /// ���ݴ������ļ�ȫ·�����ⲿ���ļ���Ĭ����ϵͳע�����͹��������
        /// </summary>
        /// <param name="fileFullPath">�ļ�ȫ·��</param>
        /// <returns>bool �ļ�����</returns>
        public static bool OpenFile(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                Process.Start(fileFullPath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// ���ݴ������ļ�ȫ·�����õ��ļ���С���淶�ļ���С�ƺ�����1�ǣ����ϣ���λ�ãǣ£����ͣ����ϣ���λ�ãͣ£����ͣ����£���λ�ãˣ�
        /// </summary>
        /// <param name="fileFullPath">�ļ�ȫ·��</param>
        /// <returns>bool �ļ���С</returns>
        public static string GetFileSize(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                var f = new FileInfo(fileFullPath);
                long fl = f.Length;
                if (fl > 1024 * 1024 * 1024)
                {
                    return Convert.ToString(Math.Round((fl + 0.00) / (1024 * 1024 * 1024), 2)) + " GB";
                }
                if (fl > 1024 * 1024)
                {
                    return Convert.ToString(Math.Round((fl + 0.00) / (1024 * 1024), 2)) + " MB";
                }
                return Convert.ToString(Math.Round((fl + 0.00) / 1024, 2)) + " KB";
            }
            return null;
        }

        /// <summary>
        /// �ļ�ת���ɶ����ƣ����ض���������Byte[]
        /// </summary>
        /// <param name="fileFullPath">�ļ�ȫ·��</param>
        /// <returns>byte[] �����ļ����Ķ���������</returns>
        public static byte[] FileToStreamByte(string fileFullPath)
        {
            byte[] fileData = null;
            if (File.Exists(fileFullPath))
            {
                var fs = new FileStream(fileFullPath, FileMode.Open);
                fileData = new byte[fs.Length];
                fs.Read(fileData, 0, fileData.Length);
                fs.Close();
            }
            return fileData;
        }

        /// <summary>
        /// ����������Byte[]�����ļ�
        /// </summary>
        /// <param name="createFileFullPath">Ҫ���ɵ��ļ�ȫ·��</param>
        /// <param name="streamByte">Ҫ�����ļ��Ķ����� Byte ����</param>
        /// <returns>bool �Ƿ����ɳɹ�</returns>
        public static bool ByteStreamToFile(string createFileFullPath, byte[] streamByte)
        {
            if (File.Exists(createFileFullPath) == false)
            {
                FileStream fs = File.Create(createFileFullPath);
                fs.Write(streamByte, 0, streamByte.Length);
                fs.Close();
                return true;
            }
            return false;
        }

        /// <summary>
        /// ����������Byte[]�����ļ�������֤�ļ��Ƿ���ڣ���������ɾ��
        /// </summary>
        /// <param name="createFileFullPath">Ҫ���ɵ��ļ�ȫ·��</param>
        /// <param name="streamByte">Ҫ�����ļ��Ķ����� Byte ����</param>
        /// <param name="fileExistsDelete">ͬ·���ļ������Ƿ���ɾ��</param>
        /// <returns>bool �Ƿ����ɳɹ�</returns>
        public static bool ByteStreamToFile(string createFileFullPath, byte[] streamByte, bool fileExistsDelete)
        {
            if (File.Exists(createFileFullPath))
            {
                if (fileExistsDelete && DeleteFile(createFileFullPath) == false)
                {
                    return false;
                }
            }
            FileStream fs = File.Create(createFileFullPath);
            fs.Write(streamByte, 0, streamByte.Length);
            fs.Close();
            return true;
        }

        /// <summary>
        /// ��д�ļ���������ƥ�������滻
        /// </summary>
        /// <param name="pathRead">��ȡ·��</param>
        /// <param name="pathWrite">д��·��</param>
        /// <param name="replaceStrings">�滻�ֵ�</param>
        public static void ReadAndWriteFile(string pathRead, string pathWrite, Dictionary<string, string> replaceStrings)
        {
            var objReader = new StreamReader(pathRead);
            if (File.Exists(pathWrite))
            {
                File.Delete(pathWrite);
            }
            var streamw = new StreamWriter(pathWrite, false, Encoding.GetEncoding("utf-8"));
            var readLine = objReader.ReadToEnd();
            if (replaceStrings != null && replaceStrings.Count > 0)
            {
                foreach (var dicPair in replaceStrings)
                {
                    readLine = readLine.Replace(dicPair.Key, dicPair.Value);
                }
            }
            streamw.WriteLine(readLine);
            objReader.Close();
            streamw.Close();
        }

        /// <summary>
        /// ��ȡ�ļ�
        /// </summary>
        /// <param name="filePath">�ļ�·��</param>
        /// <returns>����ֵ</returns>
        public static string ReadFile(string filePath)
        {
            var objReader = new StreamReader(filePath);
            string readLine = null;
            if (File.Exists(filePath))
            {
                readLine = objReader.ReadToEnd();
            }
            objReader.Close();
            return readLine;
        }

        /// <summary>
        /// д���ļ�
        /// </summary>
        /// <param name="pathWrite">д��·��</param>
        /// <param name="content">����</param>
        public static void WriteFile(string pathWrite, string content)
        {
            if (File.Exists(pathWrite))
            {
                File.Delete(pathWrite);
            }
            var streamw = new StreamWriter(pathWrite, false, Encoding.GetEncoding("utf-8"));
            streamw.WriteLine(content);
            streamw.Close();
        }

        /// <summary>
        /// ��ȡ�������ı�
        /// </summary>
        /// <param name="filePath">�ļ�·��</param>
        /// <param name="content">����</param>
        public static void ReadAndAppendFile(string filePath, string content)
        {
            File.AppendAllText(filePath, content, Encoding.GetEncoding("utf-8"));
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="sources">Դ�ļ�</param>
        /// <param name="dest">Ŀ���ļ�</param>
        public static void CopyFile(string sources, string dest)
        {
            var dinfo = new DirectoryInfo(sources);
            foreach (FileSystemInfo f in dinfo.GetFileSystemInfos())
            {
                var destName = Path.Combine(dest, f.Name);
                if (f is FileInfo)
                {
                    File.Copy(f.FullName, destName, true);
                }
                else
                {
                    Directory.CreateDirectory(destName);
                    CopyFile(f.FullName, destName);
                }
            }
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="sources">Դ�ļ�</param>
        /// <param name="dest">Ŀ���ļ�</param>
        public static void MoveFile(string sources, string dest)
        {
            var dinfo = new DirectoryInfo(sources);
            foreach (FileSystemInfo f in dinfo.GetFileSystemInfos())
            {
                var destName = Path.Combine(dest, f.Name);
                if (f is FileInfo)
                {
                    File.Move(f.FullName, destName);
                }
                else
                {
                    Directory.CreateDirectory(destName);
                    MoveFile(f.FullName, destName);
                }
            }
        }

        /// <summary>
        /// ���ָ���ļ��Ƿ����,��������򷵻�true��
        /// </summary>
        /// <param name="filePath">�ļ��ľ���·��</param>
        /// <returns>bool �Ƿ�����ļ�</returns>
        public static bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }

        #endregion

        #region �ļ���
        /// <summary>
        /// �����ļ���
        /// </summary>
        public static void CreateFolder(string name, string parentName)
        {
            DirectoryInfo di = new DirectoryInfo(parentName);
            di.CreateSubdirectory(name);
        }

        /// <summary>
        /// ɾ���ļ���
        /// </summary>
        public static bool DeleteFolder(string path)
        {
            try
            {
                Directory.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// �ƶ��ļ���
        /// </summary>
        public static bool MoveFolder(string oldPath, string newPath)
        {
            try
            {
                Directory.Move(oldPath, newPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// �����ļ���
        /// </summary>
        public static bool CopyFolder(string source, string destination)
        {
            try
            {
                String[] files;
                if (destination[destination.Length - 1] != Path.DirectorySeparatorChar) destination += Path.DirectorySeparatorChar;
                if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);
                files = Directory.GetFileSystemEntries(source);
                foreach (string element in files)
                {
                    if (Directory.Exists(element))
                        CopyFolder(element, destination + Path.GetFileName(element));
                    else
                        File.Copy(element, destination + Path.GetFileName(element), true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region ����ļ�
        /// <summary>
        /// �ж��Ƿ�Ϊ��ȫ�ļ���
        /// </summary>
        /// <param name="str">�ļ���</param>
        public static bool IsSafeName(string strExtension)
        {
            strExtension = strExtension.ToLower();
            if (strExtension.LastIndexOf(".") >= 0)
            {
                strExtension = strExtension.Substring(strExtension.LastIndexOf("."));
            }
            else
            {
                strExtension = ".txt";
            }
            string[] arrExtension = { ".htm", ".html", ".txt", ".js", ".css", ".xml", ".sitemap", ".jpg", ".gif", ".png", ".rar", ".zip" };
            for (int i = 0; i < arrExtension.Length; i++)
            {
                if (strExtension.Equals(arrExtension[i]))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  �ж��Ƿ�Ϊ����ȫ�ļ���
        /// </summary>
        /// <param name="str">�ļ������ļ�����</param>
        public static bool IsUnsafeName(string strExtension)
        {
            strExtension = strExtension.ToLower();
            if (strExtension.LastIndexOf(".") >= 0)
            {
                strExtension = strExtension.Substring(strExtension.LastIndexOf("."));
            }
            else
            {
                strExtension = ".txt";
            }
            string[] arrExtension = { ".", ".asp", ".aspx", ".cs", ".net", ".dll", ".config", ".ascx", ".master", ".asmx", ".asax", ".cd", ".browser", ".rpt", ".ashx", ".xsd", ".mdf", ".resx", ".xsd" };
            for (int i = 0; i < arrExtension.Length; i++)
            {
                if (strExtension.Equals(arrExtension[i]))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  �ж��Ƿ�Ϊ�ɱ༭�ļ�
        /// </summary>
        /// <param name="str">�ļ������ļ�����</param>
        public static bool IsCanEdit(string strExtension)
        {
            strExtension = strExtension.ToLower();

            if (strExtension.LastIndexOf(".") >= 0)
            {
                strExtension = strExtension.Substring(strExtension.LastIndexOf("."));
            }
            else
            {
                strExtension = ".txt";
            }
            string[] arrExtension = { ".htm", ".html", ".txt", ".js", ".css", ".xml", ".sitemap" };
            for (int i = 0; i < arrExtension.Length; i++)
            {
                if (strExtension.Equals(arrExtension[i]))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}