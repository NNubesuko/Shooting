using System.IO;

namespace KataokaLib.Extension.Directory
{
    public static class DirectoryExtension
    {
        /// <summary>
        /// ディレクトリが存在しなければ、ディレクトリを作成する
        /// </summary>
        /// <param name="path">Assets/{任意のディレクトリ名} のようなパスを渡す</param>
        /// <returns>ディレクトリの情報</returns>
        public static DirectoryInfo Create(string path)
        {
            if (!global::System.IO.Directory.Exists(path))
            {
                return global::System.IO.Directory.CreateDirectory(path);
            }

            return null;
        }
    }
}